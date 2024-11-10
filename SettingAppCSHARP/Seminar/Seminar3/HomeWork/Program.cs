namespace HomeWork
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                await Server.AcceptMsg();
            }
            else
            {
                await Client.SendMsg($"{args[0]}");
            }
        }
    }
}
