using System.Net.Sockets;
using Communication.Sockets.Core.Server;

namespace Communication.Sockets.Core
{
    public delegate void TCPTerminal_MessageRecivedDel(ConnectedClient socket, byte[] message);
    public delegate void TCPTerminal_ConnectDel(Socket socket);
    public delegate void TCPTerminal_DisconnectDel(Socket socket);
}
