using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try
{
    await socket.ConnectAsync(IPAddress.Any, 8888);
    Console.WriteLine($"Подключился {socket.RemoteEndPoint}");
}
catch(SocketException ex)
{
    Console.WriteLine(ex.ToString());   
}


