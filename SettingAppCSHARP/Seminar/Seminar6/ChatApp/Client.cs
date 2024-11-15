using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
    public class Client
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public async Task Connect(string host, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(host, port);
            _stream = _client.GetStream();
            Console.WriteLine("Connected to server.");
        }

        public async Task SendMessage(string message)
        {
            if (_stream == null) throw new InvalidOperationException("Not connected to server.");

            var data = Encoding.UTF8.GetBytes(message);
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<string> ReceiveMessage()
        {
            if (_stream == null) throw new InvalidOperationException("Not connected to server.");

            var buffer = new byte[1024];
            int byteCount = await _stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, byteCount);
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
            Console.WriteLine("Disconnected from server.");
        }
    }
}
