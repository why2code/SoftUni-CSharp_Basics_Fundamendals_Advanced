using System;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string coins = "";
            string product = "";
            double totalCashToSpend = 0;
            double productPrice = 0;
            bool checkerCoins = false;

            while (coins != "Start")
            {
                coins = Console.ReadLine();
                if (coins == "Start")
                {
                    break;
                }
                switch (coins)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2":
                        totalCashToSpend += double.Parse(coins);
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coins}");
                        break;
                }

            }

            while (product != "End")
            {
                product = Console.ReadLine();
                if (product == "End")
                {
                    break;
                }
                switch (product)
                {
                    case "Nuts":
                        productPrice = 2;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                if ((totalCashToSpend >= productPrice) && (product == "Nuts" || product == "Water" || product == "Crisps" ||
                    product == "Soda" || product == "Coke"))
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    totalCashToSpend -= productPrice;
                }
                else if ((totalCashToSpend < productPrice) && (product == "Nuts" || product == "Water" || product == "Crisps" ||
                    product == "Soda" || product == "Coke"))
                {
                    Console.WriteLine("Sorry, not enough money");
                }

            }

            if (product == "End" && totalCashToSpend >= 0)
            {
                Console.WriteLine($"Change: {totalCashToSpend:f2}");
            }


        }
    }
}
