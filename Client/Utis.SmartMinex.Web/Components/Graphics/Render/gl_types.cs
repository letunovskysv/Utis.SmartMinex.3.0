//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: Различные типы WebGL 2.0 - API построена на основе OpenGL ES 3.0, для шейдеров
//           поддерживается язык GLSL ES версии 1.00 и 3.00.
//--------------------------------------------------------------------------------------------------
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Utis.SmartMinex.Graphics;

[DebuggerDisplay("{X}, {Y}, {Z}")]
public struct GVector3(double x, double y, double z)
{
    public static GVector3 Zero => new(0, 0, 0);

    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;
    public readonly double[] ToArray() => [X, Y, Z];

    public readonly double Length => GMath.Distance(Zero, this);

    #region Operations

    public static GVector3 operator *(GVector3 left, float right) =>
        new(left.X * right, left.Y * right, left.Z * right);

    public static GVector3 operator /(GVector3 left, float right) =>
        new(left.X / right, left.Y / right, left.Z / right);

    public static GVector3 operator +(GVector3 left, GVector3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static GVector3 operator -(GVector3 left, GVector3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static bool operator ==(GVector3 left, GVector3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(GVector3 left, GVector3 right) =>
        left.X != right.X || left.Y != right.Y || left.Z != right.Z;

    public static bool operator >(GVector3 left, GVector3 right) =>
        left.X > right.X || left.X > right.Y || left.Z > right.Z;

    public static bool operator <(GVector3 left, GVector3 right) =>
        left.X < right.X || left.X < right.Y || left.Z < right.Z;

    #endregion Operations
}

public struct GColor4
{
    public float R { get; set; }
    public float G { get; set; }
    public float B { get; set; }
    public float A { get; set; }
    public readonly float[] ToArray() => [R, G, B, A];

    public GColor4(int r, int g, int b, int a)
    {
        R = r / 255f;
        G = g / 255f;
        B = b / 255f;
        A = a / 255f;
    }

    public GColor4(string name)
    {
        if (name != null && name.StartsWith('#'))
        {
            var rgba = Regex.Matches(name[1..], @"[ABCDEFabcdef\d]{2}").Cast<Match>()
                .Select(m => int.Parse(m.Value, System.Globalization.NumberStyles.HexNumber)).ToArray();

            if (rgba.Length == 3)
            {
                R = rgba[0] / 255f;
                G = rgba[1] / 255f;
                B = rgba[2] / 255f;
                A = 1f;
            }
            else if (rgba.Length == 4)
            {
                R = rgba[1] / 255f;
                G = rgba[2] / 255f;
                B = rgba[3] / 255f;
                A = rgba[0] / 255f;
            }
        }
    }
}