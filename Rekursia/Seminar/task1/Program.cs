//for (int i = 1; i <= number; i++)
// {
//    Console.Write(i + "  ");
//}

using system;
internal class Program
{
    void main()
    {
        int number = ReadInt("Введите число: ");
        PrintNumber(number);
    }

    void PrintNumber (int N)
    {
        if(N < 1)
        {
            return;
        }
        Console.Write(N + " ");
        PrintNumber(N - 1);
    }
    int ReadInt(string msg)
    {
        Console.Write(msg);
        return Convert.ToInt32(Console.ReadLine());
    }
}