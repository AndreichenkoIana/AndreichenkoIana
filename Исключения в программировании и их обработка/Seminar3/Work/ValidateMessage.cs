using System.Globalization;

namespace Work;
internal class ValidateMessage()
{
    internal static void Validate(string input)
    {
        string[] parts = input.Split(' ');
        // Проверка количества введенных данных
        if (parts.Length != 6)
        {
            Console.WriteLine("Ошибка: введено " + (parts.Length < 6 ? "меньше" : "больше") + " данных, чем требуется.");
        }
        else
        {
            try
            {
                string lastName = parts[0];
                string firstName = parts[1];
                string patronymic = parts[2];

                // Проверка и парсинг даты рождения
                if (!DateTime.TryParseExact(parts[3], "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
                {
                    throw new FormatException("Неверный формат даты рождения. Ожидаемый формат: dd.MM.yyyy.");
                }

                // Проверка и парсинг номера телефона
                if (!long.TryParse(parts[4], out long phoneNumber))
                {
                    throw new FormatException("Неверный формат номера телефона. Ожидается целое беззнаковое число.");
                }

                // Проверка пола
                char gender = parts[5][0];
                if (gender != 'f' && gender != 'm')
                {
                    throw new ArgumentException("Пол должен быть 'f' или 'm'.");
                }

                // Запись данных в файл
                WriteToFile.WriteFile(lastName, firstName, patronymic, birthDate, phoneNumber, gender);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}
