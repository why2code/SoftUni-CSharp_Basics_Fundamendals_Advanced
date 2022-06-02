using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person(int Age)
        {
            this.Name = "No name";
            this.Age = Age;
        }

        public Person(string Name, int Age)
        {
            this.name = Name;
            this.Age = Age;
        }


    }

}
