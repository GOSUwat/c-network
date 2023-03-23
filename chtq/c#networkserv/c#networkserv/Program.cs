using System.Net;
using System.Net.Sockets;
using System.Text;

IPEndPoint bind = new IPEndPoint(IPAddress.Any, 8888);
using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(bind);
socket.Listen();
Console.WriteLine("Ждем коннектов");
using Socket client = await socket.AcceptAsync();
Console.WriteLine($"Кто то подключился {client.RemoteEndPoint}");
byte[] bytes = new byte[512];
var data = await socket.ReceiveAsync(bytes, SocketFlags.None);
string message = Encoding.UTF8.GetString(data);


