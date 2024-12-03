using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lesson1;

class Programm
{
    static void Main(string[] args)
    {
        using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);

            Console.WriteLine("Connecting...");
            client.Connect(remoteEndPoint);
            Console.WriteLine("Connected!");

            byte[] bytes = Encoding.UTF8.GetBytes("Привет!");

            int count = client.Send(bytes);

            if (count == bytes.Length)
            {
                Console.WriteLine("Отправленно");
            }
            else
            {
                Console.WriteLine("Что-то пошло не так");
            }

        }
    }
}