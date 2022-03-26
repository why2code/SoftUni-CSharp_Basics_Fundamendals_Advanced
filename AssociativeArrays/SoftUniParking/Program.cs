using System;
using System.Collections.Generic;

namespace SoftuniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            Dictionary<string, string> carPark = new Dictionary<string, string>();
            string licensePlate = null;

            for (int i = 0; i < rotations; i++)
            {
                string command = Console.ReadLine();
                string[] splitCommands = command.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string registerOrUnregister = splitCommands[0];
                string userName = splitCommands[1];
                if (registerOrUnregister != "unregister")
                {
                    licensePlate = splitCommands[2];
                }


                if (registerOrUnregister == "register")
                {
                    if (!carPark.ContainsKey(userName))
                    {
                        carPark.Add(userName, licensePlate);
                        Console.WriteLine($"{userName} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                }
                else if (registerOrUnregister == "unregister")
                {
                    if (!carPark.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        carPark.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }

            }

            foreach (var car in carPark)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
