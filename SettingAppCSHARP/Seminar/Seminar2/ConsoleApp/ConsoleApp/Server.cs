using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    internal class Server
    {
        private static bool isRunning = true;

        public static void AcceptMsg()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(16874);
            Console.WriteLine("Сервер ожидает сообщение. Нажмите любую клавишу для завершения работы.");

            // Запускаем поток для ожидания нажатия клавиши
            Thread keyListenerThread = new Thread(WaitForKeyPress);
            keyListenerThread.Start();

            while (isRunning)
            {
                if (udpClient.Available > 0)
                {
                    byte[] buffer = udpClient.Receive(ref ep);
                    string data = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

                    // Проверка на получение команды "Exit"
                    if (data.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Получена команда 'Exit'. Завершение работы сервера.");
                        isRunning = false;
                        break;
                    }

                    new Thread(() =>
                    {
                        Message msg = Message.FromJson(data);
                        Console.WriteLine(msg.ToString());
                        Message responseMsg = new Message("Server", "Message accepted on server!");
                        string responseMsgJs = responseMsg.ToJson();
                        byte[] responseDate = Encoding.UTF8.GetBytes(responseMsgJs);
                        udpClient.Send(responseDate, ep);
                    }).Start();
                }
            }

            udpClient.Close();
            Console.WriteLine("Сервер остановлен.");
        }

        private static void WaitForKeyPress()
        {
            Console.ReadKey(true); // Ожидаем нажатия любой клавиши
            isRunning = false; // Сигнализируем основному потоку завершить работу
        }
    }
}
