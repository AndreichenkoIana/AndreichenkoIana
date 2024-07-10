//Задача 1: Задайте значения M и N. 
//Напишите программу, которая выведет все натуральные числа в промежутке от M до N. 
//Использовать рекурсию, не использовать циклы.

using System;
internal class Program
{
    static void Main()
    {
        int m = ReadInt("Введите первое число: ");
        int n = ReadInt("Введите второе число: ");
        if (m < n)
        {
            PrintNumber(m, n);
        }
        else
        {
            PrintNumber(n, m);
        }
    }

    static void PrintNumber(int m, int n)
    {
        if (n < m)
        {
            return;
        }

        PrintNumber(m, n - 1);
        Console.Write(n + " ");
    }
    static int ReadInt(string msg)
    {
        Console.Write(msg);
        return Convert.ToInt32(Console.ReadLine());
    }
}