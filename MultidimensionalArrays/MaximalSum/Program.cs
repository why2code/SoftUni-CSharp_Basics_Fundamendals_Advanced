using System;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = ranges[0];
            int cols = ranges[1];

            long[,] matrix = new long[rows, cols];
            FillDataIntoMatrix(matrix, rows, cols, " ");

            long maxSumValue = long.MinValue;
            int rowIndex = -1;
            int colIndex = -1;

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    long currentMaxValue = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 2, j] + matrix[i + 1, j + 1] + matrix[i + 2, j + 1]
                        + matrix[i + 1, j + 2] + matrix[i + 2, j + 2];

                    if (currentMaxValue > maxSumValue)
                    {
                        rowIndex = i;
                        colIndex = j;
                        maxSumValue = currentMaxValue;
                    }
                }
            }

            if (maxSumValue == int.MinValue)
            {
                return;
            }
            else
            {
                Console.WriteLine("Sum = " + maxSumValue);
                // printing the Matrix
                for (int i = rowIndex; i <= rowIndex + 2; i++)
                {
                    for (int j = colIndex; j <= colIndex + 2; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

        }


        private static void FillDataIntoMatrix(long[,] matrix, int rows, int cols, string splitter)
        {
            for (int i = 0; i < rows; i++)
            {
                long[] input = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }

            }
        }
    }
}
