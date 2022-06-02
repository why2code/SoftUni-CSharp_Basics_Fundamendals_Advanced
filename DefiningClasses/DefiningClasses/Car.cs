using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;

        private Engine engine;

        private Cargo cargo;

        private List<Tires> tires;

        public List<Tires> Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Car(string model, double engineSpeed, double enginePower, double cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            Tires = new List<Tires>()
            {
                new Tires(tire1Age, tire1Pressure),
                new Tires(tire2Age, tire2Pressure),
                new Tires(tire3Age, tire3Pressure),
                new Tires(tire4Age, tire4Pressure)
            };
        }
    }
}
