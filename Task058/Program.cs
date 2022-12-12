// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],5}, ");
            else Console.Write($"{matrix[i, j],5}");
        }
        Console.WriteLine("]");
    }
}

int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] matrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            matrix[i, j] = 0;
            for (int m = 0; m < matrix2.GetLength(0); m++)
            {
                matrix[i, j] += matrix1[i, m] * matrix2[m, j];
            }
        }
    }
    return matrix;
}

Console.Write("Enter the number of rows of the first matrix -> ");
int row1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the number of columns of the first matrix -> ");
int col1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the number of rows of the second matrix -> ");
int row2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the number of columns of the second matrix -> ");
int col2 = Convert.ToInt32(Console.ReadLine());

int[,] matrix1 = CreateMatrixRndInt(row1, col1, 2, 4);
int[,] matrix2 = CreateMatrixRndInt(row2, col2, 2, 4);
PrintMatrix(matrix1);
Console.WriteLine(" ");
PrintMatrix(matrix2);

if (matrix1.GetLength(1) == matrix2.GetLength(0))
{
    int[,] result = MultiplicationMatrix(matrix1, matrix2);
    Console.WriteLine("Multiplication result");
    PrintMatrix(result);
}
else Console.WriteLine("Multiplication of these matrices is not possible");