namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Pizza
    {
        private string name;
        private readonly ICollection<Topping> toppings;
        private Dough dough;
        private double totalpizzacalories;
        public Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough)
            : this()
        {
            this.Name = name;
            this.Dough = dough;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value)
                    && (value.Length >= 1 && value.Length <= 15))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
            }
        }
        public Dough Dough
        {
            get { return dough; }
            private set { dough = value; }
        }
        public IReadOnlyCollection<Topping> Toppings
        => (IReadOnlyCollection<Topping>)this.toppings;

        protected double Totalpizzacalories
        {
            get
            {
                this.totalpizzacalories = this.Dough.Doughcalories + TotalToppingCalories(this.toppings);
                return this.totalpizzacalories;
            }
        }
        public void AddToping(Topping topping)
        {
            if (this.toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else
            {
                this.toppings.Add(topping);
            }
        }
        private double TotalToppingCalories(ICollection<Topping> toppings)
        {
            double toppingCals = 0;

            if (this.toppings.Count != 0)
            {
                foreach (var topping in toppings)
                {
                    toppingCals += topping.Toppingcalories;
                }
            }

            return toppingCals;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Totalpizzacalories:F2} Calories.";
        }
    }
}
