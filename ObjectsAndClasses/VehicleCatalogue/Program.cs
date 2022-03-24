using System;
using System.Linq;
using System.Collections.Generic;

namespace E_06._Vehicle_Catalogue
{
    internal class Program
    {


        class Catalog
        {
            public Catalog(string type, string model, string color, double horsePower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = horsePower;
            }
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public double HorsePower { get; set; }

            public override string ToString()
            {
                string vehicleStr = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                               $"Model: {this.Model}{Environment.NewLine}" +
                               $"Color: {this.Color}{Environment.NewLine}" +
                               $"Horsepower: {this.HorsePower}";

                return vehicleStr;

                //return $"Type: {this.Type}";
                //return $"Model: {this.Model}";
                //return $"Color: {this.Color}";
                //return $"Horsepower: {this.HorsePower}";     

            }

        }
        static void Main(string[] args)
        {
            List<Catalog> catalogOfVehicles = new List<Catalog>();

            //Until you receive the "End" command, you will be receiving lines of input in the following format:
            //"{typeOfVehicle} {model} {color} {horsepower}"

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] vehicleArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = vehicleArg[0].Trim();
                string model = vehicleArg[1].Trim();
                string color = vehicleArg[2].Trim();
                double horsePower = double.Parse(vehicleArg[3].Trim());

                Catalog currVehicl = new Catalog(type, model, color, horsePower);
                catalogOfVehicles.Add(currVehicl);
            }


            string modelVehicle;
            while ((modelVehicle = Console.ReadLine()) != "Close the Catalogue")
            {

                Console.WriteLine(catalogOfVehicles.Find(x => x.Model == modelVehicle));

            }


            var car = catalogOfVehicles.Where(x => x.Type == "car").ToList();
            var truck = catalogOfVehicles.Where(x => x.Type == "truck").ToList();

            double horsepowerOfCars = CalculateHorsepower(car);
            double horsepowerOfTrucks = CalculateHorsepower(truck);
            Console.WriteLine($"Cars have average horsepower of: {horsepowerOfCars:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {horsepowerOfTrucks:F2}.");


        }

        static double CalculateHorsepower(List<Catalog> vehicles)
        {
            double summedHorsepower = 0;
            double count = 0;
            double avgHorsepower = 0;

            for (int i = 0; i < vehicles.Count; i++)
            {

                count++;
                summedHorsepower += vehicles[i].HorsePower;
            }


            if (count > 0)
            {
                avgHorsepower = summedHorsepower / count;
            }


            return avgHorsepower;
        }
    }
}

