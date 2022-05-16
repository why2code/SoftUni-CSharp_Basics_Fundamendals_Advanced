using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations_threeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

            int elementsToPushN = items[0];
            int elementsToPopS = items[1];
            int elementToSearchX = items[2];

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < elementsToPushN; i++)
            {
                stack.Push(nums[i]);
            }


            for (int i = 0; i < elementsToPopS; i++)
            {

                if (stack.Count > 0)
                {
                    stack.Pop();
                }

            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (stack.Contains(elementToSearchX))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    List<int> array = stack.ToList();
                    array.OrderByDescending(x => x).ToList();
                    int smallestValue = array[0];
                    Console.WriteLine(smallestValue);
                }
            }






        }
    }
}
