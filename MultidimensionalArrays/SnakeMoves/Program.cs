using System;
using System.Linq;

namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = ranges[0];
            int cols = ranges[1];
            string snakeText = Console.ReadLine();

            char[,] matrix = new char[rows, cols];

            int snakeIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = snakeText[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex == snakeText.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snakeText[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex == snakeText.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
            }

            MatrixPrintout(matrix, "");

        }

       

        private static void MatrixPrintout(char[,] matrix, string splitter)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + splitter);
                }
                Console.WriteLine();
            }
        }

    }
}
