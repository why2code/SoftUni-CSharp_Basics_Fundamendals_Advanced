using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> nonLetters = new Dictionary<char, int>();
            Dictionary<char, int> upperLetters = new Dictionary<char, int>();
            Dictionary<char, int> lowerLetters = new Dictionary<char, int>();

            foreach (char ch in text)
            {
                if (Char.IsLetter(ch) && Char.IsUpper(ch))
                {
                    VerifyIfContainedInDictionary(upperLetters, ch);
                }
                else if (Char.IsLetter(ch) && Char.IsLower(ch))
                {
                    VerifyIfContainedInDictionary(lowerLetters, ch);

                }
                else
                {
                    VerifyIfContainedInDictionary(nonLetters, ch);
                }
            }

            PrintDictionary(nonLetters);
            PrintDictionary(upperLetters);
            PrintDictionary(lowerLetters);

        }



        static void VerifyIfContainedInDictionary(Dictionary<char, int> dictionary, char ch)
        {
            if (!dictionary.ContainsKey(ch))
            {
                dictionary.Add(ch, 1);
            }
            else
            {
                dictionary[ch]++;
            }
        }

        static void PrintDictionary(Dictionary<char, int> dictionary)
        {
            foreach (var ch in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
