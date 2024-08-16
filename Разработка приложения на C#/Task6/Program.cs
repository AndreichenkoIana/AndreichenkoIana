using System;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первое число:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Calculator calc = new Calculator(num1);

        Console.WriteLine("Введите оператор (+, -, *, /):");
        char op = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.WriteLine("Введите второе число:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        try
        {
            double result = 0;

            switch (op)
            {
                case '+':
                    result = calc + num2;
                    break;
                case '-':
                    result = calc - num2;
                    break;
                case '*':
                    result = calc * num2;
                    break;
                case '/':
                    result = calc / num2;
                    break;
                default:
                    Console.WriteLine("Некорректный оператор!");
                    return;
            }

            Console.WriteLine($"Результат: {result}");
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }
}
