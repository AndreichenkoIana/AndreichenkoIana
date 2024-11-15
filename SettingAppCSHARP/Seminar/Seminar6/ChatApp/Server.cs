using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
    public class Server
    {
        private TcpListener _listener;
        private bool _isRunning;

        public Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            _listener.Start();
            _isRunning = true;
            Console.WriteLine("Server started.");

            Task.Run(() => ListenForClients());
        }

        private async Task ListenForClients()
        {
            while (_isRunning)
            {
                var client = await _listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected.");
                Task.Run(() => HandleClient(client));
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            var stream = client.GetStream();
            var buffer = new byte[1024];

            while (_isRunning)
            {
                int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (byteCount <= 0) break;

                var message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Console.WriteLine("Received: " + message);

                // Echo the message back to the client
                await stream.WriteAsync(buffer, 0, byteCount);
            }

            client.Close();
            Console.WriteLine("Client disconnected.");
        }

        public void Stop()
        {
            _isRunning = false;
            _listener.Stop();
            Console.WriteLine("Server stopped.");
        }
    }
}
