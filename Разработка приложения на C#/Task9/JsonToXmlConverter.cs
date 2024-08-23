using System.Text.Json;
using System.Xml;

class JsonToXmlConverter
    {
    public static void ConvertJsonToXml(JsonElement jsonElement,
                                        XmlElement parentElement,
                                        XmlDocument xmlDocument)
    {
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in jsonElement.EnumerateObject())
                {
                    XmlElement element = xmlDocument.CreateElement(property.Name);
                    parentElement.AppendChild(element);
                    ConvertJsonToXml(property.Value, element, xmlDocument);
                }
                break;

            case JsonValueKind.Array:
                foreach (var item in jsonElement.EnumerateArray())
                {
                    XmlElement arrayItemElement = xmlDocument.CreateElement("Item");
                    parentElement.AppendChild(arrayItemElement);
                    ConvertJsonToXml(item, arrayItemElement, xmlDocument);
                }
                break;

            case JsonValueKind.String:
                parentElement.InnerText = jsonElement.GetString();
                break;

            case JsonValueKind.Number:
                parentElement.InnerText = jsonElement.GetRawText();
                break;

            case JsonValueKind.True:
            case JsonValueKind.False:
                parentElement.InnerText = jsonElement.GetBoolean().ToString();
                break;

            case JsonValueKind.Null:
                // Оставляем пустым для null
                break;

            default:
                throw new NotSupportedException($"Тип значения {jsonElement.ValueKind} не поддерживается.");
        }
    }
}

