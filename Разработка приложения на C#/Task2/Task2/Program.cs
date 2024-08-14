using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Примеры использования неявного приведения
        Bits bitsFromLongImplicit = 1234567890123456789L;
        Bits bitsFromIntImplicit = 123456789;
        Bits bitsFromByteImplicit = (byte)123;

        Console.WriteLine("Неявное приведение:");
        Console.WriteLine(bitsFromLongImplicit);
        Console.WriteLine(bitsFromIntImplicit);
        Console.WriteLine(bitsFromByteImplicit);

        // Примеры использования явного приведения
        long longValue = (long)bitsFromLongImplicit;
        int intValue = (int)bitsFromIntImplicit;
        byte byteValue = (byte)bitsFromByteImplicit;

        Console.WriteLine("Явное приведение:");
        Console.WriteLine(longValue);
        Console.WriteLine(intValue);
        Console.WriteLine(byteValue);
    }
}
