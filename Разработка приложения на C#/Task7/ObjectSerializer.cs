using System.Reflection;

public static class ObjectSerializer
{
    // Метод для сериализации объекта в строку
    public static string ObjectToString<T>(T obj)
    {
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
        var keyValuePairs = new List<string>();

        foreach (var field in fields)
        {
            var customNameAttr = field.GetCustomAttribute<CustomNameAttribute>();
            string fieldName = customNameAttr != null ? customNameAttr.Name : field.Name;
            string fieldValue = field.GetValue(obj)?.ToString() ?? "null";
            keyValuePairs.Add($"{fieldName}:{fieldValue}");
        }

        return string.Join(", ", keyValuePairs);
    }

    // Метод для десериализации строки в объект
    public static void StringToObject<T>(string str, T obj)
    {
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
        var keyValuePairs = str.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var pair in keyValuePairs)
        {
            var parts = pair.Split(':');
            if (parts.Length != 2) continue;

            string fieldName = parts[0].Trim();
            string fieldValue = parts[1].Trim();

            // Поиск поля по имени или по атрибуту
            var field = fields.FirstOrDefault(f =>
                f.Name == fieldName ||
                (f.GetCustomAttribute<CustomNameAttribute>()?.Name == fieldName));

            if (field != null)
            {
                // Установка значения поля
                object value = Convert.ChangeType(fieldValue, field.FieldType);
                field.SetValue(obj, value);
            }
        }
    }
}
