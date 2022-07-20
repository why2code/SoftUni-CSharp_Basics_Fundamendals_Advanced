namespace VehiclesExtension.Models
{
    using Interfaces;
    using System;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        private const double defautTankCapacity = 0;
        protected abstract double AdditionalConsumption { get; }
        private Vehicle()
        {
            this.FuelConsumptionModifier = 0;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : this()
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }


        protected virtual double FuelConsumptionModifier { get; }
        //Full property -> Open to extension, easy can add validation
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (this.fuelQuantity > this.tankCapacity)
                {
                    this.fuelQuantity = defautTankCapacity;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value + this.FuelConsumptionModifier;
            }
        }


        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            private set
            {
                this.tankCapacity = value;
            }
        }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + AdditionalConsumption);
            if (fuelNeeded > this.FuelQuantity)
            {
                //Not Enough fuel
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }



    }
}