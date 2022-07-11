using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<ICitizen>();
            //list.Add(new Citizen());
            //list.Add(new Robot());

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //Creating Robot or Citizen based on lenght of the input parameters (2 or 3)
                if (commArgs.Length == 3)
                {
                    string citizenName = commArgs[0];
                    int citizenAge = int.Parse(commArgs[1]);
                    string citizenID = commArgs[2];

                    Citizen person = new Citizen(citizenName, citizenAge, citizenID);
                    list.Add(person);
                }
                else if (commArgs.Length == 2)
                {
                    string robotName = commArgs[0];
                    string robotID = commArgs[1];

                    Robot robot = new Robot(robotName, robotID);
                    list.Add(robot);
                }

                command = Console.ReadLine();
            }

            //Receiving ID to detain
            string detainedIDNumber = Console.ReadLine();
            int lenghtOfDetainedID = detainedIDNumber.Length;

            //Searching through citizens to find matching ID substrings
            foreach (var citizen in list)
            {
                string currID = citizen.id;
                if (currID.Length >= lenghtOfDetainedID)
                {
                    string verificationIDString = currID.Substring(currID.Length - lenghtOfDetainedID, lenghtOfDetainedID);
                    if (verificationIDString == detainedIDNumber)
                    {
                        Console.WriteLine(citizen.id.ToString());
                    }
                }
            }

        }
    }
}
