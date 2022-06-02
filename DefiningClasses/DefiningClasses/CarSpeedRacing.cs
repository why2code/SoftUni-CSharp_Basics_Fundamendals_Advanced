using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class CarSpeedRacing
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public CarSpeedRacing(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public void Drive(double kilometersToTravel)
        {
            double requiredFuel = kilometersToTravel * FuelConsumptionPerKilometer;
            if (FuelAmount >= requiredFuel)
            {
                TravelledDistance += kilometersToTravel;
                FuelAmount -= requiredFuel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }
    }
}
