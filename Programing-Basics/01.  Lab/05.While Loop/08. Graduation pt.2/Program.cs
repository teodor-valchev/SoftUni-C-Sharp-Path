using System;

namespace _08._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grades = 1;
            double sum = 0;
            int escluded = 0;

            while (grades<=12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade<=4)
                {
                    escluded++;
                    if (escluded>1)
                    {
                        Console.WriteLine($"{name} has been excluded at {grades} grade");
                    }
                    continue;
                }
                sum += grade;
                grades++;
            }
            double average = sum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
        }
    }
}
