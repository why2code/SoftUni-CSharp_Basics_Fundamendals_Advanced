using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;

        private int weight;

        private string color;

        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = int.MinValue;
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public Car(string model, Engine engine, int weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
        {
            Model = model;
            Engine = engine;
            Color = color;
            Weight = int.MinValue;
        }
    }
}
