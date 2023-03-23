using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

var port = 8888;
IPEndPoint bind = new IPEndPoint(IPAddress.Any, port);
using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(bind);
Console.WriteLine(socket.LocalEndPoint);
socket.Listen(1000);
Console.WriteLine("Ждем коннектов");
using Socket client = await socket.AcceptAsync();
Console.WriteLine($"Кто то подключился {client.RemoteEndPoint}");