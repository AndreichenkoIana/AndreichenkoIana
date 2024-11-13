namespace Seminar1
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                int[] array1 = { 5, 10, 15 };
                int[] array2 = { 3, 6, 9, 10};

                int[] resultArray = ArrayDifference.SubtractArrays(array1, array2);

                Console.WriteLine("Результирующий массив:");
                foreach (int value in resultArray)
                {
                    Console.Write(value + " ");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
