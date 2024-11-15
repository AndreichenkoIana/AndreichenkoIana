using NetMQ;
using NetMQ.Sockets;

namespace ConsoleApp1
{
    public class NetMQServer : IMessageSource
    {
        private readonly string _address;
        private ResponseSocket _responseSocket;
        private bool _isRunning;

        public NetMQServer(string address)
        {
            _address = address;
        }

        public void Start()
        {
            _isRunning = true;
            _responseSocket = new ResponseSocket(_address);

            Task.Run(() =>
            {
                while (_isRunning)
                {
                    var message = _responseSocket.ReceiveFrameString();
                    Console.WriteLine("Received: " + message);
                    _responseSocket.SendFrame(message); // Echo back the message
                }
            });
        }

        public void Stop()
        {
            _isRunning = false;
            _responseSocket?.Close();
            _responseSocket = null;
        }
    }
}
