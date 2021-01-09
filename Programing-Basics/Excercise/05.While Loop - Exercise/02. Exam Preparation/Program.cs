using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int unsatisfiedGrades = int.Parse(Console.ReadLine());
            int faildeTimes = 0;
            int solvedProblemCoundt = 0;
            double gradeSum = 0;
            string lastProblem = "";
            bool isFailed = true;

            while (faildeTimes<unsatisfiedGrades)
            {
                string problameName = Console.ReadLine();
              

                if (problameName=="Enough")
                {
                    isFailed = false;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                if (grade<=4)
                {
                    faildeTimes++;
                }
                gradeSum += grade;
                solvedProblemCoundt++;
                lastProblem = problameName;

            }
            if (isFailed)
            {
                Console.WriteLine($"You need a break, {unsatisfiedGrades} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {gradeSum/solvedProblemCoundt}");
                Console.WriteLine($"Number of problems: {solvedProblemCoundt}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }

        }
    }
}
