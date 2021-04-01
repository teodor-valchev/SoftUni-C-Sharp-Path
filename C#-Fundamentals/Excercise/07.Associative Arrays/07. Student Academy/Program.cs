using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<double>());
                }
                grades[name].Add(grade);





            }
            foreach (var studens in grades.Where(x => x.Value.Average(x => x) >= 4.50).OrderByDescending(y => y.Value.Average(z => z)))
            {

                Console.WriteLine($"{studens.Key} -> {(studens.Value.Average(x => x)):f2}");
            }
        }
    }
}
