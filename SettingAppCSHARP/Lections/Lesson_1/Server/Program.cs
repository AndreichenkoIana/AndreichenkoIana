using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lesson1;

class Programm
{
    static void Main(string[] args)
    {
        using(Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            listener.Blocking = true;
            listener.Bind(localEndPoint);
            listener.Listen(100);
            Console.WriteLine("Waitting for connection...");
            var socket = listener.Accept();
            Console.WriteLine("Connected!");

            byte[] buffer = new byte[255];



            int count = socket.Receive(buffer);

            if (count > 0)
            {
                string message = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Сообщение не получено!");
            }
            listener.Close();
        }
    }
}