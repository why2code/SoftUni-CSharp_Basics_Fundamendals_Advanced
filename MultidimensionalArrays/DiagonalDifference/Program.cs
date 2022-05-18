using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = values[j];
                }
            }

            int diagonalOne = 0;
            int diagonalTwo = 0;

            for (int i = 0; i < n; i++)
            {
                diagonalOne += matrix[i,i];
            }

            for (int j = 0; j < n; j++)
            {
                diagonalTwo += matrix[j, n - j - 1];
            }

            Console.WriteLine($"{Math.Abs(diagonalOne - diagonalTwo):F0}");
        }
    }
}
