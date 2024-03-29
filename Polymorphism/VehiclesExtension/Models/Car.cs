﻿namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double CarFuelConsumptionIncrement = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionModifier
            => CarFuelConsumptionIncrement;

        protected override double AdditionalConsumption => CarFuelConsumptionIncrement;
    }
}