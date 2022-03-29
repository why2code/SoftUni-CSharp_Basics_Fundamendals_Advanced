using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, decimal> validItems = new Dictionary<string, decimal>();
            List<string> items = new List<string>();
            string pattern = @"[>]{2}(?<name>[A-Za-z]+)[<]{2}(?<price>\d+(\.\d+)?)\!(?<quantity>\d+)";
            decimal totalCost = 0;


            while (input != "Purchase")
            {
                Match isValid = Regex.Match(input, pattern);

                if (isValid.Success)
                {
                    string productName = isValid.Groups["name"].Value;
                    decimal price = decimal.Parse(isValid.Groups["price"].Value);
                    int quantity = int.Parse(isValid.Groups["quantity"].Value);

                    items.Add(productName);
                    totalCost += price * quantity;
                
                }

                input = Console.ReadLine();
            }



            Console.WriteLine("Bought furniture:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalCost:f2}");



        }
    }
}
