using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IMessageSource
    {
        void Start();
        void Stop();
    }

    public interface IMessageSourceClient
    {
        Task Connect(string address);
        Task Disconnect();
        Task SendMessage(string message);
        Task<string> ReceiveMessage();
    }

}
