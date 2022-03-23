using System;
using System.Numerics;

namespace FactorielDevision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"{FactorielDevision(firstNumber, secondNumber):F2}");
        }

        static double FactorielDevision(int a, int b)
        {
            double factorielOne = 1;
            double factorielTwo = 1;

            if (a == 0)
            {
                factorielOne = 1;
            }
            else
            {
                for (int i = 1; i <= a; i++)
                {
                    factorielOne *= (double)i;
                }
            }

            if (b == 0)
            {
                factorielTwo = 1;
            }
            else
            {
                for (int j = 1; j <= b; j++)
                {
                    factorielTwo *= (double)j;
                }
            }

            return factorielOne / factorielTwo;
        }
    }
}
