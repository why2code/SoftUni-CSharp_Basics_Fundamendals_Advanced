using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    internal class PredicateForNames
    {
        static void Main(string[] args)
        {
            int lenghtOfNames = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> matchingName = name => name.Length <= lenghtOfNames;
            foreach (var name in names)
            {
                if (matchingName(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
