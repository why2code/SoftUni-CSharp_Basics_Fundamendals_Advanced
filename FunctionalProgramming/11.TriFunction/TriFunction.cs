using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.TriFunction
{
    internal class TriFunction
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Console.WriteLine(names.First(x => x.Select(symbol => (int) symbol).Sum() >= number));
        }
    }
}
