using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private static double tunedCarStartingFuelAvailalbe = 65;
        private static double tunedCarStartingFuelConsumptionPerRace = 7.5;
        private static double TunedCarModifierForEngineWear = 0.3;
        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, tunedCarStartingFuelAvailalbe, tunedCarStartingFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower -= (int)Math.Ceiling(HorsePower * TunedCarModifierForEngineWear); //is it Round or Ceiling?

        }

    }
}
