using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    internal class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            HashSet<int> numbersDevidedSuccessfully = new HashSet<int>();
            Func<int, List<int>, HashSet<int>> verifyDividing = (endRange, dividers) =>
            {
                HashSet<int> ints = new HashSet<int>();
               
                for (int i = 0; i < dividers.Count; i++)
                {
                    if (endRange == 1 && dividers.Contains(1))
                    {
                        ints.Add(1);
                        break;
                    }
                    for (int j = 1; j <= endRange; j++)
                    {
                        if (j % dividers[i] == 0)
                        {
                            ints.Add(j);
                        }
                        else
                        {
                            if (ints.Contains(j))
                            {
                                ints.Remove(j);
                            }
                        }
                    }
                }
                return ints;
            };

            numbersDevidedSuccessfully = verifyDividing(endOfRange, dividers);
            foreach (var num in numbersDevidedSuccessfully)
            {
                Console.Write($"{num} ");
            }
        }
    }
}
