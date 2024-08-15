using System;

namespace ConsoleCalculator
{
    // Интерфейс для операций калькулятора
    public interface IOperation
    {
        double Execute(double a, double b);
        string GetSymbol();
    }

    // Класс для сложения
    public class Addition : IOperation
    {
        public double Execute(double a, double b) => a + b;
        public string GetSymbol() => "+";
    }

    // Класс для вычитания
    public class Subtraction : IOperation
    {
        public double Execute(double a, double b) => a - b;
        public string GetSymbol() => "-";
    }

    // Класс для умножения
    public class Multiplication : IOperation
    {
        public double Execute(double a, double b) => a * b;
        public string GetSymbol() => "*";
    }

    // Класс для деления
    public class Division : IOperation
    {
        public double Execute(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Деление на ноль невозможно.");
            return a / b;
        }

        public string GetSymbol() => "/";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в калькулятор!");
            Console.WriteLine("Введите 'отмена' для выхода.");

            while (true)
            {
                Console.Write("Введите первое число: ");
                string inputA = Console.ReadLine();
                if (string.IsNullOrEmpty(inputA) || inputA.ToLower() == "отмена") break;

                Console.Write("Введите второе число: ");
                string inputB = Console.ReadLine();
                if (string.IsNullOrEmpty(inputB) || inputB.ToLower() == "отмена") break;

                Console.Write("Выберите операцию (+, -, *, /): ");
                string operation = Console.ReadLine();
                if (operation.ToLower() == "отмена") break;

                try
                {
                    double a = Convert.ToDouble(inputA);
                    double b = Convert.ToDouble(inputB);
                    IOperation selectedOperation = operation switch
                    {
                        "+" => new Addition(),
                        "-" => new Subtraction(),
                        "*" => new Multiplication(),
                        "/" => new Division(),
                        _ => throw new InvalidOperationException("Недопустимая операция.")
                    };

                    double result = selectedOperation.Execute(a, b);
                    Console.WriteLine($"Результат: {a} {selectedOperation.GetSymbol()} {b} = {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите корректные числа.");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Спасибо за использование калькулятора. До свидания!");
        }
    }
}