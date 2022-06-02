using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tires
    {
        private int age;

        private double pressure;
        
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        public Tires(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}
