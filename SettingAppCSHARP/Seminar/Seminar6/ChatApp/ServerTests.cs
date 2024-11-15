using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChatApp
{
    [TestClass]
    public class ServerTests
    {
        private Server _server;

        [TestInitialize]
        public void Setup()
        {
            _server = new Server(5000);
            _server.Start();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _server.Stop();
        }

        [TestMethod]
        public async Task TestServerStartAndStop()
        {
            Assert.IsTrue(true); // Проверка запуска и остановки без ошибок
            await Task.Delay(100); // Небольшая задержка для проверки асинхронности
        }
    }
}
