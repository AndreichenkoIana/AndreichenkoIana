using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Seminar4
{
    abstract class ChatParticipant
    {
        protected bool isRunning = true;
        protected UdpClient udpClient;

        public async Task Run()
        {
            Initialize();
            await ProcessMessages();
            Cleanup();
        }

        protected abstract void Initialize();
        protected abstract Task ProcessMessages();
        protected abstract void Cleanup();
    }
}
