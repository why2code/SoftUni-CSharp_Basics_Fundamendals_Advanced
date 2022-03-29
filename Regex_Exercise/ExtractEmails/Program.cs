using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:[\s])\b(?<userName>[A-Za-z0-9]+[\.|\-|_]*[A-Za-z0-9]+\@{1})(?<host>[A-Za-z]+\-*[A-Za-z]*\.{1}[A-Za-z]+\.*[A-Za-z]*)\b";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.Write(match.Groups["userName"].Value);
                    Console.Write(match.Groups["host"].Value);
                    Console.WriteLine();
                }

            }

        }
    }
}
