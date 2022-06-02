using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Family familia = new Family();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person memberToAddIntoFamily = new Person(name, age);
                familia.AddMember(memberToAddIntoFamily);
            }

            familia.GetOldestMember();

        }
    }
}
