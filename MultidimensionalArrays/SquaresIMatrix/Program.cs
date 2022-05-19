using System;
using System.Linq;

namespace SquaresIMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = ranges[0];
            int cols = ranges[1];

            string[,] matrix = new string[rows, cols];
            FillDataIntoMatrix(matrix, rows, cols, " ");

            int squaresCounter = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i,j] == matrix[i, j + 1]
                        && matrix[i,j] == matrix[i + 1, j]
                        && matrix[i,j] == matrix[i + 1, j + 1])
                    {
                        squaresCounter++;
                    }
                }
            }

            Console.WriteLine(squaresCounter);

        }

        private static void FillDataIntoMatrix(string[,] matrix, int rows, int cols, string splitter)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split(splitter);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }

            }
        }

    }
}
