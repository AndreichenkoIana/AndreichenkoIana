using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    internal class WriteToFile
    {
        internal static void WriteFile(string lastName, string firstName, string patronymic, DateTime birthDate, long phoneNumber, char gender)
        {
            // Удаление недопустимых символов из имени файла
            char[] invalidChars = Path.GetInvalidFileNameChars();
            string safeLastName = new string(lastName.Where(c => !invalidChars.Contains(c)).ToArray());

            string fileName = safeLastName + ".txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine($"{lastName} {firstName} {patronymic} {birthDate:dd.MM.yyyy} {phoneNumber} {gender}");
                    Console.WriteLine("Данные успешно записаны в файл: " + fileName);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ошибка записи в файл: " + e.Message);
            }
        }
    }
}
