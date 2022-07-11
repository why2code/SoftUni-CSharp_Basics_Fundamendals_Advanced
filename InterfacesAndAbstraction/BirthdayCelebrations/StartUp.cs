using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<ICitizen>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = commArgs[1];
                if (commArgs[0] == "Citizen")
                {
                    int age = int.Parse(commArgs[2]);
                    string id = commArgs[3];
                    string birthdate = commArgs[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    list.Add(citizen);
                }
                else if (commArgs[0] == "Pet")
                {
                    string birthdate = commArgs[2];
                    Pet pet = new Pet(name, birthdate);
                    list.Add(pet);
                }
                else if (commArgs[0] == "Robot")
                {
                    string id = commArgs[2];
                    Robot robot = new Robot(name, id);
                    list.Add(robot);
                }

                command = Console.ReadLine();
            }

            string birthdayYear = Console.ReadLine();
            int lenghtOfBirthdate = birthdayYear.Length;
            foreach (var citizen in list)
            {
                string currBirthday = citizen.birthdate;
                if (currBirthday != " ") //set as " " by default for Robots that have no Birthday
                {
                    string verificationBirthdayString = currBirthday.Substring
                    (currBirthday.Length - lenghtOfBirthdate, lenghtOfBirthdate);
                    if (verificationBirthdayString == birthdayYear)
                    {
                        Console.WriteLine(citizen.birthdate.ToString());
                    }
                }
            }

        }
    }
}
