using System;

public class Labirynth
{
    private static int[] rowDirections = { -1, 1, 0, 0 };
    private static int[] colDirections = { 0, 0, -1, 1 };

    public static int CountExits(int startI, int startJ, int[,] labirynth)
    {
        int rows = labirynth.GetLength(0);
        int cols = labirynth.GetLength(1);
        bool[,] visited = new bool[rows, cols];
        return DFS(startI, startJ, labirynth, visited, rows, cols);
    }

    private static int DFS(int i, int j, int[,] labirynth, bool[,] visited, int rows, int cols)
    {
        // Проверяем, находится ли текущая позиция за пределами лабиринта или является стеной
        if (i < 0 || i >= rows || j < 0 || j >= cols || labirynth[i, j] == 1 || visited[i, j])
        {
            return 0;
        }

        // Если текущая позиция на границе лабиринта и является проходимой (значение 0), считаем это выходом
        if ((i == 0 || i == rows - 1 || j == 0 || j == cols - 1) && labirynth[i, j] == 0)
        {
            return 1;
        }

        // Отмечаем текущую ячейку как посещенную
        visited[i, j] = true;

        int exits = 0;

        // Пытаемся двигаться в четырех направлениях: вверх, вниз, влево и вправо
        for (int direction = 0; direction < 4; direction++)
        {
            int newRow = i + rowDirections[direction];
            int newCol = j + colDirections[direction];
            exits += DFS(newRow, newCol, labirynth, visited, rows, cols);
        }

        return exits;
    }
}
