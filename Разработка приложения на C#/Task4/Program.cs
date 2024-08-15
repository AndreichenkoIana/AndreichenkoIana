﻿using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int[] values = new int[20];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = random.Next(0, 10);
        }

        int sum = random.Next(0, 20);
        Console.WriteLine($"Дан массив чисел: {String.Join(" ", values)}");
        Console.WriteLine($"Ищем 3 числа, которые дают в сумме {sum}:");

        var result = FindThreeNumbers(values, sum);
        if (result != null)
        {
            Console.WriteLine($"Найдены числа: {result[0]}, {result[1]}, {result[2]}");
        }
        else
        {
            Console.WriteLine("Числа не найдены.");
        }
    }

    static int[] FindThreeNumbers(int[] arr, int targetSum)
    {
        Array.Sort(arr); // Сортируем массив

        for (int i = 0; i < arr.Length - 2; i++)
        {
            int left = i + 1;
            int right = arr.Length - 1;

            while (left < right)
            {
                int currentSum = arr[i] + arr[left] + arr[right];

                if (currentSum == targetSum)
                {
                    return new int[] { arr[i], arr[left], arr[right] }; // Возвращаем найденные числа
                }
                else if (currentSum < targetSum)
                {
                    left++; // Увеличиваем сумму
                }
                else
                {
                    right--; // Уменьшаем сумму
                }
            }
        }

        return null; // Если не нашли такие числа
    }
}
