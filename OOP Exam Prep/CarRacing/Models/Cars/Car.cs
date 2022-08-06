using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsepower;
        private double fuelavailable;
        private double fuelconsumptionperrace;
        //protected double horsepowerReductionModifier;



        protected Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
            //this.horsepowerReductionModifier = 0;
        }
        public string Make
        {
            get => this.make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }
                this.make = value;
            }
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                this.model = value;
            }
        }
        public string VIN
        {
            get => this.vin;
            private set
            {
                string x = value;
                if (x.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }
                this.vin = value;
            }
        }
        public int HorsePower
        {
            get => this.horsepower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }
                this.horsepower = value;
            }
        }
        public double FuelAvailable
        {
            get => this.fuelavailable;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.fuelavailable = value;
            }
        }
        public double FuelConsumptionPerRace
        {
            get => this.fuelconsumptionperrace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                this.fuelconsumptionperrace = value;
            }
        }
        public virtual void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
            //double result = (Math.Ceiling(this.HorsePower  - (this.HorsePower * horsepowerReductionModifier)));
            //this.HorsePower = (int)result;
        }
    }
}
