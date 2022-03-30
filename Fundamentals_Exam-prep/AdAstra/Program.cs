using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textInput = Console.ReadLine();
            int caloriesRequired = 2000;
            int caloriesAvailable = 0;

            string pattern = @"([\#|\|])(?<item>[A-Za-z\s]+)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>\d+)\1";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(textInput);

            if (matches.Count == 0)
            {
                Console.WriteLine("You have food to last you for: 0 days!");
            }
            else
            {
                foreach (Match match in matches)
                {
                    caloriesAvailable += int.Parse(match.Groups["calories"].Value);
                }

                int daysWithAvailableSupplies = caloriesAvailable / caloriesRequired;

                Console.WriteLine($"You have food to last you for: {daysWithAvailableSupplies} days!");
                foreach (Match match in matches)
                {
                    string product = match.Groups["item"].Value;
                    string bestBefore = match.Groups["date"].Value;
                    string nutrition = match.Groups["calories"].Value;
                    Console.WriteLine($"Item: {product}, Best before: {bestBefore}, Nutrition: {nutrition}");
                }



            }

        }
    }
}
