namespace Work1
{
    internal class Program
    {
        static void Main()
        {
            float userInput = GetFloatFromUser();
            Console.WriteLine($"Вы ввели число: {userInput}");
        }

        static float GetFloatFromUser()
        {
            while (true)
            {
                Console.Write("Пожалуйста, введите дробное число: ");
                string input = Console.ReadLine();

                if (float.TryParse(input, out float result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                }
            }
        }
    }
}
