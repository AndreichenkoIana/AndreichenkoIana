using System;
using System.Globalization;
using System.IO;
namespace Work;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Введите данные в формате: Фамилия Имя Отчество Дата_рождения Номер_телефона Пол");
        string input = Console.ReadLine();
        ValidateMessage.Validate(input);
    }
}
