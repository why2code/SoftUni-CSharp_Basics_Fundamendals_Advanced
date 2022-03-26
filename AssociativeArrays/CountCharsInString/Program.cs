using System;
using System.Collections.Generic;
using System.Linq;

namespace CountChairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] charDerivedFromWords = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();

            Dictionary<char, int> countedLetters = new Dictionary<char, int>();


            foreach (char character in charDerivedFromWords)
            {
                if (!countedLetters.ContainsKey(character))
                {
                    countedLetters.Add(character, 1);
                }
                else
                {
                    countedLetters[character] += 1;
                }
            }

            foreach (var item in countedLetters)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
