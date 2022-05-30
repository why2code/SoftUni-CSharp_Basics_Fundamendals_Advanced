using System;
using System.Linq;

namespace _01.ActionPrint
{
    internal class ActionPrint
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Action<string> printer = x => PrintArray(x);
            printer(input);
        }

        private static void PrintArray(string input)
        {
            string[] names = input.Split(' ');
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
