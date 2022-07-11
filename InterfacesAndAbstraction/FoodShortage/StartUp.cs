using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<ICitizen>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);
                if (commandArgs.Length == 3) //Rebel
                {
                    string group = commandArgs[2];
                    Rebel rebel = new Rebel(name, age, group);
                    list.Add(rebel);
                }
                else if (commandArgs.Length == 4) //Citizen
                {
                    string id = commandArgs[2];
                    string birthday = commandArgs[3];
                    Citizen citizen = new Citizen(name, age, id, birthday);
                    list.Add(citizen);
                }
            }

            //Listing buyer names in order to buy food
            string foodBuyerName = Console.ReadLine();
            while (foodBuyerName != "End")
            {
                //Searching if the name of the buyer is in the list
                foreach (var citizen in list)
                {
                    if (citizen.name == foodBuyerName)
                    {
                        if (citizen is Citizen c)
                        {
                            c.BuyFood();
                        }
                        if (citizen is Rebel r)
                        {
                            r.BuyFood();
                        }
                    }
                }


                foodBuyerName = Console.ReadLine();
            }

            //Final sum of total food bought
            int totalFood = 0;
            foreach (IBuyer citizen in list)
            {
                int food = citizen.Food;
                totalFood += food;
            }

            Console.WriteLine(totalFood);
        }
    }
}
