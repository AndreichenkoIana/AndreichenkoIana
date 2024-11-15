using NetMQ;
using NetMQ.Sockets;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class NetMQClient : IMessageSourceClient
    {
        private RequestSocket _requestSocket;
        private string _address;

        public async Task Connect(string address)
        {
            _address = address;
            _requestSocket = new RequestSocket();
            _requestSocket.Connect(_address);
        }

        public async Task Disconnect()
        {
            _requestSocket?.Disconnect(_address);
            _requestSocket?.Close();
            _requestSocket = null;
        }

        public async Task SendMessage(string message)
        {
            _requestSocket.SendFrame(message);
        }

        public async Task<string> ReceiveMessage()
        {
            return _requestSocket.ReceiveFrameString();
        }
    }
}
