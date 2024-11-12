using System.Text;
using System.Text.Json;

namespace Seminar4
{
    internal class Message
    {
        public string Sender { get; set; }
        public string Text { get; set; }

        public Message(string sender, string text)
        {
            Sender = sender;
            Text = text;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message? FromJson(string message)
        {
            return JsonSerializer.Deserialize<Message>(message);
        }

        public static string ListToJson(List<Message> messages)
        {
            var sb = new StringBuilder("[");
            for (int i = 0; i < messages.Count; i++)
            {
                sb.Append(messages[i].ToJson());
                if (i < messages.Count - 1)
                    sb.Append(",");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static List<Message> ListFromJson(string json)
        {
            var messages = new List<Message>();
            var trimmedJson = json.Trim('[', ']');
            if (string.IsNullOrWhiteSpace(trimmedJson))
                return messages;

            var messageStrings = trimmedJson.Split(new[] { "},{" }, StringSplitOptions.None);
            foreach (var msgStr in messageStrings)
            {
                var cleanMsgStr = msgStr.StartsWith("{") ? msgStr : "{" + msgStr;
                cleanMsgStr = cleanMsgStr.EndsWith("}") ? cleanMsgStr : cleanMsgStr + "}";
                messages.Add(FromJson(cleanMsgStr));
            }

            return messages;
        }

        public override string ToString()
        {
            return $"{Sender}: {Text}";
        }
    }
}
