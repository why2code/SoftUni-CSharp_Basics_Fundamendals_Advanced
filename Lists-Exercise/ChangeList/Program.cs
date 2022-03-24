using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandsReceived = command.Split(' ');
                string currentCommand = commandsReceived[0];

                if (currentCommand == "Delete")
                {
                    int numberToDelete = int.Parse(commandsReceived[1]);
                    numbers.RemoveAll(x => x == numberToDelete);

                    //for (int i = 0; i < numbers.Count; i++)
                    //{
                    //    if (numbers[i] == numberToDelete)
                    //    {
                    //        numbers.RemoveAt(i);
                    //    }
                    //}
                }
                else if (currentCommand == "Insert")
                {
                    int element = int.Parse(commandsReceived[1]);
                    int position = int.Parse(commandsReceived[2]);
                    numbers.Insert(position, element);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
