using System;
using System.Text.RegularExpressions;

namespace MessageDecrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            string pattern = @"^([\$|\%]{1})(?<tag>[A-Z][a-z]{2,})\1\:\s{1}\[(?<first>[0-9]+)\]\|\[(?<second>[0-9]+)\]\|\[(?<third>[0-9]+)\]\|$";
            Regex regex = new Regex(pattern);
            
            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();
                
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string tag = match.Groups["tag"].Value;
                    int firstNumber = int.Parse(match.Groups["first"].Value);
                    int secondNumber = int.Parse(match.Groups["second"].Value);
                    int thirdNumber = int.Parse(match.Groups["third"].Value);

                    char ch1 = (char)firstNumber;
                    char ch2 = (char)secondNumber;
                    char ch3 = (char)thirdNumber;

                    Console.WriteLine($"{tag}: {ch1}{ch2}{ch3}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
