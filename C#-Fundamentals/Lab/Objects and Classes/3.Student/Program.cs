using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Student
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string firstnane = tokens[0];
                string lastname = tokens[1];
                double grade =double.Parse( tokens[2]);

                Student student = new Student(firstnane, lastname, grade);

                students.Add(student);

            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            foreach (Student currentStudent in students)
            {
                Console.WriteLine(currentStudent);
            }
        }

        class Student
        {
            public Student(string firstName,string lastName,double grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:f2}";
            }

        }
    }
}
