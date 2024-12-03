using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp.Server;

namespace ConsoleApp
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var server = new Server();
                server?.AcceptMsg();
            }
            else
            {
                new Thread(() =>
                {
                    Client.SendMsg($"{args[0]}");
                }).Start();
            }
        }
    }
}
