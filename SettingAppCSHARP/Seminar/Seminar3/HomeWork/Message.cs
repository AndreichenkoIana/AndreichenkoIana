using System.Text.Json;

namespace HomeWork
{
    internal class Message
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Stime { get; set; }
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public static Message? FromJson(string message)
        {
            return JsonSerializer.Deserialize<Message>(message);
        }

        public Message(string nikname, string text)
        {
            this.Name = nikname;
            this.Text = text;
            this.Stime = DateTime.Now;
        }
        public Message() { }

        public override string ToString()
        {
            return $"Получено сообщение от {Name} ({Stime.ToShortTimeString()}): \n {Text}";
        }
    }
}
