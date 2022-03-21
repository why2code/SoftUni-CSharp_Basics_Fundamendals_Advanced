using System;
using System.Linq;

namespace MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int magicNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int k = i + 1; k < numbers.Length; k++)
                {
                    int summedValues = numbers[i] + numbers[k];
                    if (summedValues == magicNumber)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[k]}");
                    }
                }
            }

        }
    }
}
