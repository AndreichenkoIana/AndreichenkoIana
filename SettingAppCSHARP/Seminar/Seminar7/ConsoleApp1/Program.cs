namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new NetMQServer("tcp://*:5000");
            server.Start();

            var client = new NetMQClient();
            await client.Connect("tcp://localhost:5000");

            for (int i = 0; i < 10; i++)
            {
                string messageToSend = $"Message {i}";
                await client.SendMessage(messageToSend);

                string response = await client.ReceiveMessage();
                Console.WriteLine("Response from server: " + response);
            }

            await client.Disconnect();
            server.Stop();

            Console.ReadLine(); // Ожидание ввода для завершения программы
        }
    }

}
