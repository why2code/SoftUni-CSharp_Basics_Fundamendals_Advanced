using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Person> peopleOver30 = new List<Person>();
            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                if (age > 30)
                {
                    peopleOver30.Add(new Person(name, age));
                }
            }

            peopleOver30 = peopleOver30.OrderBy(x => x.Name).ToList();
            foreach (var person in peopleOver30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

            //int num = int.Parse(Console.ReadLine());
            //Family familia = new Family();

            //for (int i = 0; i < num; i++)
            //{
            //    string[] input = Console.ReadLine().Split();
            //    string name = input[0];
            //    int age = int.Parse(input[1]);

            //    Person memberToAddIntoFamily = new Person(name, age);
            //    familia.AddMember(memberToAddIntoFamily);
            //}

            ////familia.GetOldestMember();
            //Person oldestPerson = familia.GetOldestMember();
            //Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

        }
    }
}
