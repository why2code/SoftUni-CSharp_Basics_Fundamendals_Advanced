using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Pet : ICitizen
    {
        public Pet(string name, string birthdate)
        {
            this.name = name;
            this.birthdate = birthdate;
        }

        public string id { get; protected set; } = " ";
        public string birthdate { get; private set; }
        public string name { get; private set; }
    }
}
