using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите неотрицательное число m: ");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите неотрицательное число n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int result = AckermannFunction(m, n);
        Console.WriteLine($"Значение функции Аккермана для ({m}, {n}) равно: {result}");
    }

    static int AckermannFunction(int m, int n)
    {
        if (m == 0)
            return n + 1;
        else if (n == 0)
            return AckermannFunction(m - 1, 1);
        else
            return AckermannFunction(m - 1, AckermannFunction(m, n - 1));
    }
}