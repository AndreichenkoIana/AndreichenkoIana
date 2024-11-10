using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HomeWork
{
    internal class Server
    {
        private static bool isRunning = true;
        private static CancellationTokenSource cancellationToken = new CancellationTokenSource();
        public static async Task AcceptMsg()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(16874);
            Console.WriteLine("Сервер ожидает сообщение. Нажмите любую клавишу для завершения работы.");

            try
            {
                while (isRunning)
                {
                    if (udpClient.Available > 0)
                    {
                        byte[] buffer = udpClient.Receive(ref ep);
                        string data = Encoding.UTF8.GetString(buffer);

                        // Проверка на получение команды "Exit"
                        if (data.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                        {
                            cancellationToken.Cancel();
                        }

                        await Task.Run(async () =>
                        {
                            Message msg = Message.FromJson(data);
                            System.Console.WriteLine(msg.ToString());

                            Message responseMsg = new Message("Server", "Message accept on server!");
                            string responseMsgJs = responseMsg.ToJson();
                            byte[] responseDate = Encoding.UTF8.GetBytes(responseMsgJs);
                            await udpClient.SendAsync(responseDate, ep);
                        });
                    }
                }

                udpClient.Close();
                Console.WriteLine("Сервер остановлен.");
            }
            catch
            {
                Console.WriteLine("Сlient has stopped execution");
            }
        }

    }
}
