using System.Net.Sockets;
using System.Text;


try
{
    TcpClient client = new TcpClient();
    await client.ConnectAsync("127.0.0.1", 8888);

    while (true)
    {
        var stream = client.GetStream();
        string message = Console.ReadLine();
        if (message != null)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(bytes);


        }
        else
        {
            Console.WriteLine("Введите сообщение");
        }
        

    }
      
}
catch (Exception ex)
{

}


