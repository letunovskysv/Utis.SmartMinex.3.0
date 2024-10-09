using System.Text.RegularExpressions;
using Utis.SmartMinex.Graphics;

namespace Utis.SmartMinex.Client;

public class GData
{
    public double[] Vertices { get; set; }
    public int[] Indices { get; set; }
    public float[] Colors { get; set; }
    /// <summary> Нормали не принципиальны, поскольку направление света в нашем случае не важно!</summary>
    public double[] Normals { get; set; } = [];
    public GVector3 Camera { get; set; } = new GVector3(26605, 32072, -1300);
    public GVector3 Origin { get; set; }

    public GData(ZScheme model)
    {
        Read(model);
    }

    void Read(ZScheme model)
    {
        var faceStyle = model.Styles[nameof(ZLayer.Sections)] ?? new ZStyle();
        faceStyle.Background ??= "#753b00";
        faceStyle.Width ??= 5;

        var nodes = model.Levels.SelectMany(lev => lev.Layers.SelectMany(lay => lay.Nodes)).ToDictionary(k => k.Id, v => new GNode(v));
        // ...Layers.Where(l => l.Id == 13229461344372736) // -800 horizon
        var faces = model.Levels.SelectMany(lev => lev.Layers.SelectMany(lay => 
            lay.Sections.Where(f => f.Type == 0).Select(f => new GFace(f, nodes, model.Styles, faceStyle)))).ToList();

        var vertices = new List<Double>();
        var colors = new List<float>();
        var indices = new List<Int32>();
        int i = 0;
        faces.ForEach(f =>
        {
            var n1 = f.Node1;
            var n2 = f.Node2;
            vertices.AddRange(GetBoundVertices(n1.X, n1.Y, n1.Z, n2.X, n2.Y, n2.Z, f.Width));
            indices.AddRange(GFace.Indices.Select(j => i + j));
            i += 6;
            for (int j = 0; j < 6; j++)
                colors.AddRange(f.BackColor);
        });

        Vertices = vertices.ToArray();
        Indices = indices.ToArray();
        Colors = colors.ToArray();
        Origin = Mean();
    }

    /// <summary> Расчёт координат границ фигуры секции выработки по узловым точкам (0-1-2-3-4-5) против часовой стрелки.</summary>
    public static double[] GetBoundVertices(double x1, double y1, double z1, double x2, double y2, double z2, double width)
    {
        var len = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
        var dx = width / 2f * (y2 - y1) / len;
        var dy = width / 2f * (x2 - x1) / len;

        var res = new double[18];
        res[0] = x1 - dx;
        res[1] = -dy - y1;
        res[2] = z1;

        res[3] = x1;
        res[4] = -y1;
        res[5] = z1;

        res[6] = x1 + dx;
        res[7] = -y1;
        res[8] = z1;

        res[9] = x2 + dx;
        res[10] = dy - y2;
        res[11] = z2;

        res[12] = x2;
        res[13] = -y2;
        res[14] = z2;

        res[15] = x2 - dx;
        res[16] = -dy - y2;
        res[17] = z2;
        return res;
    }

    /// <summary> Вычисление центра схемы, центра вращения по умолчанию.</summary>
    /// <remarks> Расчитываться должно исходя из центра масс (облака точек).</remarks>
    GVector3 Mean()
    {
        double minx = double.MaxValue, maxx = double.MinValue;
        double miny = double.MaxValue, maxy = double.MinValue;
        double minz = double.MaxValue, maxz = double.MinValue;
        for (int i = 0; i < Vertices.Length; i += 3)
        {
            minx = Math.Min(minx, Vertices[i]);
            maxx = Math.Max(maxx, Vertices[i]);
            miny = Math.Min(miny, Vertices[i + 1]);
            maxy = Math.Max(maxy, Vertices[i + 1]);
            minz = Math.Min(minz, Vertices[i + 2]);
            maxz = Math.Max(maxz, Vertices[i + 2]);
        }
        return new GVector3(minx + (maxx - minx) / 2.0, miny + (maxy - miny) / 2.0, minz + (maxz - minz) / 2.0);
    }
}

public class GNode(ZNode node)
{
    public double X = node.D[0];
    public double Y = node.D[1];
    public double Z = node.D[2];
    public List<GFace> Faces = [];
}

public class GFace
{
    public GNode Node1;
    public GNode Node2;

    public float Width;
    public static int[] Indices = [0, 1, 5, 5, 1, 4, 4, 1, 2, 2, 3, 4];
    public float[] BackColor;

    public GFace(ZSection sect, Dictionary<long, GNode> nodes, ZStyles styles, ZStyle defaultStyle)
    {
        Node1 = nodes[sect.D[0]];
        Node1.Faces.Add(this);
        Node2 = nodes[sect.D[1]];
        Node2.Faces.Add(this);
        BackColor = new GColor4(defaultStyle.Background).ToArray();
        Width = defaultStyle.Width ?? 5;
        if (sect.Style != null && sect.Style.Contains("background:") && int.TryParse(Regex.Match(sect.Style, @"(?<=background\:)\d+").Value, out var n))
        {
            var st = styles[n];
            BackColor = new GColor4(st.Background ?? st.Color).ToArray();
        }
    }
}