using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private int age;

        public virtual int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    this.age = 0;
                    //throw new ArgumentException("No negative age can be set!");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }

    }
}
