using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person :IComparable<Person>
    {
        private string name;

        private int age;

        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CompareTo( Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            //if names match, we check Age
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            //if Age also matches, finally we check for Town
            if (result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
