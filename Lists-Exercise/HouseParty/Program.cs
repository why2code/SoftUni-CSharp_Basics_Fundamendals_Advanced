using System;
using System.Collections.Generic;

namespace HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                string nameOfGuest = command[0];

                if (command.Length == 3)
                {
                    if (guests.Contains(nameOfGuest))
                    {
                        Console.WriteLine($"{nameOfGuest} is already in the list!");
                    }
                    else
                    {
                        guests.Add(nameOfGuest);
                    }
                }
                else if (command.Length == 4)
                {
                    if (!guests.Contains(nameOfGuest))
                    {
                        Console.WriteLine($"{nameOfGuest} is not in the list!");
                    }
                    else
                    {
                        guests.Remove(nameOfGuest);
                    }
                }
            }

            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
