//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TPath – Path.GetDirectoryName в Linux, работает некорректно.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Runtime;

public static class TPath
{
    /// <summary> Path.GetDirectoryName в Linux, работает некорректно.</summary>
    public static string? GetDirectoryName(string? path) =>
        path == null ? string.Empty : string.Join(OperatingSystem.IsLinux() ? "/" : "\\", path.Split(['\\', '/'])[0..^1]);

    /// <summary> Directory.GetCurrentDirectory() в Linux, работает некорректно.</summary>
    public static string? GetCurrentDirectory() =>
        GetDirectoryName(Environment.CommandLine);

    /// <summary> Path.GetFileName() в Linux, работает некорректно.</summary>
    public static string? GetFileName(string? path) =>
        path == null ? string.Empty : path[(path.LastIndexOf(OperatingSystem.IsLinux() ? "/" : "\\") + 1)..];

    public static string Combine(params string[] path)
    {
        ArgumentNullException.ThrowIfNull(path);
        return string.Join(Path.DirectorySeparatorChar, path.Select(p => p.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar)));
    }
}
