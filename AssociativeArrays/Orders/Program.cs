using System;
using System.Collections.Generic;

namespace Orders
{
    public class Product
    {
        public Product(double price, double quantity)
        {
            this.Price = price;
            this.Quantity = quantity;
        }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double TotalPrice { get; set; }
        public double CalculateTotalPrice(double price, double quantity)
        {
            return this.TotalPrice = price * quantity;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> listOfProducts = new Dictionary<string, Product>();

            string command = Console.ReadLine();
            while (command != "buy")
            {
                string[] separatedCommants = command.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string nameOfProduct = separatedCommants[0];
                double priceOfProduct = double.Parse(separatedCommants[1]);
                double quantityOfProduct = double.Parse(separatedCommants[2]);

                if (!listOfProducts.ContainsKey(nameOfProduct))
                {
                    Product prodToAdd = new Product(priceOfProduct, quantityOfProduct);
                    prodToAdd.CalculateTotalPrice(priceOfProduct, quantityOfProduct);
                    listOfProducts.Add(nameOfProduct, prodToAdd);
                }
                else
                {
                    listOfProducts[nameOfProduct].Price = priceOfProduct;
                    listOfProducts[nameOfProduct].Quantity += quantityOfProduct;
                    listOfProducts[nameOfProduct].TotalPrice =
                        listOfProducts[nameOfProduct].CalculateTotalPrice(priceOfProduct, listOfProducts[nameOfProduct].Quantity);

                }

                command = Console.ReadLine();
            }

            foreach (var item in listOfProducts)
            {
                double totalPriceOfCurrentItem = item.Value.TotalPrice;
                Console.WriteLine($"{item.Key} -> {totalPriceOfCurrentItem:F2}");
            }
        }
    }
}
