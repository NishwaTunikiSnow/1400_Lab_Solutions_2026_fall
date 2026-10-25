// Name: [Your Name]
// Homework: Homework 5 - Two Dimensional Array Methods (Solution)
// Date: [Submission Date]

using System;

class Program
{
    static void PrintMatrix(int[,] matrix)
    {
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                Console.Write($"{matrix[r, c],2} ");
            }
            Console.WriteLine();
        }
    }

    static int SumMatrix(int[,] matrix)
    {
        int total = 0;
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                total += matrix[r, c];
            }
        }
        return total;
    }

    static int[] RowSums(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] sums = new int[rows];

        for (int r = 0; r < rows; r++)
        {
            int rowTotal = 0;
            for (int c = 0; c < cols; c++)
            {
                rowTotal += matrix[r, c];
            }
            sums[r] = rowTotal;
        }

        return sums;
    }

    static int[] ColumnSums(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] sums = new int[cols];

        for (int c = 0; c < cols; c++)
        {
            int colTotal = 0;
            for (int r = 0; r < rows; r++)
            {
                colTotal += matrix[r, c];
            }
            sums[c] = colTotal;
        }

        return sums;
    }

    static int FindMax(int[,] matrix)
    {
        int max = matrix[0, 0];

        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                if (matrix[r, c] > max)
                {
                    max = matrix[r, c];
                }
            }
        }

        return max;
    }

    static int[,] Transpose(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[cols, rows];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                result[c, r] = matrix[r, c];
            }
        }

        return result;
    }

    static int DiagonalSum(int[,] matrix)
    {
        int total = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            total += matrix[i, i];
        }
        return total;
    }

    static void PrintArray(int[] values)
    {
        foreach (int v in values)
        {
            Console.Write(v + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[,] matrix = {
            { 8, 3, 6 },
            { 1, 9, 4 },
            { 7, 2, 5 }
        };

        Console.WriteLine("Matrix:");
        PrintMatrix(matrix);

        Console.WriteLine("\nSum of matrix: " + SumMatrix(matrix));

        Console.Write("Row sums: ");
        PrintArray(RowSums(matrix));

        Console.Write("Column sums: ");
        PrintArray(ColumnSums(matrix));

        Console.WriteLine("Max value: " + FindMax(matrix));

        Console.WriteLine("Transpose:");
        PrintMatrix(Transpose(matrix));

        Console.WriteLine("Diagonal sum: " + DiagonalSum(matrix));
    }
}
