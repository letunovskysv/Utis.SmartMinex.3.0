//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TelnetSession – Терминальная клиентская сессия Telnet.
//--------------------------------------------------------------------------------------------------
#region Using
using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Utis.SmartMinex.Data;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> [Системный модуль] Терминальная клиентская сессия telnet.</summary>
internal partial class TelnetSession
{
    void DoModuleCommand(StringBuilder output, string input)
    {
        var args = input.SplitArguments();
        if (args.Length > 1 && int.TryParse(args[1], out int nppMod))
            if (args.Length > 2)
            {
                args = args[2..];
                if (args[0] == "?") args[0] = "HELP";

                if (args.Length > 2 && args[1].Trim() == "=" && Regex.IsMatch(args[0], @"[_\w]+"))
                    SetModuleProperty(nppMod, args[0], string.Join(' ', args.Where((p, i) => i > 1).ToArray()));
                else
                    Runtime.Send(MSG.ConsoleCommand, ProcessId, nppMod, args);

                return;
            }
            else
            {
                GetModuleProperties(nppMod);
                return;
            }

        PrintHelp(output, args.FirstOrDefault().ToUpper());
    }

    List<IModule> GetModules() => ((RuntimeService)Runtime).Modules;

    IModule? GetModuleByNumber(int id) =>
        GetModules().FirstOrDefault(m => m.ProcessId == id);

    /// <summary> [who] Получить список модулей.</summary>
    void ShowModules(StringBuilder output, string input)
    {
        using var data = new DataTable();
        data.Columns.AddRange([
                new DataColumn("ИД"),
                new DataColumn("Наименование сервиса"),
                new DataColumn("Статус"),
                new DataColumn("Сообщений"),
                new DataColumn("Время")
            ]);
        var rtm = (RuntimeService)Runtime;
        data.Rows.Add(rtm.Id, rtm.Name, rtm.Status, rtm.MessageCount, rtm.ExecTime);
        GetModules().ForEach(m =>
            data.Rows.Add(
                m.ProcessId,
                m.Name,
                m.Status,
                (m as IDiagnostic)?.MessageCount.ToString() ?? "—",
                (m as IDiagnostic)?.ExecTime ?? "—")
            );

        PrintTable(output, data);
    }

    /// <summary> Получить конфигурацию модуля (процесса). Команда MOD CONFIG.</summary>
    void GetModuleProperties(int id)
    {
        var output = new StringBuilder();
        var mod = GetModuleByNumber(id);
        if (mod != null)
        {
            foreach (var prop in mod.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(m => m.MetadataToken))
            {
                output.Append("  ").Append(prop.Name).Append(" = ");

                var val = prop.GetValue(mod);
                if (prop.Name.Equals("Messages") && val is IEnumerable<int> msgs)
                    output.AppendLine(string.Join(", ", msgs.Select(m => MSG.ToString(m))));
                else if (prop.PropertyType.IsSZArray && val is IEnumerable<int> val32s)
                    output.AppendLine(string.Join(", ", val32s));
                else if (prop.PropertyType.IsSZArray && val is IEnumerable<long> val64s)
                    output.AppendLine(string.Join(", ", val64s));
                else
                    output.AppendLine(val?.ToString() ?? "NULL");
            }
            Print(output.ToString());
        }
        else PrintLine($"Модуль #{id} не найден!");
    }

    /// <summary> Установка свойств модуля.</summary>
    bool SetModuleProperty(int idProcess, string name, string value)
    {
        var mod = GetModuleByNumber(idProcess);
        if (mod != null)
            try
            {
                if (mod.SetProperty(name, value, out string msg))
                {
                    //Runtime.Send(MSG.SecurityLog, SecurityLogTypes.Property, 0x6000000001400,
                    //    new SecurityLogRecord(DateTime.Now, 0x6000000001400, SecurityLogTypes.Property,
                    //    "Модуль «" + mod.Name + "». Свойство " + name + " = " + value));

                    Print(TColor.GOOD("OK"));
                    return true;
                }
                Print(TColor.FAIL(msg));
            }
            catch (Exception ex)
            {
                Print(TColor.FAIL(ex.Message));
                return true;
            }

        else PrintLine(TColor.WARN($"Модуль {idProcess} не найден!"));

        return false;
    }

    /// <summary> Получить сведения о системе СКПТ (объектовый сервер).</summary>
    void ShowSystemInfo(StringBuilder output, string input) => _md?.UseDatabase((fs) =>
    {
        PrintDictionary(output, new Dictionary<string, string>
            {
                { "Номер узла", Runtime.Code },
                { "Имя узла", Runtime.Name },
                //{ "Тип узла", ((DescriptionAttribute)typeof(RUnit).GetFields().FirstOrDefault(f => (int)f.GetValue(null) == Runtime.Level)?.GetCustomAttribute(typeof(DescriptionAttribute))).Description ?? Runtime.Level.ToString() },
                { "Сетевое имя", Security.Cerberus.HostName() },
                { "Сетевой адрес", Security.Cerberus.LocalAddress() },
                { "Версия узла", Runtime.Version },
                { "Версия БД", _md?.Version ?? NULL },
                { "Индекс БД", _md?.Node.Index.ToString() ?? NULL },
                { "Время запуска", Runtime.Started.ToString("dd.MM.yyyy HH:mm:ss") },
                { "Версия ОС", GetOSVersion() },
                { RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "Дистрибутив ОС" : string.Empty, GetDistributorLinux() },
                { "Среда выполнения", RuntimeInformation.FrameworkDescription },
                { "СУБД", fs?.Version ?? NULL},
                { "Подключений БД", fs?.ConnectionCount.ToString() ?? NULL },
                { "Размер БД", fs?.DatabaseSize ?? NULL },
                { "Потоков", ThreadPool.PendingWorkItemCount + " > " + ThreadPool.ThreadCount + " > " + ThreadPool.CompletedWorkItemCount },
                { "Bootstrap", Security.Cerberus.GetBootstrapVersion() ?? NULL}
        }.Where(k => k.Key != string.Empty)
        .ToDictionary(k => k.Key, v => v.Value)
        , ": ");
    });

    static string GetOSVersion() =>
        Environment.OSVersion.VersionString
            + (Marshal.SizeOf(typeof(IntPtr)) == 8 ? " x64 " : " x86 ")
            + Environment.OSVersion.ServicePack;

    static string GetDistributorLinux()
    {
        var res = string.Empty;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            try
            {
                var proc = new Process()
                {
                    StartInfo = new ProcessStartInfo() // lsb_release -a или чтение файла /etc/lsb-release
                    {
                        FileName = "/bin/bash",
                        Arguments = "-c \"lsb_release -a\"",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                res += Regex.Match(proc.StandardOutput.ReadToEnd(), @"(?<=Description\:\s+).*?(?=$|\n)").Value.Trim();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        return res;
    }

    /// <summary> Послать общую команду.</summary>
    void SendCommand(int msg, string input)
    {
        var args = input.SplitArguments();
        if (args.Length == 2 && int.TryParse(args[1], out int idProc))
            Runtime.Send(msg, idProc);
        else
            Runtime.Send(msg, 0, 0, args.Length > 1 ? string.Join(" ", args[1..]) : null);
    }

    /// <summary> Послать команду модулю.</summary>
    void SendCommand(string moduleName, string command, params string[] args)
    {
        var mod = GetModules().FirstOrDefault(p => p.GetType().Name == moduleName);
        if (mod != null)
            mod.SendDirect(new TMessage(MSG.ConsoleCommand, ProcessId, mod.ProcessId, new[] { command }.Concat(args).ToArray()));
    }
}
