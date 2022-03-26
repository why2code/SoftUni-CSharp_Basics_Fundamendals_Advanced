using System;
using System.Collections.Generic;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dictionary <string, List<string> >
            // Add into List based on course name (Key)
            // Print result, count of the students in the course from List.Count

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] studentWithCourseName = command.Split(" : ");
                string nameOfCourse = studentWithCourseName[0];
                string nameOfStudent = studentWithCourseName[1];

                if (!courses.ContainsKey(nameOfCourse))
                {
                    courses.Add(nameOfCourse, new List<string>() { nameOfStudent });
                }
                else
                {
                    courses[nameOfCourse].Add(nameOfStudent);
                }

                command = Console.ReadLine();
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student.ToString()}");
                }
            }
        }
    }
}
