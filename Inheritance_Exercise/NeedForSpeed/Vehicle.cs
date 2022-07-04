using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsepower, double fuel)
        {
            this.HorsePower = horsepower;
            this.Fuel = fuel;
            this.FuelConsumption = 1.25;
        }

        private int horsePower;

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        private double fuel;

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        private double defaultFuelConsumption;
        private double fuelConsumption;
        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set
            {
                this.fuelConsumption = value;
            }
        }


        public virtual void Drive(double kilometers)
        {
            double reducedFuel = this.Fuel - ((this.FuelConsumption * kilometers) / 100);
            this.Fuel = reducedFuel;
        }
    }
}
