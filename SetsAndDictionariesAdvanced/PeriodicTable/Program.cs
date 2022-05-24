using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> uniqueChemicalElements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicalElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < chemicalElements.Length; j++)
                {
                    uniqueChemicalElements.Add(chemicalElements[j]);
                }
            }

            foreach (var element in uniqueChemicalElements.OrderBy(x => x))
            {
                Console.Write(element + " ");
            }
        }
    }
}
