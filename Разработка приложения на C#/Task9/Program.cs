using System;
using System.Text.Json;
using System.Xml;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Использование: JsonToXmlConverter.exe <json-файл>");
            return;
        }

        string jsonFilePath = args[0];

        try
        {
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            using JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
            XmlDocument xmlDocument = new XmlDocument();

            XmlElement root = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(root);

            JsonToXmlConverter.ConvertJsonToXml(jsonDocument.RootElement, root, xmlDocument);

            string xmlOutput = xmlDocument.OuterXml;
            Console.WriteLine("Результат XML:");
            Console.WriteLine(xmlOutput);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
