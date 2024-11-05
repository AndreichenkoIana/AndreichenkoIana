using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Server.AcceptMsg();
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
