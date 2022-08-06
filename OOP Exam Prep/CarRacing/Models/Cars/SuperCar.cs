﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private static double SuperCarStartingFuelAvailalbe = 80;
        private static double SuperCarStartingFuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, SuperCarStartingFuelAvailalbe, SuperCarStartingFuelConsumptionPerRace)
        {

        }
    }
}
