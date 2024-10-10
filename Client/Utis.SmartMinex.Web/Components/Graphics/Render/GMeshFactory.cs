//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: GMeshFactory - Построение различных фигур.
//--------------------------------------------------------------------------------------------------
using Utis.SmartMinex.Client;

namespace Utis.SmartMinex.Graphics;

public class GMeshFactory
{
    /// <summary> Расчёт координат границ фигуры секции выработки по узловым точкам (0-1-2-3-4-5) против часовой стрелки заданной ширины.</summary>
    /// <remarks> Для построения Mesh-фигуры. Полигоны [0-1-5],[5-1-4],[4-1-2],[2-3-4] </remarks>
    public static double[] GetBoundVertices(double x1, double y1, double z1, double x2, double y2, double z2, double width)
    {
        var len = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        var dx = width / 2.0 * (y2 - y1) / len;
        var dy = width / 2.0 * (x2 - x1) / len;

        var res = new double[18];
        res[0] = x1 - dx;
        res[1] = y1 + dy;
        res[2] = z1;

        res[3] = x1;
        res[4] = y1;
        res[5] = z1;

        res[6] = x1 + dx;
        res[7] = y1 - dy;
        res[8] = z1;

        res[9] = x2 + dx;
        res[10] = y2 - dy;
        res[11] = z2;

        res[12] = x2;
        res[13] = y2;
        res[14] = z2;

        res[15] = x2 - dx;
        res[16] = y2 + dy;
        res[17] = z2;
        return res;
    }

    /// <summary> Расчёт координат границ фигуры секции выработки по узловым точкам (0-1-2-3-4-5) против часовой стрелки заданной ширины.</summary>
    /// <remarks> Для построения Mesh-фигуры. Полигоны [0-1-5],[5-1-4],[4-1-2],[2-3-4] </remarks>
    public static List<GVector3> GetBoundVertices2(double x1, double y1, double z1, double x2, double y2, double z2, double width)
    {
        var len = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        var dx = width / 2.0 * (y2 - y1) / len;
        var dy = width / 2.0 * (x2 - x1) / len;

        return [new GVector3(x1 - dx, y1 + dy, z1), new GVector3(x1, y1, z1), new GVector3(x1 + dx, y1 - dy, z1),
            new GVector3(x2 + dx, y2 - dy, z2), new GVector3(x2, y2, z2), new GVector3(x2 - dx, y2 + dy, z2)];
    }

    /// <summary> Построить вершины шахты с полукруглым сводом.</summary>
    public static void BuildTube(GFace face)
    {
        var i = face.Bounds.Count;
        var wall = new GVector3(0, 0, face.Height - face.Width / 2.0);
        face.Bounds.Add(face.Bounds[5] + wall);
        face.Bounds.Add(face.Bounds[0] + wall);
        face.Bounds.Add(face.Bounds[2] + wall);
        face.Bounds.Add(face.Bounds[3] + wall);
        face.Indices.AddRange([0, 5, i, i, i + 1, 0, 3, 2, i + 2, i + 2, i + 3, 3]);
    }
}
