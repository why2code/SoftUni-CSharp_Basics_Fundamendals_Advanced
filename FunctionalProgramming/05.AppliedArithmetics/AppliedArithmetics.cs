using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    internal class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int[]> addComplex
                = (nums) =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = nums[i] + 1;
                }
                return nums;
            };

            Func<int[], int[]> multiplyComplex
             = (nums) =>
             {
                 for (int i = 0; i < nums.Length; i++)
                 {
                     nums[i] = nums[i] * 2;
                 }
                 return nums;
             };

            Func<int[], int[]> subtractComplex
            = (nums) =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = nums[i] - 1;
                }
                return nums;
            };

           
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    addComplex(numbers);
                }
                else if (command == "multiply")
                {
                    multiplyComplex(numbers);
                }
                else if (command == "subtract")
                {
                    subtractComplex(numbers);
                }
                else if (command == "print")
                {
                    foreach (var item in numbers)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }
        }
    }
}
