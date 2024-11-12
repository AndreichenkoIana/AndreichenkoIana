using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Seminar4
{
    internal class Client : ChatParticipant
    {
        private string name;

        public Client(string name)
        {
            this.name = name;
        }

        protected override void Initialize()
        {
            udpClient = new UdpClient();
        }

        protected override async Task ProcessMessages()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16874);

            while (isRunning)
            {
                Console.WriteLine("Enter message");
                string text = Console.ReadLine();

                if (text.Equals("Exit", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(text))
                {
                    isRunning = false;
                    Message msg1 = new Message(name, text);
                    string responseMsgJs1 = msg1.ToJson();
                    byte[] responseData1 = Encoding.UTF8.GetBytes(responseMsgJs1);
                    await udpClient.SendAsync(responseData1, ep);
                    break;
                }

                Message msg = new Message(name, text);
                string responseMsgJs = msg.ToJson();
                byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                await udpClient.SendAsync(responseData, ep);

                if (isRunning)
                {
                    byte[] answerData = udpClient.Receive(ref ep);
                    string answerMsgJs = Encoding.UTF8.GetString(answerData);
                    Message answerMsg = Message.FromJson(answerMsgJs);
                    Console.WriteLine(answerMsg.ToString());
                }
            }
        }

        protected override void Cleanup()
        {
            udpClient.Close();
        }
    }
}
