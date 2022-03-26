using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Dictionary<string, double> students = new Dictionary<string, double>();

            for (int i = 0; i < counter; i++)
            {
                string nameOfStudent = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(nameOfStudent))
                {
                    students.Add(nameOfStudent, grade);
                }
                else
                {
                    double currentGrade = students[nameOfStudent];
                    double avgOfGrade = (currentGrade + grade) / 2;
                    students[nameOfStudent] = avgOfGrade;
                }
            }

            Dictionary<string, double> filteredStudents = new Dictionary<string, double>();
            foreach (var student in students)
            {
                if (student.Value >= 4.50)
                {
                    filteredStudents.Add(student.Key, student.Value);
                }
            }

            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:F2}");
            }

        }
    }
}
