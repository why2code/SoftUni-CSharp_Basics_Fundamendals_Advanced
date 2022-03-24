using System;
using System.Collections.Generic;
using System.Linq;

namespace Train

{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] actions = command.Split();

                string currentActionToPerform = actions[0];
                if (currentActionToPerform == "Add")
                {
                    int passengersToAdd = int.Parse(actions[1]);
                    wagons.Add(passengersToAdd);
                }
                else
                {
                    int passengersToAdd = int.Parse(actions[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengersToAdd <= maxCapacity)
                        {
                            wagons[i] += passengersToAdd;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}
