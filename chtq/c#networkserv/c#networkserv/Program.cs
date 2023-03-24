using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;



IPAddress ip = IPAddress.Parse("127.0.0.1");
IPEndPoint ep = new IPEndPoint(ip, 8888);
var server = new TcpListener(ep);

try
{
    server.Start();
    Console.WriteLine("Запущен");
    while (true)
    {
        using var client = await server.AcceptTcpClientAsync();
        var stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytes = 0;
        var message = new StringBuilder();
        do
        {
            bytes = await stream.ReadAsync(buffer);
            message.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
            Console.WriteLine(message);
            message.Clear();
        }
        while (bytes > 0);


    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());

}
finally
{
    server.Stop();
}





        
        //try
        //{
        //    server.Start();
        //    while (true)
        //    {
        //        using var client = await server.AcceptTcpClientAsync();
        //        Console.WriteLine("Connected {0}", client.Client.RemoteEndPoint);
        //        byte[] data = Encoding.UTF8.GetBytes("hello");
        //        var stream = client.GetStream();
        //        await stream.WriteAsync(data);
        //        Console.WriteLine("отправил сообщение");

        //    }
        //}
        //catch (Exception)
        //{

        //    throw;
        //}
        //finally
        //{
        //    server.Stop();
        //}
        

    








