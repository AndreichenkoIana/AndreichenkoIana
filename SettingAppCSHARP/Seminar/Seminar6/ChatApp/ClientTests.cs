using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChatApp
{
    [TestClass]
    public class ClientTests
    {
        private Client _client;

        [TestInitialize]
        public void Setup()
        {
            _client = new Client();
        }

        [TestMethod]
        public async Task TestClientConnectAndDisconnect()
        {
            await _client.Connect("localhost", 5000);
            Assert.IsTrue(true); // Проверка подключения без ошибок

            _client.Disconnect();
            Assert.IsTrue(true); // Проверка отключения без ошибок
        }

        [TestMethod]
        public async Task TestSendAndReceiveMessage()
        {
            await _client.Connect("localhost", 5000);

            string messageToSend = "Hello, Server!";
            await _client.SendMessage(messageToSend);

            string receivedMessage = await _client.ReceiveMessage();
            Assert.AreEqual(messageToSend, receivedMessage);

            _client.Disconnect();
        }

        [TestMethod]
        public async Task TestMultipleMessagesExchange()
        {
            await _client.Connect("localhost", 5000);

            for (int i = 0; i < 10; i++)
            {
                string messageToSend = $"Message {i}";
                await _client.SendMessage(messageToSend);

                string receivedMessage = await _client.ReceiveMessage();
                Assert.AreEqual(messageToSend, receivedMessage);
            }

            _client.Disconnect();
        }
    }
}
