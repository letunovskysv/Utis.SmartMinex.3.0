//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TcpServer –
//--------------------------------------------------------------------------------------------------
#region Using
using System.Net;
using System.Net.Sockets;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public class TcpServer : Socket
{
    readonly IPEndPoint _endpoint;

    public TcpServer(int port)
        : base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    {
        _endpoint = new IPEndPoint(IPAddress.Any, port);
        Bind(_endpoint);
    }
}