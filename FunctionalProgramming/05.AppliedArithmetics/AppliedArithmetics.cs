using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    internal class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //Func<int[], int[]> add(int[] nums)
            //{
            //    int[] res = new int[nums.Length];
            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        res[i] = nums[i] + 1;
            //    }
            //    nums = res;
            //    //return nums;
            //}

            Func<int, int> add = x => x += 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x -= 1;

            //Action<int[]> printingCollection(int[] collection)
            //{
            //    foreach (var item in collection)
            //    {
            //        Console.Write($"{item} ");
            //    }
            //    return null;
            //}

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = add(numbers[i]);
                    }
                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = multiply(numbers[i]);
                    }
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = subtract(numbers[i]);
                    }
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
