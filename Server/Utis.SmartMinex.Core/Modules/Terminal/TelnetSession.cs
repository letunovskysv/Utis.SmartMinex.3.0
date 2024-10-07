//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TelnetSession – Терминальная клиентская сессия Telnet.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Utis.SmartMinex.Data;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> [Системный модуль] Терминальная клиентская сессия telnet.</summary>
internal sealed partial class TelnetSession : SmartModule
{
    #region Declarations

    const string LOGO = @"АРМ «Горный диспетчер»";

    const string LOOPMODE = "*";
    const string NULL = "-";

    const string USER_PROMPT = "USER> ";
    const string PASS_PROMPT = "PASS> ";
    const string BREAK = "BREAK";
    const string EXIT = "EXIT";
    const string NEWLINE = "\r\n";

    const string BEGIN_STR = "\x1b[G";

    static int _count = 1;

    readonly Socket _sock;
    readonly string? _usrDefault;
    readonly string? _pwdDefault;
    string _username;
    bool _trace;
    bool _msg_enabled = true;
    int _pass_attempt = 3;
    bool _urpt_visible = false;
    long _proccessHolder;

    readonly IMetadata? _md;
    readonly TelnetChannel _channel = new();

    /// <summary> Секундомер прохождения сообщения.</summary>
    Stopwatch _swtest;

    /// <summary> Заполняется при запросе конфигурации, настроек или параметров.</summary>
    object _devobj;
    /// <summary> Флаги изменённыйх секций.</summary>
    int _modified;
    /// <summary> Заполняется при запросе конфигурации, настроек или параметров.</summary>
    Dictionary<int, KeyValuePair<object, MemberInfo>> _prmsets;

    /// <summary> История команд. Последняя команда.</summary>
    Action<StringBuilder, object[]> _repeat;
    object[] _repeat_args;
    int _repeat_cnt;
    readonly string _repeat_progress = "–\\|/";

    StringBuilder _script;
    string _script_delim;

    readonly List<CancellationTokenSource> _cancellationTokenSources = new();
    readonly LinkedList<string> _history = new();
    readonly Dictionary<string, Action<StringBuilder, string>> _handlers;

    #endregion Declarations

    #region State

    enum SessionState
    {
        Initial,
        Password,
        Running,
        Script
    }

    SessionState _state;
    SessionState State
    {
        get => _state;
        set
        {
            //if(value == SessionState.Password)
            //  Print("\x1b[D*");

            _state = value;
            _channel.IsEchoSuppressed = _state == SessionState.Password;
        }
    }

    #endregion State

    #region Properties

    #endregion Properties

    #region Constructor

    public TelnetSession(IRuntime runtime, IMetadata? metadata, Socket client, string? username, string? password) : base(runtime)
    {
        Messages = [MSG.InformMessage, MSG.WarningMessage, MSG.ErrorMessage, MSG.CriticalMessage, MSG.Test];
        Name = string.Concat("Терминальная сессия #", ++_count, " ", (client.RemoteEndPoint as IPEndPoint)?.Address);
        ForcedLoop = true;
        _md = metadata;
        _usrDefault = username;
        _pwdDefault = password;

        _sock = client;

        _channel.Send = buffer => _sock?.Send(buffer);
        _channel.ExecuteCommand = ExecuteCommand;
        _channel.BreakExecution = () => ExecuteCommand(BREAK);
        _channel.CloseRequested = () => ExecuteCommand(EXIT);

        _channel.RequestHistory = () => new LinkedList<string>(_history);

        _channel.ConsoleEncoding = Encoding.UTF8;

        _handlers = new()
            {
                { "?", (o, e) => PrintHelp(o) },
                { "HELP", (o, e) => PrintHelp(o) },
                { "WHO", ShowModules },
                { "START", (o, e) => SendCommand(MSG.Start, e) },
                { "STOP", (o, e) => SendCommand(MSG.Stop, e) },
                { "KILL", (o, e) => SendCommand(MSG.Kill, e) },
                { "INSTALL", (o, e) => SendCommand(MSG.InstallModule, e) },
                { "UNINSTALL", (o, e) => SendCommand(MSG.UninstallModule, e) },
                { "#", DoModuleCommand },
                { "MOD", DoModuleCommand },
                { "SYSTEMINFO", ShowSystemInfo },
                { "RESTART", (o, e) => Runtime.Send(MSG.RestartAppServer, Id) },
                { "MSGOFF", (o, e) => MessageEnabled(false) },  // Запрет вывода сообщений
                { "MSGON", (o, e) => MessageEnabled(true) },  // Разрешение вывода сообщений
                { "EXIT", (o, e) => Stop() },
                { "QUIT", (o, e) => Stop() },
                { "TEST", (o, e) => Test(e) }
            };
    }

    #endregion Constructor

    public override bool OnStart()
    {
        _channel.Connected();
        PrintLine(LOGO);
        Print(USER_PROMPT);
        return true;
    }

    public override async Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        try
        {
            if (_sock.Poll(1, SelectMode.SelectRead) && _sock.Available == 0)
            {
                Stop();
                return;
            }
            var input = Receive();
            if (input.Length > 0)
            {
                _channel.Received(input);
            }
            if (State == SessionState.Running)
                switch (m.Msg)
                {
                    case MSG.Terminal:
                        if ((_proccessHolder == 0 || _proccessHolder == m.LParam) && m.HParam == 0 || m.HParam == ProcessId)
                        {
                            if (m.Data is string line)
                                Print(line.StartsWith('~') ? line[1..] : line + Environment.NewLine);

                            else if (m.Data is int mode)
                                _proccessHolder = mode switch { TColor.HOLD => m.LParam, TColor.FREE => 0, _ => _proccessHolder };

                            else if (m.Data is DataTable tbl)
                                Print(tbl);
                        }
                        break;

                    case MSG.InformMessage:
                        if (_msg_enabled)
                            Print($"\x1b[Dinfo: {m.Data}\r\n\r\n>");
                        break;
                    case MSG.WarningMessage:
                        if (_msg_enabled)
                            Print($"{TColor.YELLOW}\x1b[Dwarn: {GetProcessName(m.LParam)}{m.Data}{TColor.DEFAULT}\r\n\r\n>");
                        break;
                    case MSG.ErrorMessage:
                        if (_msg_enabled)
                            Print($"{TColor.RED}\x1b[Dfail: {GetProcessName(m.LParam)}{m.Data}{TColor.DEFAULT}\r\n\r\n>");
                        break;
                    case MSG.CriticalMessage:
                        if (_msg_enabled)
                            Print($"{TColor.RED}\x1b[Dcrit: {GetProcessName(m.LParam)}{m.Data}{TColor.DEFAULT}\r\n\r\n>");
                        break;

                    case MSG.Test:
                        if ( m.LParam == 0)
                        {
                            _swtest.Stop();
                            Print($"Время прохождение сообщения: {_swtest.ElapsedMilliseconds} мс\r\n");
                        }
                        break;
                }
        }
        catch (Exception ex)
        {
            PrintLine("ERROR: " + ex.Message + "\r\n" + ex.StackTrace);
        }
        await Task.CompletedTask;
    }

    public override void OnStop()
    {
        Runtime.Send(MSG.Cancel, 0, ProcessId);
        if (_sock.Connected)
        {
            _sock.Shutdown(SocketShutdown.Both);
            _sock.Disconnect(false);
        }
        _sock.Close(0);
        _sock.Dispose();
    }

    #region Private methods

    byte[] Receive()
    {
        if (_sock.Available == 0) return [];

        var buf = new byte[512];
        int cnt;
        while ((cnt = _sock.Receive(buf, buf.Length, SocketFlags.None)) > 0)
            if (_sock.Available == 0) break;

        if (cnt == 0) return [];

        var res = new byte[cnt];
        Array.Copy(buf, res, cnt);
        return res;
    }

    #region Looped...

    void RunLoop(Action<StringBuilder, object[]> foutput, params object[] args)
    {
        _repeat_args = args;
        _repeat = foutput;
        _repeat_cnt = 0;
        RepeatCommand();
    }

    void RepeatCommand()
    {
        StringBuilder output = new(TColor.STARTLINE);

        output.Append(_repeat_progress[_repeat_cnt++ % 4].ToString());
        _repeat(output, _repeat_args);

        output.Append(BEGIN_STR);
        Print(output.ToString());
    }
    #endregion Looped

    void ExecuteCommand(string line)
    {
        var input = line.Trim();
        var output = new StringBuilder();
        var prompt = NEWLINE;
        var args = input.SplitArguments();
        var cmd = args.FirstOrDefault()?.ToUpper();
        bool isloop = false;
        bool handled = true;

        switch (State)
        {
            case SessionState.Initial:
                if (!string.IsNullOrWhiteSpace(input))
                {
                    _username = input;
                    prompt = PASS_PROMPT;
                    State = SessionState.Password;
                }
                else prompt = USER_PROMPT;
                break;

            case SessionState.Password:
                var authenticated = _usrDefault == null ? true
                    : _username.Equals(_usrDefault, StringComparison.OrdinalIgnoreCase) && (string.IsNullOrWhiteSpace(_pwdDefault) || _pwdDefault.Equals(input));

                //#if !DEBUG
                //                    try
                //                    {
                //                        authenticated = Runtime.Authentificate(_username, input, out TUserRow _);
                //                    }
                //                    catch (Exception ex)
                //                    {
                //                        Runtime.Send(MSG.ErrorMessage, 0, 0, ex);
                //                    }
                //#else
                //                    authenticated = true;
                //#endif

                if (!authenticated)
                {
                    if (--_pass_attempt == 0)
                        Stop();

                    prompt = "Не верное имя пользователя или пароль!\r\n" + PASS_PROMPT;
                }
                else
                {
                    State = SessionState.Running;
                    output.Append(Runtime.Code + " OK");
                }
                break;

            case SessionState.Script:
                if (input == _script_delim)
                    _state = SessionState.Running;
                else
                    _script.AppendLine(line);

                prompt = string.Empty;
                break;

            default:
                StoreHistoryCommand(input);

                if (_handlers.TryGetValue(cmd, out Action<StringBuilder, string>? act))
                    try
                    {
                        act.Invoke(output, input);
                    }
                    catch (Exception ex)
                    {
                        Print(TColor.FAIL("Ошибка выполнения команды: " + ex.Message));
                    }
                else
                    switch (cmd)
                    {
                        case "STAT":
                            if (args.Length == 2 && int.TryParse(args[1], out int idProc) && GetModuleByNumber(idProc) is IDiagnostic proc)
                                proc.Statistics(output);
                            else
                                PrintHelp(output, cmd);

                            break;

                        case "URPT": // Показать/скрыть входящие данные от УРПТ -->
                            if (args.Length > 1)
                                if (args[1].ToUpper() == "SHOW")
                                {
                                    _urpt_visible = true;
                                    output.Append("Показывать входящие данные от УРПТ.");
                                }
                                else if (args[1].ToUpper() == "HIDE")
                                {
                                    _urpt_visible = false;
                                    output.Append("Скрывать входящие данные от УРПТ.");
                                }
                            break;

                        case "SCRIPT":
                            if (args.Length == 1)
                                output.Append(_script);
                            else if (args[1].ToUpper() == "RUN")
                                Runtime.Send(MSG.Script, 0x505954484F4E, ProcessId, _script.ToString());
                            else
                            {
                                _state = SessionState.Script;
                                _script = new StringBuilder();
                                _script_delim = args[1];
                            }
                            break;
#if DEBUG
                        case "TEST": // Произвольный тест -->
                            break;
#endif
                        case "PING": // Команды операционной системы Windows -->
                        case "TRACERT":
                        case "ROUTE":
                        case "ARP":

                        case "CHCP":
                            if (args.Length == 2)
                            {
                                var encoding = CodePagesEncodingProvider.Instance.GetEncoding(args[1]);
                                if (encoding == null)
                                    switch (args[1].ToUpper())
                                    {
                                        case "UTF8":
                                        case "UTF-8":
                                        case "65001":
                                            encoding = Encoding.UTF8;
                                            break;
                                        case "1200":
                                        case "CP1200":
                                        case "CP-1200":
                                        case "UNICODE":
                                            encoding = Encoding.Unicode;
                                            break;
                                        case "866":
                                        case "CP866":
                                        case "CP-866":
                                        case "DOS":
                                            encoding = CodePagesEncodingProvider.Instance.GetEncoding(866);
                                            break;
                                        case "1251":
                                        case "CP1251":
                                        case "CP-1251":
                                        case "WIN":
                                        case "WINDOWS":
                                            encoding = CodePagesEncodingProvider.Instance.GetEncoding(1251);
                                            break;
                                    }

                                if (encoding != null)
                                {
                                    _channel.ConsoleEncoding = encoding;
                                    output.Append($"\x1bcКодовая страница изменена на \"{_channel.ConsoleEncoding.EncodingName}\"");
                                }
                                else
                                    output.Append($"Кодовая страница \"{args[0]}\" не найдена");
                            }
                            else
                                PrintHelp(output, cmd);
                            break;

                        case BREAK: // "\xfffd\xfffd\x03" - [Ctrl+C] Прерываем цикличный вывод -->
                            _cancellationTokenSources.Where(c => !c.IsCancellationRequested).ToList().ForEach(c => c.Cancel());
                            _repeat = null;
                            _trace = false;
                            _modified = 0;
                            Runtime.Send(MSG.Cancel, 0, ProcessId);
                            break;

                        case "":
                            prompt = string.Empty;
                            break;

                        default:
                            handled = false;
                            break;
                    }
                break;
        }

        if (State == SessionState.Running)
        {
            if (!handled)
                output.Append($"\"{input}\" не является внутренней или внешней командой.");
            if (!isloop)
                output.Append(prompt).Append("\r\n> ");

            Print(output.ToString());
        }
        else
            Print(prompt);
    }

    void StoreHistoryCommand(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return;

        _history.Remove(input);
        _history.AddLast(input);
    }

    string GetProcessName(long idProcess)
    {
        var mods = GetModules();
        return idProcess > 0 && mods.Any(s => s.ProcessId == idProcess)
            ? "[" + mods.First(s => s.ProcessId == idProcess).GetType().Name + "] "
            : null;
    }

    void MessageEnabled(bool enabled)
    {
        _msg_enabled = enabled;
        PrintLine(enabled ? TColor.COLOR(TColor.GREEN, STR.TerminalMessageOutputON) : TColor.COLOR(TColor.YELLOW, STR.TerminalMessageOutputOFF));
    }

    void Test(string cmd)
    {
        int.TryParse(Regex.Match(cmd, @"\d+").Value, out var cnt);
        _swtest = Stopwatch.StartNew();
        for (int i = cnt; i >= 0; i--)
            Runtime.Send(MSG.Test, i);
    }

    #region Console...

    void PrintHelp(StringBuilder output, string command = null) =>
        PrintDictionary(output, string.IsNullOrEmpty(command)
            ? TelnetHelp.Terminal
            : TelnetHelp.Terminal.Where(kvp => kvp.Key.StartsWith(command)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

    /// <summary> Стандартный консольный вывод.</summary>
    void Print(string prompt) =>
        _channel.SendString(prompt);

    /// <summary> Стандартный консольный вывод.</summary>
    void PrintLine(string prompt) =>
        Print(prompt + NEWLINE);

    static void PrintDictionary(StringBuilder output, Dictionary<string, string> lines, string separator = " | ")
    {
        var w = new int[2];
        foreach (var c in lines)
        {
            w[0] = Math.Max(w[0], c.Key.Length);
            w[1] = Math.Max(w[1], c.Value?.Length ?? 1);
        }
        foreach (var c in lines)
            output.Append("  ")
                .Append(c.Key.PadRight(w[0]))
                .Append(separator)
                .Append(c.Value?.PadRight(w[1]) ?? "—")
                .Append(NEWLINE);
    }

    void Print(DataTable grid)
    {
        var output = new StringBuilder(NEWLINE);
        PrintTable(output, grid);
        _channel.SendString(output.Append(NEWLINE).ToString());
    }

    static string CellValue(object val) => val == DBNull.Value ? "\x2500" : val is long xref ? xref.ToString("X") : val is bool xbool ? xbool ? "1" : "0" : val.ToString();

    static void PrintTable(StringBuilder output, DataTable data)
    {
        string line = string.Empty, endline = string.Empty;
        var w = new int[data.Columns.Count];
        foreach (DataColumn c in data.Columns)
            foreach (DataRow r in data.Rows)
                w[c.Ordinal] = Math.Max(w[c.Ordinal], CellValue(r[c.Ordinal]).Length);

        foreach (DataColumn c in data.Columns)
        {
            bool islast = data.Columns.Count == c.Ordinal + 1;
            line += new string('\x2500', w[c.Ordinal] + 2) + (islast ? "\x2524" : "\x253C");
            endline += new string('\x2500', w[c.Ordinal] + 2) + (islast ? "\x2518" : "\x2534");
            output.Append(" " + c.ColumnName.PadRight(w[c.Ordinal] + 1)[..(w[c.Ordinal] + 1)]);
            output.Append("\x2502");
        }
        output.Append(NEWLINE).Append(line).Append(NEWLINE);
        foreach (DataRow row in data.Rows)
        {
            output.Append(' ');
            output.Append(string.Join(" \x2502 ", data.Columns.Cast<DataColumn>()
                .Select(c => CellValue(row[c.Ordinal]).PadRight(w[c.Ordinal]))));

            output.Append(" \x2502").Append(NEWLINE);
        }
        output.Append(endline);
    }

    #endregion Console

    #endregion Private methods
}
