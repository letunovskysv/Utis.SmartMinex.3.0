//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: SpgtModelTypeConverter – Конвертация типов (моделей) в объекты конфигурации.
// Типы содержаться в библиотеке Modules/Models/Utis.Spgt.ProductionModel
//--------------------------------------------------------------------------------------------------
#region Using
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using Utis.Minex.Common;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Utils;

class SpgtModelTypeConverter
{
    public static string? Build(string assembly, string filename, string connectionString)
    {
        var db = new PgSqlDatabase(connectionString).Open();
        var maptypes = db.Query("SELECT* FROM config.zobjects WHERE type=" + TType.Type).Rows.Cast<DataRow>().Select(r =>
        {
            return JsonSerializer.Deserialize<XObject>(Encoding.UTF8.GetString((byte[])r["definition"]), new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }).ToDictionary(k => k.Code, v => v.Id);

        long id = 4503599627370496;
        long iter = 281474976710656;
        foreach (var type in Assembly.Load(assembly)?.GetTypes().Where(t => t.IsHasAttribute<TableAttribute>(out _)).ToList())
        {
            var src = type.GetCustomAttribute<TableAttribute>().Name;
            var name = type.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>()?.Description ?? type.Name;
            if (string.IsNullOrWhiteSpace(name)) name = src;
            string descr = null;
            if (name.Contains(':'))
            {
                var names = name.Split([':']).Select(s => s.Trim()).ToArray();
                name = names[0];
                descr = names[1];
            }
            var obj = new XObject()
            {
                Id = id,
                Parent = TType.Catalog,
                Type = TType.Catalog,
                Code = Camel(name),
                Name = name,
                Description = descr,
                Source = string.Concat("$(Production)", src),
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

                  name = (p.GetCustomAttribute<System.ComponentModel.DisplayNameAttribute>()?.DisplayName ?? p.Name).Trim();
                  name = name == "Идентификатор" ? name : name.Replace("Идентификатор", "").Trim();
                  descr = null;
                  if (name.Contains(':'))
                  {
                      var names = name.Split([':']).Select(s => s.Trim()).ToArray();
                      name = names[0];
                      descr = names[1];
                  }
                  return new XAttribute()
                  {
                      Id = id += 1024,
                      Code = p.Name == "Id" ? "ИД" : Camel(name),
                      Name = FIO(name),
                      Source = p.GetCustomAttribute<ColumnAttribute>()?.Name ?? p.Name.ToLower(),
                      Description = descr,
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
            var fn = Path.Combine(filename, Camel(src) + ".json");
            if (!File.Exists(fn)) 
                File.WriteAllText(fn, res, Encoding.UTF8);
            id += iter;
        }
        return null;
    }

    static string FIO(string value) =>
         string.Concat(value.Length > 0 ? value[0].ToString().ToUpper() : "", value.Length > 1 ? value[1..] : "");

    static string Camel(string value) =>
         string.Concat(value.Split([' ', '/', '.', ',', '-', '_', '(', ')'], StringSplitOptions.RemoveEmptyEntries)
             .Select(a => a[0].ToString().ToUpper() + (a.Length > 1 ? a[1..].ToLower() : string.Empty)));
}
