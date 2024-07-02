using System;

int[,] CreateMatrix(int rowCount, int columnsCount)
{
    int[,] matrix = new int[rowCount, columnsCount];

    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {

            matrix[i, j] = rnd.Next(1, 1000);
        }
    }
    return matrix;
}

bool IsInteresting(int value)
{
    int sumOfDgits = GetSumOfDigits(value);
    if (sumOfDgits % 2 == 0)
    {
        return true;
    }
    return false;
}
int GetSumOfDigits (int value)
{
    int sum = 0;
    while (value > 0)
    {
        sum = sum + value % 10;
        value = value / 10;
    }
    return sum;
}

void ShowMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {

            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}
int[,] matrix = CreateMatrix(3,4);
ShowMatrix(matrix);
foreach (int e in matrix)
{
    if (IsInteresting(e) == true)
    {
        Console.WriteLine(e);
    }
}
