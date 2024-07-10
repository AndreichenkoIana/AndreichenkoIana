using system;
internal class Program
{
    private static void Main(string[] args)
    {
        void main()
        {
            int number = ReadInt("Введите число: ");
            for (int i = 1; i <= number; i++)
            {
                Console.Write(i + "  ");
            }
}

        int ReadInt(string msg)
        {
            Console.Write(msg);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}