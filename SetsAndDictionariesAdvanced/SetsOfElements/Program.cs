using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] nm = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = nm[0];
            int m = nm[1];
            
            HashSet<int> numsOne = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numsOne.Add(number);
            }

            HashSet<int> numsTwo = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numsTwo.Add(number);
            }


            List<int> matchingNumbers = new List<int>();
            foreach (var num in numsOne)
            {
                if (numsTwo.Contains(num))
                {
                    matchingNumbers.Add(num);
                }
            }

            foreach (var num in matchingNumbers)
            {
                Console.Write(num + " ");
            }
        }
    }
}
