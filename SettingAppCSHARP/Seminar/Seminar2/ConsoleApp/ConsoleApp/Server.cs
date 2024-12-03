using System.Net.Sockets;
using System.Net;
using System.Text;
using ConsoleApp;

namespace ConsoleApp
{
    internal class Server
    {
        public async Task AcceptMsg()
        {

            UdpClient udpClient = new UdpClient(16874);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Сервер ждет сообщение от клиента");

            CancellationTokenSource cts = new CancellationTokenSource();

            while (!cts.IsCancellationRequested)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);

                var messageTxt = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"получено {buffer.Length} байт");

                byte[] reply = Encoding.UTF8.GetBytes("Сообщение получено");

                int bytes = await udpClient.SendAsync(reply, iPEndPoint);
                Console.WriteLine($"отправлено {bytes} байт");

                Message? message = Message.FromJson(messageTxt);
                if (message.Text.ToLower().Equals("exit")) cts.Cancel();
                message.PrintGetMessageFrom();
                cts.Cancel();
            }
        }
    }
}