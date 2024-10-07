//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TerminalService – Терминальный сервер telnet. Code page: CP866
//--------------------------------------------------------------------------------------------------
#region Using
using System.Net.Sockets;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Метаданные.</summary>
sealed class TerminalService : SmartModule, IStartup
{
    #region Declarations

    TcpServer? _listener;

    public int Port { get; set; }

    #endregion Declarations

    public TerminalService(IRuntime runtime, int? port) : base(runtime)
    {
        Port = port ?? 23;
        Name = "Служба терминалов, порт " + Port;
    }

    public override bool OnStart()
    {
        try
        {
            _listener = new TcpServer(Port);
            _listener.Listen(13);

            var client = new SocketAsyncEventArgs();
            client.Completed += AcceptCompleted;
            _listener.AcceptAsync(client);
            return true;
        }
        catch (Exception ex)
        {
            LastError = ex;
            _listener = null;
            Runtime.Send(MSG.ErrorMessage, 0, 0, ex);
            throw;
        }
    }

    public override async Task OnExecuteAsync(TMessage m, CancellationToken stoppingToken)
    {
        await DoEventsAsync(500, stoppingToken);
    }

    public override void OnStop()
    {
        if (_listener != null)
        {
            _listener.Shutdown(SocketShutdown.Both);
            _listener.Close(0);
            _listener.Dispose();
            _listener = null;
        }
    }

    void AcceptCompleted(object? sender, SocketAsyncEventArgs e)
    {
        do
        {
            try
            {
                if (e.SocketError == SocketError.Success)
                    Runtime.Send(MSG.RunModule, ProcessId, 0, typeof(TelnetSession), e.AcceptSocket);
            }
            catch
            { }
            finally
            {
                e.AcceptSocket = null; // to enable reuse
            }
        }
        while (!_listener.AcceptAsync(e));
    }
}
