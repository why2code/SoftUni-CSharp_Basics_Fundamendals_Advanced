using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> people = new List<Person>();
            while (command != "END")
            {
                string[] commArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = commArgs[0];
                int age = int.Parse(commArgs[1]);
                string town = commArgs[2];

                people.Add(new Person(name, age, town));

                command = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine());
            int totalPeopleCount = people.Count;
            int equalPeople = 0;

            foreach (var person in people)
            {
                if (people[index - 1].CompareTo(person) == 0) //Index - 1 as we count from 1. Check full matching of Name, Age and Town
                {
                    equalPeople++;
                }
            }

            if (equalPeople <= 1) //this is because ComparedTo will always produce at least 1 match (1 person matching himself)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int notEqualPeople = totalPeopleCount - equalPeople;
                Console.WriteLine($"{equalPeople} {notEqualPeople} {totalPeopleCount}");
            }

        }
    }
}
