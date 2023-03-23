using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //string ip = "192.168.50.249";
        var port = 80;
        IPAddress ip = new IPAddress(new byte[] { 192, 168, 50, 19 });
        IPEndPoint ep = new IPEndPoint(ip, port);
        using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            await socket.ConnectAsync(ep);
            string message = "aaa";
            var messageBytes = Encoding.UTF8.GetBytes(message);
            int sended = await socket.SendAsync(messageBytes, SocketFlags.None);
            Console.WriteLine($"Отправил {sended}");

        }
        catch (SocketException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}