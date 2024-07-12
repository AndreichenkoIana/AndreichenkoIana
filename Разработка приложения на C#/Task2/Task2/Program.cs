using System;

class Program
{
    static void Main()
    {
        long longNumber = 1234567890123456789;
        int intNumber = 123456789;
        byte byteNumber = 200;

        string longBits = Convert.ToString(longNumber, 2);
        string intBits = Convert.ToString(intNumber, 2);
        string byteBits = Convert.ToString(byteNumber, 2);

        Console.WriteLine($"Биты для long: {longBits}");
        Console.WriteLine($"Биты для int: {intBits}");
        Console.WriteLine($"Биты для byte: {byteBits}");
    }
}
