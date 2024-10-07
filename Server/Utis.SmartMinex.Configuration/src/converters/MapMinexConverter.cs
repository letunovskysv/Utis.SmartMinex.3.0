//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: MapMinexConverter – Конвертация старых типов схем.
//--------------------------------------------------------------------------------------------------
#region Using
using Newtonsoft.Json.Serialization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Xml.Linq;
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Graphics;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Utils;

/// <summary> Конвертация старых типов схем.</summary>
class MapMinexConverter
{
    public static void ReadScheme(string filename, bool split)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        /*if (File.Exists(filename))
        {
            using (var arh = new ArchiveReader(filename))
                foreach (var fn in arh.GetFiles("map", "*"))
                {
                    var pf = fn.Split(['\\', '/'])[1..];
                    if (pf.Length == 3)
                    {
                        var content = arh.ReadAllText(fn, Encoding.GetEncoding(1251));
                        var xdoc = XDocument.Parse(content);
                        if (horizons.ContainsKey(pf[0]))
                            horizons[pf[0]].Add(pf[1], arh.ReadAllText(fn));
                        else
                            horizons.Add(pf[0], new Dictionary<string, string>() { { pf[1], arh.ReadAllText(fn) } });
                    }
                }
        }*/
        var map = new ZObjects();
        var sch = new ZScheme()
        {
            Id = 13229323905400832,
            Parent = TType.Scheme,
            Type = TType.Scheme,
            Code = "Октябрьский",
            Name = "Рудник Октябрьский",
            Source = "config.zobjects",
            Levels = []
        };
        map.Objects.Add(sch);
        ZLayer lay;
        ZLevel lev;
        long levid = 13229323905400832 + TType.Level;
        long layid = 13229323905400832 + TType.Layer;
        long elmid = 0;
        foreach (var fn in Directory.GetFiles(@"D:\map", "*", SearchOption.AllDirectories).OrderBy(l => float.TryParse(Regex.Match(l, @"\d+").Value, out var hor) ? hor : 0))
        {
            var pf = fn.Split(['\\', '/'])[1..];
            if (pf.Length == 4)
            {
                var content = File.ReadAllText(fn, Encoding.GetEncoding(1251));
                var xdoc = XDocument.Parse(content);
                if (!sch.Levels.Any(l => l.Name == pf[1]))
                {
                    levid += 1024;
                    sch.Levels.Add(lev = new ZLevel()
                    {
                        Id = levid,
                        Parent = 13229323905400832,
                        Type = TType.Level,
                        Code = Regex.Match(pf[1], @"\d+").Value,
                        Name = pf[1],
                        Layers = []
                    });
                    if (split) map.Objects.Add(lev);
                }
                lev = sch.Levels.First(l => l.Name == pf[1]);
                layid += 1024;
                lev.Layers.Add(lay = new ZLayer()
                {
                    Id = layid,
                    Parent = levid,
                    Type = TType.Layer,
                    Code = pf[2],
                    Name = GetLayerName(pf[2]),
                    Nodes = [],
                    Sections = []
                });
                foreach (var node in xdoc.Root.Element("nodes")?.Elements() ?? [])
                {
                    lay.Nodes.Add(new ZNode()
                    {
                        Id1 = node.Attribute("id").Value,
                        Id = long.Parse(node.Attribute("id").Value, System.Globalization.NumberStyles.HexNumber),
                        D = node.Attribute("d").Value.Split(',').Select(n => float.Parse(n)).ToArray(),
                        Name = node.Attribute("name")?.Value,
                        Type = node.Attribute("type")?.Value,
                        Bind = node.Attribute("bind")?.Value is string sbind ? long.Parse(sbind) : 0
                    });
                }
                foreach (var sect in xdoc.Root.Element("sections")?.Elements() ?? [])
                {
                    lay.Sections.Add(new ZSection()
                    {
                        Id1 = sect.Attribute("id").Value,
                        Id = long.Parse(sect.Attribute("id").Value, System.Globalization.NumberStyles.HexNumber),
                        Type = (sect.Name.LocalName) switch { "sect" => 0, "arcs" => 1, "pass" => 2, "shaft" => 3, _ => 255 },
                        D = sect.Attribute("d").Value.Split([',']).Select(a => long.Parse(a, System.Globalization.NumberStyles.HexNumber)).ToArray(),
                        Name = sect.Attribute("name")?.Value,
                        Text = sect.Attribute("text")?.Value,
                        Style = sect.Attribute("style")?.Value,
                        Start = sect.Attribute("start")?.Value,
                        Sweep = sect.Attribute("sweep")?.Value,
                    });
                }
                if (split) map.Objects.Add(lay);
            }
        }
        var res = TSerializator.SerializeText(map);
    }

    static string GetLayerName(string code)
    {
        string res = string.Empty;
        bool first = true;
        foreach (var c in code)
        {
            if (!first && c <= 'Я')
                res += " " + c.ToString().ToLower();
            else
                res += c.ToString();

            first = false;
        }
        return res;
    }

    class ZObjects
    {
        public List<object> Objects { get; set; } = [];
    }

}