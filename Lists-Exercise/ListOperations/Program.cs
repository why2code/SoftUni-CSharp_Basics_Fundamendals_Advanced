using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandsSeparated = command.Split(' ');
                string currentCommand = commandsSeparated[0];

                if (currentCommand == "Add")
                {
                    int numberToAdd = int.Parse(commandsSeparated[1]);
                    numbers.Add(numberToAdd);
                }
                else if (currentCommand == "Insert")
                {
                    int numberToAdd = int.Parse(commandsSeparated[1]);
                    int indexToAdd = int.Parse(commandsSeparated[2]);
                    if (indexToAdd >= numbers.Count || indexToAdd < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    else
                    {
                        numbers.Insert(indexToAdd, numberToAdd);

                    }

                }
                else if (currentCommand == "Remove")
                {
                    int indexToRemove = int.Parse(commandsSeparated[1]);
                    if (indexToRemove >= numbers.Count || indexToRemove < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(indexToRemove);

                    }
                }
                else if (currentCommand == "Shift")
                {
                    if (commandsSeparated[1] == "left")
                    {
                        int rotateCounter = int.Parse(commandsSeparated[2]);
               
                        int actualRotator = rotateCounter % numbers.Count;
                        for (int i = 1; i <= actualRotator; i++)
                        {
                            int firstNumber = numbers.First();
                            numbers.RemoveAt(0);
                            numbers.Add(firstNumber);
                        }
                    }
                    else if (commandsSeparated[1] == "right")
                    {
                        int rotateCounter = int.Parse(commandsSeparated[2]);
                  
                        int actualRotator = rotateCounter % numbers.Count;
                        for (int i = 1; i <= actualRotator; i++)
                        {
                            int lastNumber = numbers.Last();
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastNumber);
                        }

                    }

                }


            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
