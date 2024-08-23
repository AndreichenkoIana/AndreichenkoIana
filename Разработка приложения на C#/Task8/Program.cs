using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Использование: Program.exe <расширение> <текст>");
            return;
        }

        string extension = args[0];
        string searchText = args[1];
        string currentDirectory = Directory.GetCurrentDirectory();

        Console.WriteLine($"Поиск файлов с расширением .{extension} и текстом \"{searchText}\" в каталоге {currentDirectory}...");

        SearchFiles(currentDirectory, extension, searchText);
    }

    static void SearchFiles(string directory, string extension, string searchText)
    {
        try
        {
            foreach (var file in Directory.GetFiles(directory, $"*.{extension}"))
            {
                if (FileContainsText(file, searchText))
                {
                    Console.WriteLine($"Файл найден: {file}");
                }
            }

            foreach (var subdirectory in Directory.GetDirectories(directory))
            {
                SearchFiles(subdirectory, extension, searchText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при доступе к каталогу {directory}: {ex.Message}");
        }
    }

    static bool FileContainsText(string filePath, string searchText)
    {
        try
        {
            string content = File.ReadAllText(filePath);
            return content.Contains(searchText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла {filePath}: {ex.Message}");
            return false;
        }
    }
}
