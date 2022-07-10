namespace PizzaCalories
{
    using System;
    public class Dough
    {
        private string flourtype;
        private string bakingtechnique;
        private double weight;
        private double doughcalories;


        public Dough(string fourtype, string bakingtechnique, double weight)
        {
            this.Flourtype = fourtype;
            this.Bakingtechnique = bakingtechnique;
            this.Weight = weight;
        }

        //•  Modifiers:	
        //•	White - 1.5
        //•	Wholegrain - 1.0
        //•	Crispy - 0.9
        //•	Chewy - 1.1
        //•	Homemade - 1.0

        public double Doughcalories
        {
            get
            {
                double flourModifier = 1; //default for Wholegrain
                double bakingModifier = 0.9; //default for Crispy 
                if (this.flourtype.ToLower() == "white")
                {
                    flourModifier = 1.5;
                }

                if (this.bakingtechnique.ToLower() == "chewy")
                {
                    bakingModifier = 1.1;
                }

                if (this.bakingtechnique.ToLower() == "homemade")
                {
                    bakingModifier = 1.0;
                }

                this.doughcalories = 2 * this.weight * flourModifier * bakingModifier;
                return this.doughcalories;
            }


        }
        protected string Flourtype
        {
            get { return flourtype; }
            private set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    this.flourtype = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        protected string Bakingtechnique
        {
            get { return bakingtechnique; }
            private set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {
                    this.bakingtechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        protected double Weight
        {
            get { return weight; }
            private set
            {
                if (value >= 1 && value <= 200)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }
    }
}
