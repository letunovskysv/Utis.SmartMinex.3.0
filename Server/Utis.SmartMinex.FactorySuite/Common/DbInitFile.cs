//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DbInitFile – Чтение файла инциализации базы данных (*.smx).
//--------------------------------------------------------------------------------------------------
#region Using
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

/// <summary> Чтение файла инциализации базы данных (*.smx).</summary>
public class DbInitFile : List<ZObject>
{
    #region Declarations

    const string OBJECTS = "objects";
    const string ATTRIBUTES = "attributes";
    const string ITEMS = "data";
    const string ID = "id";
    const string PARENT = "parent";
    const string TYPE = "type";
    const string SOURCE = "source";

    /// <summary> Возвращает список записей БД.</summary>
    public readonly Dictionary<string, List<string>> Items = [];

    static readonly JsonSerializerSettings _jsonopts = new() { NullValueHandling = NullValueHandling.Ignore };

    #endregion Declarations

    public DbInitFile(Stream stream)
    {
        string? filename = null;
        string file;
        try
        {
            using var initdb = new ArchiveReader(stream);
            foreach (var fn in ((JObject)JsonConvert.DeserializeObject(initdb.ReadAllText("[content].json")))
                ["solution"]["partnames"].ToString().Split([',', ';'])
                .SelectMany(f => initdb.GetFiles(TPath.GetDirectoryName(f), TPath.GetFileName(f) + ".json")))
            {
                Read((JObject)JsonConvert.DeserializeObject(initdb.ReadAllText(filename = fn)));
            }
        }
        catch (Exception ex)
        {
            throw new Exception(string.Format(STR.FailedReadDatabaseInitFile, filename) + " " + ex.Message);
        }
    }

    #region Private methods

    void Read(JObject input)
    {
        if (input.First is JProperty jsect && jsect.Name == OBJECTS && jsect.Value is JArray jobjects)
            Read(null, jobjects);
    }

    void Read(ZObject? parent, JArray jobjects)
    {
        foreach (JObject jo in jobjects)
        {
            var item = jo.ToObject<ZObject>();
            if (parent != null && !jo.ContainsKey(TYPE)) item.Type = parent.Id;
            if (parent != null && !jo.ContainsKey(PARENT)) item.Parent = item.Type;

            var xitem = (JObject)jo.DeepClone();
            xitem.Remove(OBJECTS);
            xitem.Remove(ATTRIBUTES);
            xitem.Remove(ITEMS);
            if (!xitem.ContainsKey(PARENT)) xitem.Property(ID).AddAfterSelf(new JProperty(PARENT, item.Parent));
            if (!xitem.ContainsKey(TYPE)) xitem.Property(PARENT).AddAfterSelf(new JProperty(TYPE, item.Type));
            item.Definition = xitem.ToString(Formatting.None).ToBinary();

            Add(item);

            if (jo.TryGetValue(ATTRIBUTES, out var jattrs))
                foreach (JObject ja in jattrs)
                {
                    var attr = ja.ToObject<ZObject>();
                    SetJProp(ja, ID, PARENT, attr.Parent = item.Id);
                    SetJProp(ja, PARENT, TYPE, attr.Type = TType.Attribute);
                    attr.Definition = ja.ToString(Formatting.None).ToBinary();
                    Add(attr);
                }

            if (jo.TryGetValue(ITEMS, out var jitems) && jitems.Any())
            {
                var items = new List<string>();
                foreach (JObject ji in jitems)
                    items.Add(string.Concat('(',
                        string.Join(',', ji.Children<JProperty>().Select(r=>string.Concat('"', r.Name, '"'))),
                        ") VALUES (",
                        string.Join(',', ji.Children<JProperty>().Select(r => Sql.AsSqlValue(r.Value is JValue v ? v.Value : null))),
                        ')'));

                Items.Add(jo[SOURCE].ToString(), items);
            }
            if (jo[OBJECTS] is JArray jchild)
                Read(item, jchild);
        }
    }

    static void SetJProp(JObject obj, string prevName, string name, object value)
    {
        if (obj.ContainsKey(name))
            obj[name] = new JValue(value);
        else
            obj.Property(prevName).AddAfterSelf(new JProperty(name, value));
    }

    #endregion Private methods
}
