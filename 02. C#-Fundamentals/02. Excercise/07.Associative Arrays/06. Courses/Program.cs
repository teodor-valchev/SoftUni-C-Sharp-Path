using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();
           
            while (command != "end")
            {
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!output.ContainsKey(courseName))
                {
                    output.Add(courseName, new List<string>());
                }
                output[courseName].Add(studentName);


                command = Console.ReadLine();
            }

            foreach (var course in output.OrderByDescending(x=>x.Value.Count))//listCount
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var item in course.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {item}");
                }
             
            }
        }
    }
}
