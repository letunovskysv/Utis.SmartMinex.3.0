//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: SystemFunction – Зависимые от операционной системы функции.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Management;
#endregion Using

namespace Utis.SmartMinex.Windows.Shell;

/// <summary> Зависимые от операционной системы функции.</summary>
public static class SystemFunction
{
    /// <summary> Получить командную строку запуска исполняемого файла.</summary>
    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    public static string GetCommandLine(this Process process)
    {
        var searcher = new ManagementObjectSearcher($"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}");
        var collection = searcher.Get().GetEnumerator();
        if (collection.MoveNext())
            return collection.Current["CommandLine"]?.ToString();

        return null;
    }

    /// <summary> Получить температуру процессора.</summary>
    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    public static float? GetCPUTemperature()
    {
        var searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
        var collection = searcher.Get().GetEnumerator();
        if (collection.MoveNext())
        {
            //var instanceName = collection.Current["InstanceName"].ToString();
            return (float)((Convert.ToDouble(collection.Current["CurrentTemperature"].ToString()) - 2732) / 10.0);
        }
        return null;
    }
}
