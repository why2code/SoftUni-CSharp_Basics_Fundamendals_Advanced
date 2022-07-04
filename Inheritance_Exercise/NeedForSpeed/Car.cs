using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsepower, double fuel) : base(horsepower, fuel)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set
            {
                if (this.GetType().Name == "SportCar")
                {
                    base.FuelConsumption = 10;
                }
                else
                {
                    base.FuelConsumption = 3;
                }
            }
        }
    }
}
