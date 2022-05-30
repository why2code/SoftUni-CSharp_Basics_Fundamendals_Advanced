using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    internal class CustomMinFunction
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Func<int[], int> minNumber = x => x.Min();
            Console.WriteLine(minNumber(input));
        }
    }
}
