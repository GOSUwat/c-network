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
            var recive = new byte[512];
            var bytes = await socket.ReceiveAsync(recive, SocketFlags.None);
            string response = Encoding.UTF8.GetString(recive, 0, bytes);
            Console.WriteLine(response);

        }
        catch (SocketException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}