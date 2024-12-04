public class Answer
{
    public int sumDigits(int n)
    {
// Введите свое решение ниже
        int sum = 0;
        while (n != 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }

}
