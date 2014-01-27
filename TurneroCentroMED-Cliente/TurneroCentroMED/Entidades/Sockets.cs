using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace TurneroCentroMED.Entidades
{
    [Serializable]public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1000000;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        //public Array sb;
    }
}
