using System;
using static Labirynth;

public class Program
{
    public static void Main(string[] args)
    {
        int[,] labirynth1 = new int[,]
        {
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
        };

        int startI = 3;
        int startJ = 0;

        int exitCount = CountExits(startI, startJ, labirynth1);
        Console.WriteLine($"Количество выходов в лабиринте: {exitCount}");
    }
}