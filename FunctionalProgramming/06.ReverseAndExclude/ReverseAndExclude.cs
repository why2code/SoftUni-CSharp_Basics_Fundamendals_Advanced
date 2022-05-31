using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int specialDivider = int.Parse(Console.ReadLine());

            Func<int[], int, int[]> clensedArray = (nums,specialNum) =>
            {
                int[] temp = nums.Where(x => x % specialNum != 0).ToArray();
                return nums = temp.Reverse().ToArray();
            };

            inputNumbers = clensedArray(inputNumbers, specialDivider);
            foreach (var numClensed in inputNumbers)
            {
                Console.Write($"{numClensed} ");
            }

        }
    }
}
