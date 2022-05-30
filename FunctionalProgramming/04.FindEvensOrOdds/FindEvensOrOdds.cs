using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    internal class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string typeOfNumbers = Console.ReadLine();
            int startRange = range[0];
            int endRange = range[1];

            Predicate<int> isOdd = x => x % 2 != 0;
            Predicate<int> isEven = x => x % 2 == 0;

            for (int i = startRange; i <= endRange; i++)
            {
                if (typeOfNumbers == "odd")
                {
                    if (isOdd(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
                else if (typeOfNumbers == "even")
                {
                    if (isEven(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
            }

        }
    }
}
