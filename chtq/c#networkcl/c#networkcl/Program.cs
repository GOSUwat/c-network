using System.Net.Sockets;
using System.Text;

using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try
{
    await socket.ConnectAsync("127.0.0.1", 8888);
    var message = "hello";
    var mbytes = Encoding.UTF8.GetBytes(message);
    var sended = await socket.SendAsync(mbytes, SocketFlags.None);


    Console.WriteLine($"Подключился {socket.RemoteEndPoint}");
}
catch(SocketException ex)
{
    Console.WriteLine(ex.ToString());   
}


