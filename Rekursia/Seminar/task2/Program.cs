using system;
internal class Program
{
    void main()
    {
        int number = ReadInt("Введите число: ");
        Console.WriteLine(SumDigitsOfNumber(number));
    }

    int SumDigitsOfNumber(int n)
    {
        if(n < 1)
        {
            return 0;
        }
        return n % 10 + SumDigitsOfNumber(n / 10;)
    }
    int ReadInt(string msg)
    {
        Console.Write(msg);
        return Convert.ToInt32(Console.ReadLine());
    }
}