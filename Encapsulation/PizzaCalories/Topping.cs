namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Topping
    {
        private string type;
        private double weight;
        private double toppingcalories;

        //•	Meat - 1.2;
        //•	Veggies - 0.8;
        //•	Cheese - 1.1;
        //•	Sauce - 0.9;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        protected string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies"
                    || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    this.type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        protected double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public double Toppingcalories
        {
            get
            {
                double typeModifier = 1.2; //default for Meat
                if (this.type.ToLower() == "veggies")
                {
                    typeModifier = 0.8;
                }
                else if (this.type.ToLower() == "cheese")
                {
                    typeModifier = 1.1;
                }
                else if (this.type.ToLower() == "sauce")
                {
                    typeModifier = 0.9;
                }

                this.toppingcalories = 2 * this.weight * typeModifier;
                return this.toppingcalories;
            }
        }
    }
}
