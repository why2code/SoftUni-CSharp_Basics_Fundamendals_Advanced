using System;

namespace _02.KnigtsOfHonor
{
    internal class KnigtsOfHonor
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Action<string> printer = x => PrintAmendedNames(x);
            printer(input);
        }

        private static void PrintAmendedNames(string input)
        {
            string[] names = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
