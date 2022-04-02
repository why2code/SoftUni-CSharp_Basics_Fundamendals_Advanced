using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            string pattern = @"\@\#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])\@\#+";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < counter; i++)
            {
                string currentBarcode = Console.ReadLine();
                Match match = regex.Match(currentBarcode);

                if (match.Success)
                {
                    string productGroup = null;
                    bool digitFound = false;
                    string barcode = match.Groups["barcode"].Value;

                    foreach (char item in barcode)
                    {
                        if (char.IsDigit(item))
                        {
                            productGroup += item;
                            digitFound = true;
                        }
                    }

                    if (digitFound == true)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
