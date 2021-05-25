using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] cmdArg = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string user = cmdArg[0];

                if (cmdArg.Length > 2)// дали имаме Pesho-Java-84
                {
                    string language = cmdArg[1];
                    int points = int.Parse(cmdArg[2]);

                    if (!students.ContainsKey(user))
                    {
                        students.Add(user, points);
                    }
                    else
                    {
                        if (students[user]<points)
                        {
                            students[user] = points;
                        }
                    }
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    submissions[language]++;
                }
                else
                {
                    students.Remove(user);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Results: ");

            foreach (var student in students.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions: ");

            foreach (var submission in submissions.OrderByDescending(x=>x.Key).ThenBy(x=>x.Value))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }

        }
    }
}
