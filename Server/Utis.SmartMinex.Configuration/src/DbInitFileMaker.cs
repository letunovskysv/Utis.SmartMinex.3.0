//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DbInitFileMaker – Сжатие и объединение файлов инициализации метаданных и данных.
//--------------------------------------------------------------------------------------------------
#region Using
using System.IO.Compression;
using System.Text;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Encodings.Web;
using System.Reflection;
using System;
using System.Reflection.Metadata;
#endregion Using

namespace Utis.SmartMinex.Utils;

class DbInitFileMaker
{
    /// <summary> Файл содержащий схему конфигурации.</summary>
    const string FCONTENT = "[content].json";
    const string ITEMS = "data";

    const string RELEASE = ".release.xml";
    const string DEBUG = ".debug.xml";

    readonly static JsonSerializerOptions _json_opts = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = false
    };

    readonly static Dictionary<string, string> _macros = [];

    static Dictionary<string, string> _addfiles = [];

    public static void Build(string sources, string target, string configuration)
    {
        if (!sources.EndsWith("\\")) sources += "\\";

        if (!Directory.Exists(Path.GetDirectoryName(target)))
            Directory.CreateDirectory(Path.GetDirectoryName(target));

        using (var output = new FileStream(target, FileMode.Create))
        {
            using (var arch = new ZipArchive(output, ZipArchiveMode.Update))
            {
                var config = configuration.ToUpper().Contains("RELEASE") || configuration.ToUpper().Contains("PUBLISH") ? RELEASE : DEBUG;
                foreach (var filename in Directory.GetFiles(sources, "*.*", SearchOption.AllDirectories).OrderBy(f => f))
                    if (!(filename.EndsWith(RELEASE, StringComparison.OrdinalIgnoreCase)
                        || filename.EndsWith(DEBUG, StringComparison.OrdinalIgnoreCase))
                        || filename.EndsWith(config, StringComparison.OrdinalIgnoreCase))
                    {
                        if (_addfiles.Any(f => f.Value.Equals(filename.Replace(sources, string.Empty))))
                            AddContent(arch, filename.Replace(sources, string.Empty).Replace(RELEASE, ".xml").Replace(DEBUG, ".xml"),
                                ConcatFiles(_addfiles.First(f => f.Value.Equals(filename.Replace(sources, string.Empty))).Key, filename));
                        else
                            AddContent(arch, filename.Replace(sources, string.Empty).Replace(RELEASE, ".xml").Replace(DEBUG, ".xml"),
                                ReadFile(filename));
                    }

                foreach (var filename in _addfiles)
                    AddContent(arch, filename.Value, ReadFile(filename.Key));

                output.Flush();
            }
        }
        var color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Выполнено формирование файла инициализации БД dbinit.smx");
        Console.ForegroundColor = color;
    }

    static byte[] ReadFile(string filename)
    {
        var content = JsonNode.Parse(Macros(File.ReadAllText(filename, Encoding.UTF8))) as JsonObject;
        if (filename.EndsWith(FCONTENT))
        {
            var sol = content["solution"] as JsonObject;

            if (!string.IsNullOrEmpty(sol["links"]?.ToString())) // Добавим общие файлы -->
            {
                var path = Path.GetDirectoryName(filename).Split(['\\']);
                var plink = sol["links"].ToString().Split(['\\', '/'], StringSplitOptions.RemoveEmptyEntries).Where(f => f != "*").ToArray();
                var back = plink.Count(f => f == "..");
                var paths = Path.Combine(path[0..^back].Concat(plink.Skip(back)).ToArray());
                _addfiles = Directory.GetFiles(paths, "*.*", SearchOption.AllDirectories).ToDictionary(k => k, v => v.Replace(paths + "\\", string.Empty));
                sol.Remove("links");
            }
            if (sol["version"].ToString().Equals("$(Version)"))
                sol["version"] = typeof(DbInitFileMaker).Assembly.GetName().Version.ToString();

            if (sol["company"].ToString().Equals("$(Company)"))
                sol["company"] = ((AssemblyCompanyAttribute)typeof(DbInitFileMaker).Assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false).First()).Company;

            if (sol["copyright"].ToString().Equals("$(Copyright)"))
                sol["copyright"] = ((AssemblyCopyrightAttribute)typeof(DbInitFileMaker).Assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false).First()).Copyright;

            if (content["macros"] is JsonObject macros)
            {
                foreach (var m in macros)
                    _macros.Add(string.Concat("$(", m.Key, ')'), m.Value.ToString());

                content.Remove("macros");
            }
        }
        if (Path.GetExtension(filename).Equals(".json", StringComparison.OrdinalIgnoreCase)) // сожмём JSON файлы
            return Encoding.UTF8.GetBytes(content.ToJsonString(_json_opts));

        return File.ReadAllBytes(filename);
    }

    static byte[] ConcatFiles(string filename1, string filename2)
    {
        var f1 = JsonNode.Parse(File.ReadAllText(filename1, Encoding.UTF8)) as JsonObject;
        var f2 = JsonNode.Parse(Macros(File.ReadAllText(filename2, Encoding.UTF8))) as JsonObject;
        var o2 = f2["objects"] as JsonArray;
        foreach (JsonObject o1 in f1["objects"] as JsonArray)
        {
            var objid = o1["id"].GetValue<long>();
            if (o2.FirstOrDefault(e => e["id"].GetValue<long>() == objid) is JsonObject tar)
                foreach (var p in tar.ToArray())
                    switch (p.Key)
                    {
                        case ITEMS:
                            o1.Add(p.Key, p.Value.DeepClone());
                            break;
                    }
        }
        _addfiles.Remove(filename1);
        return Encoding.UTF8.GetBytes(f1.ToJsonString(_json_opts));
    }

    static string Macros(string value)
    {
        foreach (var m in _macros)
            if (value.Contains(m.Key))
                value = value.Replace(m.Key, m.Value);

        return value;
    }

    static byte[] CompressEncode(byte[] input)
    {
        using (var src = new MemoryStream(input))
        using (var dist = new MemoryStream())
        {
            using (var zip = new DeflateStream(dist, CompressionMode.Compress))
                src.CopyTo(zip);

            byte[] output = dist.ToArray();
            Encoder(output);
            return output;
        }
    }

    static void Encoder(byte[] data)
    {
        for (int i = data.Length - 1; i == 0; i--)
            data[i] = (byte)(((data[i] * 257) >> 4) & 255);

        int n2 = data.Length - 1;
        int n1 = (int)Math.Floor(data.Length / 2d);
        for (int i = --n1; i >= 0; i--)
        {
            byte n = data[i];
            data[i] = (byte)(data[n2 - i] ^ n);
            data[n2 - i] = (byte)(data[i] ^ n);
        }
    }

    static void AddContent(ZipArchive archive, string filename, byte[] content)
    {
        ZipArchiveEntry file = archive.CreateEntry(filename);
        file.Open().Write(content, 0, content.Length);
    }

    static void AddContent(ZipArchive archive, string filename, XElement content, bool formatting = false)
    {
        XDocument xdoc = new XDocument(new XDeclaration("1.0", Encoding.UTF8.WebName, "yes"), content);
        TStringWriter xfile = new TStringWriter(Encoding.UTF8);
        xdoc.Save(xfile, formatting ? SaveOptions.OmitDuplicateNamespaces : SaveOptions.DisableFormatting);
        AddContent(archive, filename, Encoding.UTF8.GetBytes(xfile.ToString()));
    }
}

class TStringWriter : StringWriter
{
    readonly Encoding _encoding;

    public TStringWriter() : this(Encoding.Default)
    { }

    public TStringWriter(Encoding encoding)
    {
        _encoding = encoding;
    }

    public override Encoding Encoding
    {
        get { return _encoding; }
    }
}
