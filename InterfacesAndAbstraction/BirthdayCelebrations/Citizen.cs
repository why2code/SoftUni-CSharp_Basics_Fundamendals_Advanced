using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.name = name;
            this.age = age;
            this.id = id;
            this.birthdate = birthdate;
        }

        public string name { get; private set; }
        public int age { get; private set; }
        public string id { get; private set; }
        public string birthdate { get; private set; }
    }
}
