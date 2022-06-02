using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ////-----------------------------------------------------------------------------
            ////06. Speed Racing 
            int num = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < num; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                double fueltank = double.Parse(carData[1]);
                double consumption = double.Parse(carData[2]);

                Car currCar = new Car(model, fueltank, consumption);
                cars.Add(currCar);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commArgs = command.Split();
                string driveModel = commArgs[1];
                double kilometers = double.Parse(commArgs[2]);

                Car travellingCar = cars.First(x => x.Model == driveModel);
                travellingCar.Drive(kilometers);
                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

            ////-----------------------------------------------------------------------------
            ////04. Opinion poll
            //int num = int.Parse(Console.ReadLine());
            //List<Person> peopleOver30 = new List<Person>();
            //for (int i = 0; i < num; i++)
            //{
            //    string[] input = Console.ReadLine().Split();
            //    string name = input[0];
            //    int age = int.Parse(input[1]);

            //    if (age > 30)
            //    {
            //        peopleOver30.Add(new Person(name, age));
            //    }
            //}

            //peopleOver30 = peopleOver30.OrderBy(x => x.Name).ToList();
            //foreach (var person in peopleOver30)
            //{
            //    Console.WriteLine($"{person.Name} - {person.Age}");
            //}

            ////-----------------------------------------------------------------------------
            ////03. OldestFamilyMember
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
