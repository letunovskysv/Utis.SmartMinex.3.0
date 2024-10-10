using System.Diagnostics;
using System.Text.RegularExpressions;
using Utis.SmartMinex.Graphics;

namespace Utis.SmartMinex.Client;

public class GData
{
    const double SHARPANGLE = Math.PI / 2.1;

    public double[] Vertices { get; set; }
    public int[] Indices { get; set; }
    public float[] Colors { get; set; }
    /// <summary> Нормали не принципиальны, поскольку направление света в нашем случае не важно!</summary>
    public float[] Normals { get; set; } = [];
    public GVector3 Camera { get; set; } = new GVector3(26605, 32072, -1300);
    public GVector3 Origin { get; set; }

    public GData(ZScheme model)
    {
        Render(model);
    }

    void Render(ZScheme model)
    {
        var faceStyle = model.Styles[nameof(ZLayer.Sections)] ?? new ZStyle();
        faceStyle.Background ??= "#753b00";
        faceStyle.Width ??= 5;
        faceStyle.Height ??= faceStyle.Width;

        var nodes = model.Levels.SelectMany(lev => lev.Layers.SelectMany(lay => lay.Nodes)).ToDictionary(k => k.Id, v => new GNode(v));
        // ...Layers.Where(l => l.Id == 13229461344372736) // -800 horizon
        var faces = model.Levels.SelectMany(lev => lev.Layers.SelectMany(lay => 
            lay.Sections.Where(f => f.Type == 0).Select(f => new GFace(f, nodes, model.Styles, faceStyle)))).ToList();

        foreach (var node in nodes.Values)
            RenderNode(node);

        foreach (var face in faces)
            GMeshFactory.RenderTube(face);

        var vertices = new List<Double>();
        var normals = new List<float>();
        var colors = new List<float>();
        var indices = new List<Int32>();
        int i = 0;
        faces.ForEach(f =>
        {
            var n = f.Bounds.Count;
            vertices.AddRange(f.Vertices);
            indices.AddRange(f.Indices.Select(j => i + j));
            i += n;
            for (int j = 0; j < n; j++)
            {
                normals.AddRange([0, 0, 1]);
                colors.AddRange(f.BackColor);
            }
        });

        Vertices = vertices.ToArray();
        Normals = normals.ToArray();
        Indices = indices.ToArray();
        Colors = colors.ToArray();
        Origin = Mean();
    }

    /// <summary> Расчёт вершин для всех сегментов входящих в состав узла. Построение поверхностей.</summary>
    static void RenderNode(GNode node)
    {
        if (node.Faces.Count > 0)
        {
            var p0 = node.Point; // Выстроим отрезки по порядку против часовой стрелки -->
            var faces = node.Faces.OrderBy(f => GMath.AngleFloor(p0, f.Node1 == node ? f.Node2.Point : f.Node1.Point)).Select(f =>
            {
                if (f.Bounds.Count == 0)
                {
                    var n1 = f.Node1;
                    var n2 = f.Node2;
                    f.Bounds = GMeshFactory.GetBoundVertices2(n1.X, n1.Y, n1.Z, n2.X, n2.Y, n2.Z, f.Width);
                }

                return f;
            }).ToArray();

            if (faces.Length > 1) // построим перекрёсток -->
            {
                int i11, i12, i21, i22;
                var cnt = faces.Length;
                var face = faces[cnt - 1];
                for (var i = 0; i < cnt; i++)
                {
                    var prev = face;
                    face = faces[i];

                    if (face.Node1 == node)
                    {
                        i11 = 2;
                        i12 = 3;
                    }
                    else
                    {
                        i11 = 5;
                        i12 = 0;
                    }
                    if (prev.Node1 == node)
                    {
                        i21 = 0;
                        i22 = 5;
                    }
                    else
                    {
                        i21 = 3;
                        i22 = 2;
                    }
                    var inter = GMath.Intersection(face.Bounds[i11], face.Bounds[i12], prev.Bounds[i21], prev.Bounds[i22]);
                    if (GMath.Angle(inter, face.Bounds[i12], prev.Bounds[i22]) < SHARPANGLE
                        && !GMath.IsPointBelongsLine(face.Bounds[i11], face.Bounds[i12], inter)) // Срежем острый угол -->
                    {
                        face.Indices.AddRange([face.Node1 == node ? 1 : 4, i11, face.Bounds.Count]);
                        face.Bounds.Add(prev.Bounds[i21]);
                    }
                    else face.Bounds[i11] = prev.Bounds[i21] = inter;

                    if (i > 0 && prev.Node1.Z != prev.Node2.Z)
                        RenderIntersection(prev, node);
                }
                if (face.Node1.Z != face.Node2.Z)
                    RenderIntersection(face, node);
            }
        }
    }

    static void RenderIntersection(GFace face, GNode node)
    {
        if (face.Node1 == node)
        {
            face.Indices.AddRange([0, 2, face.Bounds.Count]);
            face.Bounds.Add(face.Bounds[1]);
            face.Bounds[1] = GMath.MiddlePoint(face.Bounds[0], face.Bounds[2]);
        }
        else
        {
            face.Indices.AddRange([5, 3, face.Bounds.Count]);
            face.Bounds.Add(face.Bounds[4]);
            face.Bounds[4] = GMath.MiddlePoint(face.Bounds[3], face.Bounds[5]);
        }
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

[DebuggerDisplay("{Name} {X}, {Y}, {Z}")]
public class GNode(ZNode node)
{
    public string Name = node.Name;
    public double X = node.D[0];
    public double Y = node.D[1];
    public double Z = node.D[2];
    public GVector3 Point => new(X, Y, Z);
    public List<GFace> Faces = [];
}

[DebuggerDisplay("{Node1} - {Node2}")]
public class GFace
{
    public GNode Node1;
    public GNode Node2;
    public float Width;
    public float Height;

    public List<GVector3> Bounds = [];
    /// <summary> Возвращает массив вершин для OpenGL.</summary>
    public double[] Vertices => Bounds.SelectMany(p => p.ToArray()).ToArray();
    public List<int> Indices = [1, 0, 5, 5, 4, 1, 2, 1, 4, 2, 4, 3];
    public float[] BackColor;

    public GFace(ZSection sect, Dictionary<long, GNode> nodes, ZStyles styles, ZStyle defaultStyle)
    {
        Node1 = nodes[sect.D[0]];
        Node1.Faces.Add(this);
        Node2 = nodes[sect.D[1]];
        Node2.Faces.Add(this);
        BackColor = new GColor4(defaultStyle.Background).ToArray();
        Width = defaultStyle.Width ?? 5;
        Height = defaultStyle.Height ?? Width;
        if (sect.Style != null && sect.Style.Contains("background:") && int.TryParse(Regex.Match(sect.Style, @"(?<=background\:)\d+").Value, out var n))
        {
            var st = styles[n];
            BackColor = new GColor4(st.Background ?? st.Color).ToArray();
        }
    }
}