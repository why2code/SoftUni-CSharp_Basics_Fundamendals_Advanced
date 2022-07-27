namespace ValidationAttributes.Models
{
    using System;
    using Utilities.Attributes;
    public class Person
    {
        private const int minValue = 12;
        private const int maxValue = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(minValue,maxValue)]
        public int Age { get; set; }

      
    }
}
