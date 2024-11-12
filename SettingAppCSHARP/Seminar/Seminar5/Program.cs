using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Запуск сервера...");
                Server server = new Server();
                await server.Run();
            }
            else
            {
                Console.WriteLine("Запуск клиента...");
                Client client = new Client(args[0]);
                await client.Run();
            }
        }
    }
}
