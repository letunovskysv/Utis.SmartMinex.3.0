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
        var sects = model.Levels.SelectMany(lev => lev.Layers.SelectMany(lay => lay.Sections)).ToList(); // 13229461344372736 -800 horizon

        Vertices = GetBoundVertices(26605.5, 32052.52, -800, 26674.898, 32052.52, -850, 10);
        Vertices = [26585, 32052, -850, 26605, 32052, -850, 26625, 32092, -850, 26585, 32092, -850];
        Indices = [0, 1, 3, 3, 1, 2];
        Colors = [1, 0.5, 0, 1, 1, 0.5, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1];
        Normals = [];

        Origin = Mean();
    }

    /// <summary> Расчёт координат границ фигуры секции выработки по узловым точкам (0-1-2-3-4-5) против часовой стрелки.</summary>
    public static double[] GetBoundVertices(double x1, double y1, double z1, double x2, double y2, double z2, double width)
    {
        var len = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));

        var res = new double[12];
        res[0] = x1 - width;
        res[1] = y1;
        res[2] = z1;

        res[3] = x1 + width;
        res[4] = y1;
        res[5] = z1;

        res[6] = x2 + width;
        res[7] = y2;
        res[8] = z2;

        res[9] = x2 - width;
        res[10] = y2;
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

    /// <summary> Расчёт координат границ фигуры секции выработки по узловым точкам (0-1-2-3-4-5) против часовой стрелки.</summary>
    /*public static PointF[] GetBoundPoints(PointF p1, PointF p2, float width)
    {
        PointF[] bounds = new PointF[6];
        float len = (float)Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        float dx = width / 2f * (p2.Y - p1.Y) / len;
        float dy = width / 2f * (p2.X - p1.X) / len;
        bounds[0].X = p1.X - dx; bounds[0].Y = -dy - p1.Y;
        bounds[1].X = p1.X; bounds[1].Y = -p1.Y;
        bounds[2].X = p1.X + dx; bounds[2].Y = dy - p1.Y;
        bounds[3].X = p2.X + dx; bounds[3].Y = dy - p2.Y;
        bounds[4].X = p2.X; bounds[4].Y = -p2.Y;
        bounds[5].X = p2.X - dx; bounds[5].Y = -dy - p2.Y;
        return bounds;
    }*/
}

public struct GVector3(double x, double y, double z)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;
}
