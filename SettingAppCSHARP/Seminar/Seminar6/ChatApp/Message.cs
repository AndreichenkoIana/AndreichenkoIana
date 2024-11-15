
namespace ChatApp
{
    public class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }

        public Message(string sender, string content)
        {
            Sender = sender;
            Content = content;
        }

        public override string ToString()
        {
            return $"{Sender}: {Content}";
        }
    }

}
