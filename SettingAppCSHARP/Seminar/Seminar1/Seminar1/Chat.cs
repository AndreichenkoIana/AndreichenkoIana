using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Seminar1
{
    internal class Chat
    {
        public static void Server()
        {
            IPEndPoint local = new IPEndPoint(IPAddress.Any, 12345);
            UdpClient udp = new UdpClient(12345);
            Console.WriteLine("Сервер ожидает сообщения от клиента");

            while(true)
            {
                try
                {
                    byte[] buffer = udp.Receive(ref local);
                    string str1 = Encoding.UTF8.GetString(buffer);

                    Message? message = Message.FromJson(str1);
                    if (message != null )
                    {
                        Console.WriteLine(message.ToString());
                        Message newmessage = new Message("server", "Сообщение получено");
                        string js = newmessage.ToJson();
                        byte[] bytes = Encoding.UTF8.GetBytes(js);
                        udp.Send(bytes, local);
                    }
                    else
                    {
                        Console.WriteLine("Некорректное сообщение");
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Client(string nik)
        {
            IPEndPoint local = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            UdpClient udp = new UdpClient();
            Console.WriteLine("Укажите имя");

            while (true)
            {
                Console.WriteLine("Введите сообщение");
                string text = Console.ReadLine();
                if (String.IsNullOrEmpty(text))
                {
                    break;
                }
                Message newmessage = new Message(nik, text);
                string js = newmessage.ToJson();
                byte[] bytes = Encoding.UTF8.GetBytes(js);
                udp.Send(bytes, local);

                byte[] buffer = udp.Receive(ref local);
                string str1 = Encoding.UTF8.GetString(buffer);
                Message? message = Message.FromJson(str1);
                Console.WriteLine(message);
            }
        }
    }
}
