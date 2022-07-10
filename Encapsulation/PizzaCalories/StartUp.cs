namespace PizzaCalories
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                //First line with the pizza name, with substring in case multiple words included in the name
                string pizzaName = (Console.ReadLine().Substring(6));

                string[] doughDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string doughType = doughDetails[1];
                string bakingtechnique = doughDetails[2];
                double weight = double.Parse(doughDetails[3]);

                //Throws exception and breaks program if the Dough is invalid
                Dough dough = new Dough(doughType, bakingtechnique, weight);
                //If no exception thrown, we try to create the pizza with the name given (validated)
                Pizza pizza = new Pizza(pizzaName, dough);


                //Continuing with the Toppings
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] commArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                        
                    if (commArgs[0] == "Topping")
                    {
                        string toppingType = commArgs[1];
                        double toppingWeight = double.Parse(commArgs[2]);

                        //Breaks the program if topings go beyond 10 or are invalid
                        Topping topping = new Topping(toppingType, toppingWeight);
                        pizza.AddToping(topping);
                    }

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza);

            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }


        }
    }
}
