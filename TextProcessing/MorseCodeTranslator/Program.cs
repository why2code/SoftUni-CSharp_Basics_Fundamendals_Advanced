using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] moreseCodeWords = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder words = new StringBuilder();


            for (int i = 0; i < moreseCodeWords.Length; i++)
            {
                string[] word = moreseCodeWords[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);


                foreach (string letter in word)
                {
                    string ch = GetLetterFromMorese(letter);
                    words.Append(ch);
                }
                words.Append(' ');
            }

            string result = words.ToString().ToUpper().TrimEnd();
            Console.WriteLine(result);


        }
        static string GetLetterFromMorese(string morseCodeLetter)
        {
            string ch = null;
            Dictionary<char, string> morseCode = new Dictionary<char, string>()
            {
                {'A' , ".-"},
                {'B' , "-..."},
                {'C' , "-.-."},
                {'D' , "-.."},
                {'E' , "."},
                {'F' , "..-."},
                {'G' , "--."},
                {'H' , "...."},
                {'I' , ".."},
                {'J' , ".---"},
                {'K' , "-.-"},
                {'L' , ".-.."},
                {'M' , "--"},
                {'N' , "-."},
                {'O' , "---"},
                {'P' , ".--."},
                {'Q' , "--.-"},
                {'R' , ".-."},
                {'S' , "..."},
                {'T' , "-"},
                {'U' , "..-"},
                {'V' , "...-"},
                {'W' , ".--"},
                {'X' , "-..-"},
                {'Y' , "-.--"},
                {'Z' , "--.."}

            };
            var existsInKey = morseCode.Any(x => x.Value == morseCodeLetter);
            if (existsInKey)
            {
                char[] foundKey = morseCode.Where(x => x.Value == morseCodeLetter).Select(x => x.Key).ToArray();
                ch = foundKey[0].ToString();
                return ch;

            }

            return ch;
        }
    }
}