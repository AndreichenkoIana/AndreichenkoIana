namespace Seminar1
{
    public class ArrayDifference
    {
        public static int[] SubtractArrays(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
            {
                throw new ArgumentException("Длины массивов не равны.");
            }

            int[] resultArray = new int[array1.Length];

            for (int i = 0; i < array1.Length; i++)
            {
                resultArray[i] = array1[i] - array2[i];
            }

            return resultArray;
        }
    }
}
