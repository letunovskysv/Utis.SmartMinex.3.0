//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: GMeshFactory - Построение различных фигур.
//--------------------------------------------------------------------------------------------------
using System.Numerics;
using Utis.SmartMinex.Client;

namespace Utis.SmartMinex.Graphics;

public class GMeshFactory
{
    #region Declarations

    /// <summary> Количество разбиений окружности на сегменты. Качество отображения.</summary>
    static int _tessellation = 8;
    static float[] _sin; // Кэшируем операции синуса
    static float[] _cos; // Кэшируем операции косинуса

    #endregion Declarations

    #region Properties

    /// <summary> Уровень детализации графики.</summary>
    internal static int Lod
    {
        get { return _tessellation; }
        set
        {
            _tessellation = value;
            _sin = new float[_tessellation];
            _cos = new float[_tessellation];
            var ang = 360.0 * GMath.PIOVER180 / _tessellation;
            for (int i = 0; i < _tessellation; i++)
            {
                var angle = ang * i; // Углы против часовой стрелки -->
                _sin[i] = (float)Math.Sin(angle);
                _cos[i] = (float)Math.Cos(angle);
            }
        }
    }

    #endregion Properties

    static void Init()
    {
        Lod = GLod.Low;
    }

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
    public static void RenderTube(GFace face)
    {
        var i = face.Bounds.Count;
        var wall = new GVector3(0, 0, face.Height - face.Width / 2.0);
        face.Bounds.Add(face.Bounds[5] + wall);
        face.Bounds.Add(face.Bounds[0] + wall);
        face.Bounds.Add(face.Bounds[2] + wall);
        face.Bounds.Add(face.Bounds[3] + wall);
        face.Indices.AddRange([0, 5, i, i, i + 1, 0, 3, 2, i + 2, i + 2, i + 3, 3]);
    }

    /// <summary> Расчёт вершин для окружности в центре (1) и вектором направления (2) с указанным радиусом и количеством сегментов.</summary>
    /// <remarks> Координаты базового радиуса-вектора [1;1;z] - начало построения окружности.</remarks>
    internal static int RenderCircle(GVector3[] result, int index, double cx, double cy, double cz, double nx, double ny, double nz, double radius)
    {
        nx -= cx; ny -= cy; nz -= cz;
        NormVector(ref nx, ref ny, ref nz);
        var r = CalcRadiusVector(cx, cy, cz, nx, ny, nz, radius);
        result[index] = result[index++ + _tessellation] = new GVector3(cx + r.X, cy + r.Y, cz + r.Z);
        for (int i = 1; i < _tessellation; i++)
        {
            double x = r.X, y = r.Y, z = r.Z;
            RotateVertex(ref x, ref y, ref z, nx, ny, nz, _sin[i], _cos[i]);
            result[index++] = new GVector3(cx + x, cy + y, cz + z);
        }
        return _tessellation;
    }

    /// <summary> Расчёт вершин для дуги окружности. Возвращает количество построенных вершин. Углы по часовой стрелки.</summary>
    internal static int RenderArc(GVector3[] result, int index, double cx, double cy, double cz, double nx, double ny, double nz, double radius, double startAngle, double sweepAngle)
    {
        double start, finish, ang;
        startAngle = 360f - startAngle; // Корректировка углов по часовой стрелке, для совместимости с GDI++
        sweepAngle = -sweepAngle;
        if (sweepAngle < 0)
        {
            ang = startAngle % 360f + sweepAngle;
            startAngle = ang > 360f ? ang - 360f : ang < 0 ? 360f + ang : ang;
            sweepAngle = -sweepAngle;
        }
        start = startAngle = (startAngle < 0 ? 360f + startAngle : startAngle);
        finish = startAngle + sweepAngle > 360f ? startAngle + sweepAngle - 360f : startAngle + sweepAngle;
        ang = 360f / _tessellation;
        int ibegin = (int)Math.Floor(start / ang) + 1;
        int iend = (int)Math.Abs(Math.Ceiling(finish / ang)) + (finish < start ? _tessellation : 0) - 1;
        int offset = 0;
        nx -= cx; ny -= cy; nz -= cz;
        NormVector(ref nx, ref ny, ref nz);
        var r = CalcRadiusVector(cx, cy, cz, nx, ny, nz, radius);
        double x = r.X, y = r.Y, z = r.Z;
        RotateVertex(ref x, ref y, ref z, nx, ny, nz, Math.Sin(start * GMath.PIOVER180), Math.Cos(start * GMath.PIOVER180));
        result[index++] = new GVector3(cx + x, cy + y, cz + z);
        for (int i = ibegin; i <= iend; i++)
        {
            if (i == _tessellation) offset = -_tessellation;
            x = r.X; y = r.Y; z = r.Z;
            int j = i + offset;
            RotateVertex(ref x, ref y, ref z, nx, ny, nz, _sin[j], _cos[j]);
            result[index++] = new GVector3(cx + x, cy + y, cz + z);
        }
        x = r.X; y = r.Y; z = r.Z;
        RotateVertex(ref x, ref y, ref z, nx, ny, nz, Math.Sin(finish * GMath.PIOVER180), Math.Cos(finish * GMath.PIOVER180));
        result[index++] = new GVector3(cx + x, cy + y, cz + z);
        return iend - ibegin + 3;
    }

    #region Private methods

    static void NormVector(ref double x, ref double y, ref double z)
    {
        var scale = 1.0 / Math.Sqrt(x * x + y * y + z * z);
        x *= scale;
        y *= scale;
        z *= scale;
    }

    static GVector3 CalcRadiusVector(double cx, double cy, double cz, double nx, double ny, double nz, double radius)
    {
        double rx = 0.0, ry = -1.0, rz = 0.0; // радиус-вектор, начальный угол 0°, даллее против часовой стрелки  -->
        if (nz == 0)
        {
            rx = 1;
            ry = 1;
        }
        var norm = new GVector3(ny * rz - nz * ry, nz * rx - nx * rz, nx * ry - ny * rx);
        var scale = radius / norm.Length;
        rx = norm.X * scale;
        ry = norm.Y * scale;
        rz = norm.Z * scale;
        return new GVector3(norm.X * scale, norm.Y * scale, norm.Z * scale);
    }

    /// <summary> Поворот точки (1) вокруг нормированного вектора (2) на указанный угол.</summary>
    static void RotateVertex(ref double x, ref double y, ref double z, double nx, double ny, double nz, double sin, double cos)
    {
        var mcos = 1.0 - cos;
        var rx = x * (nx * mcos * nx + cos) + y * (ny * mcos * nx - sin * nz) + z * (nz * mcos * nx + sin * ny);
        var ry = x * (nx * mcos * ny + sin * nz) + y * (ny * mcos * ny + cos) + z * (nz * mcos * ny - sin * nx);
        z = x * (nx * mcos * nz - sin * ny) + y * (ny * mcos * nz + sin * nx) + z * (nz * mcos * nz + cos);
        x = rx;
        y = ry;
    }

    #endregion Private methods
}

/// <summary> Уровень детализации графики. Graphic level of details.</summary>
public static class GLod
{
    public const int Low = 24;
    public const int Medium = 48;
    public const int High = 60;
}
