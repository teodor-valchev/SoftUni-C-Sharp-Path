using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        public static object Dictionar { get; private set; }

        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (command!="end")
            {
                string[] cmdArgs = command.Split();
                string courceName = cmdArgs[0];
                string studentName = cmdArgs[1];

                if (!courses.ContainsKey(courceName))
                {
                    courses.Add(courceName, new List<string>());
                    
                }
                courses[courceName].Add(studentName);

                command = Console.ReadLine();
            }

            foreach (var currentCource in courses.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{ currentCource.Key}: {currentCource.Value.Count }");

                foreach (var item in currentCource.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
