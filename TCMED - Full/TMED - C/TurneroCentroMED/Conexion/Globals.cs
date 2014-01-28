using System.Net.Sockets;

namespace Communication.Sockets.Core
{
    public delegate void TCPTerminal_MessageRecivedDel(byte[] message);
    public delegate void TCPTerminal_ConnectDel(Socket socket);
    public delegate void TCPTerminal_DisconnectDel(Socket socket);
}
