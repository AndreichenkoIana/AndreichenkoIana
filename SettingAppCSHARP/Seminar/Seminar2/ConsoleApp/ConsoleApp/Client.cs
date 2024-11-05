using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp
{
    internal class Client
    {
        public static void SendMsg(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16874);
            UdpClient udpClient = new UdpClient();

            while (true)
            {
                Console.WriteLine("Введите сообщение (или 'Exit' для выхода):");
                string userInput = Console.ReadLine();

                if (userInput.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Завершение работы клиента.");
                    break;
                }

                Message msg = new Message(name, userInput);
                string responseMsgJs = msg.ToJson();
                byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                udpClient.Send(responseData, ep);

                byte[] answerData = udpClient.Receive(ref ep);
                string answerMsgJs = Encoding.UTF8.GetString(answerData);
                Message answerMsg = Message.FromJson(answerMsgJs);
                Console.WriteLine(answerMsg.ToString());
            }

            udpClient.Close();
        }
    }
}
