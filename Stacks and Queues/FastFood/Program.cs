using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int availableFood = int.Parse(Console.ReadLine());
            int[] orderValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> queuedOrders = new Queue<int>(orderValues);

            //printing biggest order via sorted array
            int[] sortedArray = orderValues.OrderByDescending(x => x).ToArray();
            Console.WriteLine($"{sortedArray[0]}");

            int ordersToServe = orderValues.Count();
            bool noFoodLeft = false;
            for (int i = 0; i < ordersToServe; i++)
            {
                int currentCustomerOrder = queuedOrders.Peek();
                if (availableFood >= currentCustomerOrder)
                {
                    queuedOrders.Dequeue();
                    availableFood -= currentCustomerOrder;
                }
                else
                {
                    noFoodLeft = true;
                    break;
                }
            }

            if (noFoodLeft)
            {
                Console.Write("Orders left: ");
                Console.Write(String.Join(" ", queuedOrders));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }


        }
    }
}
