using System;
using System.Drawing;
using Utis.SmartMinex.Graphics;

namespace Utis.SmartMinex.Client;

public class GData
{
    public double[] Vertices { get; set; }
    public int[] Indices { get; set; }
    public double[] Colors { get; set; }
    public double[] Normals { get; set; }
    public GVector3 Camera { get; set; } = new GVector3(26605, 32072, -1300);
    public GVector3 Origin { get; set; }

    public GData(ZScheme model)
    {
        Read(model);
    }

    void Read(ZScheme model)
    {
        var nodes = model.Levels.SelectMany(lev => lev.Layers.SelectMany(lay => lay.Nodes)).ToDictionary(k => k.Id, v => v);
        //var sects = model.Levels.SelectMany(lev => lev.Layers.Where(l => l.Id == 13229461344372736).SelectMany(lay => lay.Sections.Where(s => s.Type == 0))).ToList(); // 13229461344372736 -800 horizon
        var sects = model.Levels.SelectMany(lev => lev.Layers.SelectMany(lay => lay.Sections.Where(s => s.Type == 0))).ToList(); // 13229461344372736 -800 horizon

        var vertices = new List<Double>();
        var colors = new List<Double>();
        var indices = new List<Int32>();
        int idx = 0;
        sects.ForEach(s =>
        {
            var p1 = nodes[s.D[0]];
            var p2 = nodes[s.D[1]];
            vertices.AddRange(GetBoundVertices(p1.D[0], p1.D[1], p1.D[2], p2.D[0], p2.D[1], p2.D[2], 10));
            indices.AddRange([idx, idx + 1, idx + 3, idx + 3, idx + 1, idx + 2]);
            idx += 4;
            colors.AddRange([1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1]);
        });

        Vertices = GetBoundVertices(26605.5, 32052.52, -800, 26674.898, 32052.52, -850, 10);
        Indices = [0, 1, 3, 3, 1, 2];
        Colors = [1, 0.5, 0, 1, 1, 0.5, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1];
        Normals = [];

        Vertices = vertices.ToArray();
        Indices = indices.ToArray();
        Colors = colors.ToArray();

        Origin = Mean();
    }

    /// <summary> Расчёт координат границ фигуры секции выработки по узловым точкам (0-1-2-3-4-5) против часовой стрелки. Осевые пропускаем.</summary>
    public static double[] GetBoundVertices(double x1, double y1, double z1, double x2, double y2, double z2, double width)
    {
        var len = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
        var dx = width / 2f * (y2 - y1) / len;
        var dy = width / 2f * (x2 - x1) / len;

        var res = new double[12];
        res[0] = x1 - dx;
        res[1] = -dy - y1;
        res[2] = z1;

        //res[3] = x1;
        //res[4] = -y1;
        //res[5] = z1;

        res[3] = x1 + dx;
        res[4] = -y1;
        res[5] = z1;

        res[6] = x2 + dx;
        res[7] = dy - y2;
        res[8] = z2;

        //res[9] = x2;
        //res[10] = -y2;
        //res[11] = z2;

        res[9] = x2 - dx;
        res[10] = -dy - y2;
        res[11] = z2;
        return res;
    }

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

public struct GVector3(double x, double y, double z)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;
}
