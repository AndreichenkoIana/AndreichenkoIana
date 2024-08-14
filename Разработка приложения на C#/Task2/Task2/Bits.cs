using System;

public class Bits
{
    private long _value;

    // Конструктор для инициализации значением
    public Bits(long value)
    {
        _value = value;
    }

    // Неявное приведение из long в Bits
    public static implicit operator Bits(long value)
    {
        return new Bits(value);
    }

    // Неявное приведение из int в Bits
    public static implicit operator Bits(int value)
    {
        return new Bits(value);
    }

    // Неявное приведение из byte в Bits
    public static implicit operator Bits(byte value)
    {
        return new Bits(value);
    }

    // Явное приведение из Bits в long
    public static explicit operator long(Bits bits)
    {
        return bits._value;
    }

    // Явное приведение из Bits в int
    public static explicit operator int(Bits bits)
    {
        if (bits._value < int.MinValue || bits._value > int.MaxValue)
            throw new InvalidCastException("Value is out of range for an Int32.");
        return (int)bits._value;
    }

    // Явное приведение из Bits в byte
    public static explicit operator byte(Bits bits)
    {
        if (bits._value < byte.MinValue || bits._value > byte.MaxValue)
            throw new InvalidCastException("Value is out of range for a Byte.");
        return (byte)bits._value;
    }

    // Переопределение метода ToString для удобного отображения
    public override string ToString()
    {
        return _value.ToString();
    }
}