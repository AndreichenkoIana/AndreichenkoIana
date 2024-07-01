class Program
{
    static void Main()
    {
        int[] numbers = new int[10]; // Массив для хранения случайных чисел
        Random random = new Random(); // Генератор случайных чисел
        int evenCount = 0; // Счетчик четных чисел
        // Заполнение массива случайными трехзначными числами
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(100, 1000); // Случайное число от 100 до 999
            Console.Write(numbers[i] + " "); // Вывод сгенерированного числа
            // Проверка на четность и увеличение счетчика
            if (numbers[i] % 2 == 0)
            {
                evenCount++;
            }
        }
        // Вывод количества четных чисел в массиве
        Console.WriteLine($"\nКоличество четных чисел в массиве: {evenCount}");
    }
}