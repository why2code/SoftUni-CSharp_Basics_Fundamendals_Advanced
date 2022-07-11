using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : ICitizen, IBuyer
    {

        public Rebel(string name, int age, string group)
        {
            this.name = name;
            this.Age = age;
            this.Group = group;
        }

        public string name {get; private set;}

        public int Age { get; private set; }
        public string Group { get; private set; }


        public string id { get; protected set; } = " ";
        public string birthdate { get; protected set; } = " ";


        public int Food { get; set; } = 0;

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
