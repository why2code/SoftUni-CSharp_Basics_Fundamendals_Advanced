using System;
using System.Linq;

namespace IteratorsAndComparators
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            //===============================================================================
            //02. ListyIterator Collection
            string command = Console.ReadLine();

            //first command guaranteed to be Create, so we generate the new ListyIterator
            string[] commArgs = command.Split();
            string[] filteredInputs = new string[commArgs.Length - 1];
            for (int i = 1; i < commArgs.Length; i++)
            {
                filteredInputs[i - 1] = commArgs[i];
            }

            var listy = new ListyIterator(filteredInputs);


            while (command != "END")
            {
                if (command == "Move")
                {
                    bool commandResult = listy.Move();
                    Console.WriteLine(commandResult);
                }
                else if (command == "HasNext")
                {
                    bool commandResult = listy.HasNext();
                    Console.WriteLine(commandResult);
                }
                else if (command == "Print")
                {
                    listy.Print();
                }
                else if (command == "PrintAll")
                {
                    listy.PrintAll();
                }

                command = Console.ReadLine();
            }


            //===============================================================================
            //01. ListyIterator

            //string command = Console.ReadLine();

            ////first command guaranteed to be Create, so we generate the new ListyIterator
            //string[] commArgs = command.Split();
            //string[] filteredInputs = new string[commArgs.Length - 1];
            //for (int i = 1; i < commArgs.Length; i++)
            //{
            //    filteredInputs[i - 1] = commArgs[i];
            //}

            //var listy = new ListyIterator(filteredInputs);


            //while (command != "END")
            //{
            //    if (command == "Move")
            //    {
            //        bool commandResult = listy.Move();
            //        Console.WriteLine(commandResult);
            //    }
            //    else if (command == "HasNext")
            //    {
            //        bool commandResult = listy.HasNext();
            //        Console.WriteLine(commandResult);
            //    }
            //    else if (command == "Print")
            //    {
            //        listy.Print();
            //    }

            //    command = Console.ReadLine();
            //}

        }
    }
}
