using System;
using System.Collections.Generic;

namespace OrderByAge
{
    class Person
    {
        public Person(string name, string identification, int age)
        {
            this.Name = name;
            this.ID = identification;
            this.Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> peopleAddedToList = new List<Person>();

            while (command != "End")
            {
                string[] inputOfNewPerson = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string username = inputOfNewPerson[0];
                string identification = inputOfNewPerson[1];
                int age = int.Parse(inputOfNewPerson[2].Trim());

                // Find if ID already in the list of people
                int existingID = peopleAddedToList.FindIndex(x => x.ID == identification);
                if (existingID >= 0 && existingID < peopleAddedToList.Count)
                {
                    peopleAddedToList[existingID].Name = username;
                    peopleAddedToList[existingID].Age = age;
                }
                else
                {
                    peopleAddedToList.Add(new Person(username, identification, age));
                }

                command = Console.ReadLine();
            }

            // Sort list by age and print out
            peopleAddedToList.Sort((a, b) => a.Age.CompareTo(b.Age));
            foreach (var person in peopleAddedToList)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }

        }

    }
}
