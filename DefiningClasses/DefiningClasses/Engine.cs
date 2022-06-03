using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
      
        private string model;

        private int power;

        private double displacement;

        private string efficiency;

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public double Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = double.MinValue;
        }

        public Engine(string model, int power, double displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public Engine(string model, int power, double displacement)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
        {
            Model = model;
            Power = power;
            Efficiency=efficiency;
            Displacement = double.MinValue;
        }
    }
}
