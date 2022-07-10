namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> buyersList = new List<Person>();
            Dictionary<string, decimal> productsList = new Dictionary<string, decimal>();

            try
            {
                //Creating the buyers list from input
                string[] peopleAndCash = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < peopleAndCash.Length; i++)
                {
                    string personsName = peopleAndCash[i].Split('=')[0];
                    decimal personsMoney = decimal.Parse(peopleAndCash[i].Split('=')[1]);
                    
                    Person currentPerson = new Person(personsName, personsMoney);
                    buyersList.Add(currentPerson);
                }

                //Creating the products list from input
                string[] productsAndPrice = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productsAndPrice.Length; i++)
                {
                    string productName = productsAndPrice[i].Split('=')[0];
                    decimal productCost = decimal.Parse(productsAndPrice[i].Split('=')[1]);

                    //just ensuring the product ctor works
                    //Product currentProduct = new Product(productName, productCost);
                    productsList[productName] = productCost;
                }

                string command = Console.ReadLine();
                while (command != "END")
                {
                    string nameOfBuyer = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                    string nameOfProduct = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

                    //making sure such buyer exists in the buyersList
                    if (buyersList.FirstOrDefault(x => x.Name == nameOfBuyer) != null)
                    {
                        Person currentBuyer = buyersList.FirstOrDefault(x => x.Name == nameOfBuyer);
                        decimal priceRemainingForCurrentBuyer = currentBuyer.Money;
                        decimal productPrice = productsList[nameOfProduct];

                        if (productPrice <= priceRemainingForCurrentBuyer)
                        {
                            currentBuyer.AddProduct(new Product(nameOfProduct, productPrice));
                            currentBuyer.Money -= productPrice;
                            Console.WriteLine($"{currentBuyer.Name} bought {nameOfProduct}");
                        }
                        else
                        {
                            Console.WriteLine($"{currentBuyer.Name} can't afford {nameOfProduct}");
                        }
                    }

                    command = Console.ReadLine();
                }

                //printing final list of buyers and products
                foreach (Person buyer in buyersList)
                {
                    Console.WriteLine(buyer.ToString());
                }

            }
            catch (Exception ae)
            {
                Console.WriteLine((ae.Message));
                return;
            }
          
        }
    }
}
