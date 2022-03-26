using System;
using System.Collections.Generic;
using System.Numerics;

namespace MinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, BigInteger> resourses = new Dictionary<string, BigInteger>();
            string currentResource = Console.ReadLine();

            while (currentResource != "stop")
            {
                BigInteger value = BigInteger.Parse(Console.ReadLine());

                if (!resourses.ContainsKey(currentResource))
                {
                    resourses.Add(currentResource, value);
                }
                else
                {
                    resourses[currentResource] += value;
                }

                currentResource = Console.ReadLine();

            }

            foreach (var resource in resourses)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
