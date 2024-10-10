//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Различные математические операции и преобразования. Линейная алгебра.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Graphics;

public class GMath
{
    const double PI2 = Math.PI * 2.0;
    const double PI180 = Math.PI * 180.0;

    public static double Round(float value) =>
        Math.Round(value, 2);

    public static double Round(double value) =>
        Math.Round(value, 2);

    /// <summary> Возвращает угол между точками на плоскости Z в радианах против часовой стрелке.</summary>
    public static double AngleFloor(GVector3 start, GVector3 finish)
    {
        var point = finish - start;
        var res = Math.Atan2(point.Y, point.X);
        return res < 0 ? PI2 + res : res;
    }

    /// <summary> Возвращает угол между прямыми в пространстве в градусах.</summary>
    public static double Angle(double x, double y, double z, double x1, double y1, double z1, double x2, double y2, double z2)
    {
        x1 -= x; y1 -= y; z1 -= z;
        x2 -= x; y2 -= y; z2 -= z;
        var rad = Math.Acos((x1 * x2 + y1 * y2 + z1 * z2) / (Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1) * Math.Sqrt(x2 * x2 + y2 * y2 + z2 * z2)));
        var degree = rad * 180.0 / Math.PI;
        return degree == -180.0 ? 180.0 : degree < 0.0 ? 360.0 + degree : degree;
    }

    /// <summary> Возвращает угол между прямыми в пространстве в градусах.</summary>
    public static double Angle(GVector3 p0, GVector3 p1, GVector3 p2)
    {
        p1.X -= p0.X; p1.Y -= p0.Y; p1.Z -= p0.Z;
        p2.X -= p0.X; p2.Y -= p0.Y; p2.Z -= p0.Z;
        var rad = Math.Acos((p1.X * p2.X + p1.Y * p2.Y + p1.Z * p2.Z) / (Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y + p1.Z * p1.Z) * Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y + p2.Z * p2.Z)));
        var degree = rad * 180.0 / Math.PI;
        return degree == -180.0 ? 180.0 : degree < 0.0 ? 360.0 + degree : degree;
    }

    /// <summary> Проекция точки на прямую 3D.</summary>
    public static GVector3 Ortho(GVector3 p1, GVector3 p2, GVector3 point)
    {
        double k;
        var a = Math.Sqrt(Math.Pow(p1.X - point.X, 2) + Math.Pow(p1.Y - point.Y, 2));
        var b = Math.Sqrt(Math.Pow(p2.X - point.X, 2) + Math.Pow(p2.Y - point.Y, 2));
        var c = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        var p = (a + b + c) / 2;
        var h = 2 * Math.Sqrt(p * (p - a) * (p - b) * (p - c)) / c;
        if (double.IsNaN(h)) h = 0;
        if (a > b)
        {
            k = Math.Sqrt(a * a - h * h) / c;
            return new GVector3(p1.X + k * (p2.X - p1.X), p1.Y + k * (p2.Y - p1.Y), p1.Z + k * (p2.Z - p1.Z));
        }
        k = Math.Sqrt(b * b - h * h) / c;
        return new(p2.X + k * (p1.X - p2.X), p2.Y + k * (p1.Y - p2.Y), p2.Z + k * (p1.Z - p2.Z));
    }

    /// <summary> Возвращает расстояние между точками.</summary>
    public static double Distance(GVector3 p1, GVector3 p2) =>
        Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2) + Math.Pow(p2.Z - p1.Z, 2));

    /// <summary> Возвращает расстояние между точками.</summary>
    public static double Distance(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        x1 = x2 - x1;
        y1 = y2 - y1;
        z1 = z2 - z1;
        return Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1);
    }

    /// <summary> Возвращает расстояние между точкой и линией (перпендикуляр).</summary>
    public static double Distance(GVector3 p1, GVector3 p2, GVector3 point)
    {
        var p = Ortho(p1, p2, point);
        if (IsPointBelongsLine(p1, p2, p))
            return Distance(p, point);

        return double.MaxValue;
    }

    /// <summary> Возвращает середину отрезка.</summary>
    public static GVector3 MiddlePoint(GVector3 p1, GVector3 p2) =>
        new((p1.X + p2.X) / 2.0, (p1.Y + p2.Y) / 2.0, (p1.Z + p2.Z) / 2.0);

    /// <summary> Проверка нахождения точки на отрезке.</summary>
    public static bool IsPointBelongsLine(GVector3 p1, GVector3 p2, GVector3 p) =>
        Math.Abs(Distance(p1, p) + Distance(p2, p) - Distance(p1, p2)) < 0.005;

    /// <summary> Проверка нахождения точки на отрезке с указанием коэффициента отклонения от осевой.</summary>
    public static bool IsPointBelongsLine(GVector3 p1, GVector3 p2, GVector3 p, double variance) =>
        Math.Abs(Distance(p1, p) + Distance(p2, p) - Distance(p1, p2)) < variance;

    /// <summary> Приращение угла в градусах.</summary>
    public static double DegressAdd(double degress, double delta)
    {
        var res = degress % 360.0 + delta;
        return res > 180.0 ? res - 360.0 : res < -180.0 ? res + 360.0 : res;
    }

    public static double Rad(double degress) =>
        degress * PI180;

    /// <summary> Поворачивает точку вокруг начала координат на угол (радиан) против часовой стрелке </summary>
    public static void Rotate(ref double x, ref double y, double angle)
    {
        var dx = x;
        var cos = Math.Cos(angle);
        var sin = Math.Sin(angle);
        x = Round(dx * cos - y * sin);
        y = Round(dx * sin + y * cos);
    }

    /// <summary> Поворачивает точку вокруг начала координат на угол (радиан) против часовой стрелке на плоскости Z.</summary>
    public static GVector3 Rotate(GVector3 point, double angle)
    {
        var cos = Math.Cos(angle);
        var sin = Math.Sin(angle);
        return new(Round(point.X * cos - point.Y * sin), Round(point.X * sin + point.Y * cos), point.Z);
    }

    /// <summary> Проверка пересечения двух отрезков прямых на плоскости.</summary>
    public static bool IsIntersection(double x11, double y11, double x12, double y12, double x21, double y21, double x22, double y22)
    {
        var dx1 = x12 - x11;
        var dy1 = y12 - y11;
        var dx2 = x22 - x21;
        var dy2 = y22 - y21;
        // считаем уравнения прямых проходящих через отрезки -->
        var a1 = -dy1;
        var b1 = dx1;
        var c1 = -(a1 * x11 + b1 * y11);
        var a2 = -dy2;
        var b2 = dx2;
        var c2 = -(a2 * x21 + b2 * y21);
        // подставляем концы отрезков, для выяснения в каких полуплоскостях они лежат -->
        var seg1_line2_start = a2 * x11 + b2 * y11 + c2;
        var seg1_line2_end = a2 * x12 + b2 * y12 + c2;
        var seg2_line1_start = a1 * x21 + b1 * y21 + c1;
        var seg2_line1_end = a1 * x22 + b1 * y22 + c1;
        // если концы одного отрезка имеют один знак, значит он в одной полуплоскости и пересечения нет -->
        return !(seg1_line2_start * seg1_line2_end >= 0 || seg2_line1_start * seg2_line1_end >= 0);
    }

    /// <summary> Пересечение бесконечных линий.</summary>
    public static GVector3 Intersection(GVector3 p1, GVector3 p2, GVector3 p3, GVector3 p4)
    {
        double dx1 = p2.X - p1.X, dy1 = p2.Y - p1.Y, dz1 = p2.Z - p1.Z;
        double dx2 = p4.X - p3.X, dy2 = p4.Y - p3.Y, dz2 = p4.Z - p3.Z;
        if (dy1 * dx2 - dy2 * dx1 == 0) return p1;
        var x = (p1.X * dy1 * dx2 - p3.X * dy2 * dx1 - p1.Y * dx1 * dx2 + p3.Y * dx1 * dx2) / (dy1 * dx2 - dy2 * dx1);
        var y = (p1.Y * dx1 * dy2 - p3.Y * dx2 * dy1 - p1.X * dy1 * dy2 + p3.X * dy1 * dy2) / (dx1 * dy2 - dx2 * dy1);
        var z = dy1 * dz2 - dy2 * dz1 == 0 ? p1.Z : (p1.Z * dy1 * dz2 - p3.Z * dy2 * dz1 - p1.Y * dz1 * dz2 + p3.Y * dz1 * dz2) / (dy1 * dz2 - dy2 * dz1);
        return new(x, y, z);
    }

    /// <summary> Возвращает координаты точки на отрезке на расстоянии N от начала отрезка. Линейная интерполяция/экстраполяция.</summary>
    public static GVector3 PointOnLine(double x1, double y1, double z1, double x2, double y2, double z2, double distance)
    {
        var len = Distance(x1, y1, z1, x2, y2, z2);
        return new(Round(distance * (x2 - x1) / len), Round(distance * (y2 - y1) / len), Round(distance * (z2 - z1) / len));
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
}
