using System;
using System.Linq;

namespace MatrixShuffling
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

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeOfCommand = commArgs[0];

                if (typeOfCommand == "swap" && commArgs.Length == 5)
                {
                    int row1 = int.Parse(commArgs[1]);
                    int col1 = int.Parse(commArgs[2]);
                    int row2 = int.Parse(commArgs[3]);
                    int col2 = int.Parse(commArgs[4]);

                    if (VerifyIfIndexIsWithinMatrix(matrix, row1, col1, row2, col2))
                    {
                        string tempValue = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = tempValue;

                        MatrixPrintout(matrix, " ");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }


        private static void FillDataIntoMatrix(string[,] matrix, int rows, int cols, string splitter)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }

            }
        }

        private static bool VerifyIfIndexIsWithinMatrix(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            if (row1 >= 0 && row1 < matrix.GetLength(0)
                && col1 >= 0 && col1 < matrix.GetLength(1)
                && row2 >= 0 && row2 < matrix.GetLength(0)
                && col2 >= 0 && col2 < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void MatrixPrintout(string[,] matrix, string splitter)
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
