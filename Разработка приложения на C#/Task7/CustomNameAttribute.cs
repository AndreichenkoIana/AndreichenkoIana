
// Определяем атрибут CustomName
[AttributeUsage(AttributeTargets.Field)]
public class CustomNameAttribute : Attribute
{
    public string Name { get; }

    public CustomNameAttribute(string name)
    {
        Name = name;
    }
}
