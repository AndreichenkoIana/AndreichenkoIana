using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Seminar4
{
    internal class Server : ChatParticipant
    {
        private static CancellationTokenSource cancellationToken = new CancellationTokenSource();

        protected override void Initialize()
        {
            udpClient = new UdpClient(16874);
            Console.WriteLine("Сервер ожидает сообщение. Нажмите любую клавишу для завершения работы.");
        }

        protected override async Task ProcessMessages()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                while (isRunning)
                {
                    if (udpClient.Available > 0)
                    {
                        byte[] buffer = udpClient.Receive(ref ep);
                        string data = Encoding.UTF8.GetString(buffer);

                        if (data.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                        {
                            cancellationToken.Cancel();
                        }

                        await Task.Run(async () =>
                        {
                            Message msg = Message.FromJson(data);
                            Console.WriteLine(msg.ToString());

                            Message responseMsg = new Message("Server", "Message accept on server!");
                            string responseMsgJs = responseMsg.ToJson();
                            byte[] responseDate = Encoding.UTF8.GetBytes(responseMsgJs);
                            await udpClient.SendAsync(responseDate, ep);
                        });
                    }
                }
            }
            catch
            {
                Console.WriteLine("Client has stopped execution");
            }
        }

        protected override void Cleanup()
        {
            udpClient.Close();
            Console.WriteLine("Сервер остановлен.");
        }
    }
}
