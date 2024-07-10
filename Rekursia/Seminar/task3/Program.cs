using system;
internal class Program
{
    void main()
    {
        Console.Write("Введите текст: ");
        string? inputText = Console.ReadLine();
        PrintConsonants(inputText);
    }

    void PrintConsonants(string? str)
    {
        if(str.Length < 1)
        {
            return;
        }
        char tempChar = char.ToLower(str[0]);
        if(isConsonant(tempChar))
        {
            Console.Write(str[0] = " ");
        }
        PrintConsonants(str[1..]);
    }
    bool isConsonant(char c)
    {
        return "bcdfghjklmnpqrstvwxz".Contains(c);
    }
}