using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                //simple syntaxis filling in the matrix
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                ////Long syntaxis breaking down element by element array fill with data
                //int[] cols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                //matrix[i] = new int[cols.Length];
                //for (int j = 0; j < cols.Length; j++)
                //{
                //    matrix[i][j] = cols[j];
                //}
            }

            //Analysing the matrix
            for (int i = 0; i < rows - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                int rowToManipulate = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                int colsToManipulate = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                int value = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[3]);

                if (VerifyJaggedMatrixIndexes(matrix, rows, rowToManipulate, colsToManipulate))
                {
                    if (command.StartsWith("Add"))
                    {
                        matrix[rowToManipulate][colsToManipulate] += value;
                    }
                    else if (command.StartsWith("Subtract"))
                    {
                        matrix[rowToManipulate][colsToManipulate] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            //Printing jagged matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }


        private static bool VerifyJaggedMatrixIndexes(int[][] matrix, int matrixRows, int rowIndexValidated, int colIndexValidated)
        {
            if (rowIndexValidated >= 0 && rowIndexValidated < matrixRows
                && colIndexValidated >= 0 && colIndexValidated < matrix[rowIndexValidated].Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
