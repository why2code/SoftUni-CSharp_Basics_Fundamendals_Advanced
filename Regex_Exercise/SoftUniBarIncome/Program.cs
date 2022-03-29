using System;
using System.Text.RegularExpressions;

namespace SoftuniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            //string pattern = @"^(?:[^%]*)[%]{1}(?<customer>[A-Z]{1}[a-z]+)[%]{1}(?:[^<]*)[<]{1}(?<product>[A-Za-z]+)[>]{1}(?:[^|]*)[|](?<count>\d+)[|]{1}(?:[^0-9]*)(?<price>\d+(\.\d+)?)[$]{1}$";
            string pattern = @"\%(?<customer>[A-Z]{1}[a-z]+)\%[^%$|.]*?\<(?<product>\w+)\>[^%$|.]*?\|(?<count>\d+)\|[^%$|.]*?(?<price>\d+(\.\d+)?)\$";
            decimal totalIncome = 0;

            while (input != "end of shift")
            {
                Regex reg = new Regex(pattern);
                var matchedGroups = reg.Match(input);

                string person = null;
                string product = null;
                string quantity = null;
                string value = null;


                if (matchedGroups.Success)
                {
                    person = matchedGroups.Groups["customer"].Value;
                    product = matchedGroups.Groups["product"].Value;
                    quantity = matchedGroups.Groups["count"].Value;
                    value = matchedGroups.Groups["price"].Value;

                    //if (person != ""
                    //    && product != ""
                    //    && quantity != ""
                    //    && value != "")
                    //{
                    decimal lineExpenses = decimal.Parse(quantity) * decimal.Parse(value);
                    totalIncome += lineExpenses;
                    Console.WriteLine($"{person}: {product} - {lineExpenses:F2}");
                    //}

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");


        }
    }
}
