using System;

namespace CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int sumTotal = 0;

            if (input[0].Length >= input[1].Length)
            {
                for (int i = 0; i < input[1].Length; i++)
                {
                    sumTotal += input[1][i] * input[0][i];
                }

                for (int i = input[1].Length; i < input[0].Length; i++)
                {
                    sumTotal += input[0][i];
                }
            }
            else //input[0].Length < input[1].Length
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    sumTotal += input[0][i] * input[1][i];
                }

                for (int i = input[0].Length; i < input[1].Length; i++)
                {
                    sumTotal += input[1][i];
                }
            }

            Console.WriteLine(sumTotal);
        }

    }
}
