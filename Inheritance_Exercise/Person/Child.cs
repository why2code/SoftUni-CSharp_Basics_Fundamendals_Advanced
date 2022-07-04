using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {

        public Child(string name, int age) : base(name, age)
        {
        }

        //Extending the logic of the base setter for Age
        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    base.Age = 15;
                }
                else
                {
                    base.Age = value;
                }
            }
        }
    }
}
