using static ObjectSerializer;
internal class Program
{
    private static void Main()
    {
        // Создание объекта и его сериализация
        var sample = new SampleClass { I = 42, Name = "Test" };
        string serialized = ObjectToString(sample);
        Console.WriteLine("Serialized: " + serialized);

        // Десериализация обратно в объект
        var newSample = new SampleClass();
        StringToObject(serialized, newSample);
        Console.WriteLine($"Deserialized: I={newSample.I}, Name={newSample.Name}");
    }
}
