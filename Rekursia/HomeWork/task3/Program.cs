using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[10];
        Random random = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(0, 1000);
        }
        PrintArrayReverse(numbers, numbers.Length - 1);
    }

    static void PrintArrayReverse(int[] arr, int index)
    {
        if (index >= 0)
        {
            Console.Write(arr[index] + " ");
            PrintArrayReverse(arr, index - 1);
        }
    }
}