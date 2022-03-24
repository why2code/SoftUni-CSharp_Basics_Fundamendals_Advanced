using System;
using System.Collections.Generic;
using System.Linq;

namespace Studens
{
    class Student
    {
        public Student(string firstName, string lastName, float grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> studentsList = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] inputStudentData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string firstName = inputStudentData[0].Trim();
                string lastName = inputStudentData[1].Trim();
                float grade = float.Parse(inputStudentData[2]);

                studentsList.Add(new Student(firstName, lastName, grade));
            }

            studentsList.Sort((a, b) => b.Grade.CompareTo(a.Grade));
            for (int i = 0; i < studentsCount; i++)
            {
                Console.WriteLine($"{studentsList[i].FirstName} {studentsList[i].LastName}: {studentsList[i].Grade:F2}");
            }
        }
    }
}
