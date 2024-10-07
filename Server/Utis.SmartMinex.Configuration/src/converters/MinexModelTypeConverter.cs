//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: MinexModelTypeConverter – Конвертация типов (моделей) в объекты конфигурации.
// Типы содержаться в библиотеке Modules/Models/Utis.Minex.ProductionModel
// select * from z_objects where typeentity like '%RfidDevice%'
// select * from metadataobject where type like '%RfidDevice%'
//--------------------------------------------------------------------------------------------------
#region Using
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Utils;

/// <summary> Конвертация типов (моделей) в объекты конфигурации.</summary>
class MinexModelTypeConverter
{
    public static string? Build(string modelType, string filename, string connectionString, string productionConnectionString, string metadataConnectionString)
    {
        if (string.IsNullOrEmpty(Path.GetFileName(filename)))
            filename += modelType + ".json";

        var type = typeof(Minex.ProductionModel.Catalog.Organize.Division).Assembly.GetTypes()
            .FirstOrDefault(t => t.Name.Equals(modelType, StringComparison.OrdinalIgnoreCase));

        if (type != null)
        {
            var db = new PgSqlDatabase(connectionString).Open();
            //var dbprod = new PgSqlDatabase(productionConnectionString).Open();
            var dbmeta = new PgSqlDatabase(metadataConnectionString).Open();

            var zobjects = dbmeta.Query($"SELECT* FROM public.z_objects WHERE typeentity = '{type.FullName}'");
            if (zobjects.Rows.Count > 0)
            {
                var maptypes = db.Query("SELECT* FROM config.zobjects WHERE type=" + TType.Type).Rows.Cast<DataRow>().Select(r =>
                {
                    return JsonSerializer.Deserialize<XObject>(Encoding.UTF8.GetString((byte[])r["definition"]), new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }).ToDictionary(k => k.Code, v => v.Id);

                var zmdobj = dbmeta.Query($"SELECT* FROM metadataobject WHERE type = '{type.FullName}'").Rows[0];
                long id = (long)zobjects.Rows[0]["id"];
                var obj = new XObject()
                {
                    Id = id,
                    Parent = TType.Catalog,
                    Type = TType.Catalog,
                    Code = Camel(type.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? zmdobj["name"].ToString()),
                    Name = type.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? zmdobj["name"].ToString(),
                    Description = type.GetCustomAttribute<DescriptionAttribute>()?.Description ?? zmdobj["description"].ToString(),
                    Source = string.Concat("$(Production)", zobjects.Rows[0]["Table"].ToString().ToLower()),
                    Model = string.Concat(type.Name, ", ", Regex.Match(type.Assembly.FullName, @"[\w_\.]+").Value),
                    Flags = null
                };
                var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .OrderBy(p => p.Name switch
                    {
                        "Id" => 0,
                        "Code" => 1,
                        "Name" => 2,
                        "Created" => int.MaxValue - 3,
                        "Updated" => int.MaxValue - 2,
                        "Deleted" => int.MaxValue - 1,
                        "VersionObject" => int.MaxValue,
                        _ => p.DeclaringType.MetadataToken
                    }).ThenBy(p => p.MetadataToken).Select(p =>
                    {
                        var isReference = p.PropertyType != typeof(string) && (p.PropertyType.IsClass || p.PropertyType.IsEnum);
                        var isEnum = p.PropertyType.IsEnum;
                        var dataType = (p.PropertyType.Name.Equals("Nullable`1") ? Regex.Match(p.PropertyType.FullName, @"(?<=\[\[[\w\.]*)[\w]+(?=,)").Value : p.PropertyType.Name).ToLower();
                        var srcsuffix = isReference && !isEnum ? "_id" : string.Empty;
                        long datatype;
                        if (isReference && isEnum)
                            datatype = TType.Int32;
                        else if (isReference)
                            datatype = TType.Int64;
                        else
                            datatype = maptypes[dataType == "string" ? "text" : dataType == "boolean" ? "bool" : dataType];

                        return new XAttribute()
                        {
                            Id = id += 1024,
                            Code = p.Name == "Id" ? "ИД" : Camel(p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? p.Name),
                            Name = p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? p.Name,
                            Source = p.Name.ToLower() + srcsuffix,
                            Description = (p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? p.Name) == p.GetCustomAttribute<DescriptionAttribute>()?.Description ? null : p.GetCustomAttribute<DescriptionAttribute>()?.Description,
                            DataType = datatype,
                            Readonly = p.GetCustomAttribute<ReadOnlyAttribute>()?.IsReadOnly == true ? true : null,
                            Flags = p.Name.Equals("id", StringComparison.OrdinalIgnoreCase) ? "Key" : null,
                            Visible = !new[] { "id", "created", "updated", "deleted", "versionobject" }.Contains(p.Name.ToLower())
                        };
                    }).ToList();

                obj.Attributes = props;
                var collection = new XCollection();
                collection.Objects.Add(obj);

                var res = JsonSerializer.Serialize(collection, typeof(XCollection), new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    PropertyNamingPolicy = new XLowerCasePolicy(),
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    WriteIndented = true
                });
                File.WriteAllText(filename, res, Encoding.UTF8);
                return res;
            }
        }
        return null;
    }

    class XLowerCasePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) =>
            string.IsNullOrEmpty(name) || !char.IsUpper(name[0]) ? name : name.ToLower();
    }

    static string Camel(string value) =>
         string.Concat(value.Split([' ', '/', ',', '-'], StringSplitOptions.RemoveEmptyEntries)
             .Select(a => a[0].ToString().ToUpper() + (a.Length > 1 ? a[1..].ToLower() : string.Empty)));
}
