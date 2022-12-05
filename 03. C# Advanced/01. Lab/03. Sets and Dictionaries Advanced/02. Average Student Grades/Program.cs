using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }
                students[name].Add(grade);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }

        }
    }
}
