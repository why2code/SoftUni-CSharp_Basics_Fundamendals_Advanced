using System;
using System.Collections;
using System.Collections.Generic;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> set = new HashSet<int>();
            List<int> evenNumOccurences = new List<int>();


            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!set.Add(currentNumber))
                {

                    if (evenNumOccurences.Contains(currentNumber))
                    {
                        evenNumOccurences.Remove(currentNumber);
                    }
                    else
                    {
                        evenNumOccurences.Add(currentNumber);
                    }

                }
            }

            //If only 1 item is provided, print directly from the HashSet
            if (set.Count == 1)
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {

                foreach (var item in evenNumOccurences)
                {
                    Console.WriteLine(item);
                }

            }
        }
    }
}
