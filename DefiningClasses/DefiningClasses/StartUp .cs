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
            List<Car> cars = new List<Car>();
            for (int i = 0; i < num; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = commandArgs[0];
                double engineSpeed = double.Parse(commandArgs[1]);
                double enginePower = double.Parse(commandArgs[2]);
                double cargoWeight = double.Parse(commandArgs[3]);
                string cargoType = commandArgs[4];
                double tire1Pressure = double.Parse(commandArgs[5]);
                int tire1Age = int.Parse(commandArgs[6]);
                double tire2Pressure = double.Parse(commandArgs[7]);
                int tire2Age = int.Parse(commandArgs[8]);
                double tire3Pressure = double.Parse(commandArgs[9]);
                int tire3Age = int.Parse(commandArgs[10]);
                double tire4Pressure = double.Parse(commandArgs[11]);
                int tire4Age = int.Parse(commandArgs[12]);

                cars.Add(new Car(model,engineSpeed,enginePower,cargoWeight,cargoType,tire1Pressure,tire1Age,tire2Pressure,tire2Age,
                    tire3Pressure,tire3Age,tire4Pressure, tire4Age));
            }

            string lastCommand = Console.ReadLine();
            if (lastCommand == "fragile")
            {
                string requiredCargoType = "fragile";
                List<Car> searchedCars = cars.FindAll(x => x.Cargo.Type == requiredCargoType);
                foreach (var car in searchedCars)
                {
                    if (car.Tires.Any(x => x.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (lastCommand == "flammable")
            {
                string requiredCargoType = "flammable";
                List<Car> searchedCars = cars.FindAll(x => x.Cargo.Type == requiredCargoType);
                foreach (var car in searchedCars)
                {
                    if (car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }

            ////-----------------------------------------------------------------------------
            ////06. Speed Racing 
            //int num = int.Parse(Console.ReadLine());
            //List<CarSpeedRacing> cars = new List<CarSpeedRacing>();
            //for (int i = 0; i < num; i++)
            //{
            //    string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string model = carData[0];
            //    double fueltank = double.Parse(carData[1]);
            //    double consumption = double.Parse(carData[2]);

            //    CarSpeedRacing currCar = new CarSpeedRacing(model, fueltank, consumption);
            //    cars.Add(currCar);
            //}

            //string command = Console.ReadLine();
            //while (command != "End")
            //{
            //    string[] commArgs = command.Split();
            //    string driveModel = commArgs[1];
            //    double kilometers = double.Parse(commArgs[2]);

            //    CarSpeedRacing travellingCar = cars.First(x => x.Model == driveModel);
            //    travellingCar.Drive(kilometers);
            //    command = Console.ReadLine();
            //}

            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            //}

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
