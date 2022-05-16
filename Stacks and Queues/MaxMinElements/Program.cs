using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxMinElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                int[] commArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int typeOfCommand = commArgs[0];
                if (typeOfCommand == 1)
                {
                    int pushingNum = commArgs[1];
                    stack.Push(pushingNum);

                }
                else if (typeOfCommand == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (typeOfCommand == 3)
                {
                    if (stack.Count > 0)
                    {
                        List<int> sortedStack = stack.OrderByDescending(x => x).ToList();
                        Console.WriteLine($"{sortedStack[0]}");
                    }
                }
                else if (typeOfCommand == 4)
                {
                    if (stack.Count > 0)
                    {
                        List<int> sortedStack = stack.OrderBy(x => x).ToList();
                        Console.WriteLine($"{sortedStack[0]}");
                    }
                }
            }


            for (int i = 0; i < stack.Count; i++)
            {

                if (i == stack.Count - 1)
                {
                    var numToPrint = stack.Pop();
                    Console.Write($"{numToPrint}");
                }
                else
                {
                    var numToPrint = stack.Pop();
                    Console.Write($"{numToPrint}, ");
                }
                i--;
            }
        }
    }
}
