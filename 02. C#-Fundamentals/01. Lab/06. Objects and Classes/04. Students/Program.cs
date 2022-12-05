using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string command = Console.ReadLine();

            while (command!="end")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = tokens[0];
                string lastName = tokens[1];
                string age = tokens[2];
                string city = tokens[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.City = city;

                students.Add(student);
                

                command = Console.ReadLine();
            }
            string filterCity = Console.ReadLine();

            foreach (Student student in students)
            {
                if (filterCity==student.City)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
                
            }

        }
    }
}
