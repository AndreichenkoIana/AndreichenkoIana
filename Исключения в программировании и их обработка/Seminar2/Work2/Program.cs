namespace Work2
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                float userInput = GetFloatFromUser();
                Console.WriteLine($"Вы ввели число: {userInput}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static float GetFloatFromUser()
        {
            while (true)
            {
                Console.Write("Пожалуйста, введите дробное число: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new ArgumentException("Пустые строки вводить нельзя.");
                }

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
