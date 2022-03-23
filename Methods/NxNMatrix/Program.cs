using System;

namespace NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixNumber = int.Parse(Console.ReadLine());
            PrintMatrix(matrixNumber);
        }

        static void PrintMatrix(int matrixNumber)
        {
            for (int i = 0; i < matrixNumber; i++)
            {
                for (int j = 0; j < matrixNumber; j++)
                {
                    if (j == matrixNumber - 1)
                    {
                        Console.Write($"{matrixNumber}");

                    }
                    else
                    {
                        Console.Write($"{matrixNumber} ");

                    }
                }

                Console.WriteLine();

            }
        }
    }
}
