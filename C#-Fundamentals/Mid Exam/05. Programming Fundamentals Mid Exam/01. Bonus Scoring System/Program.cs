using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            double lectures = int.Parse(Console.ReadLine());
            double bonus = int.Parse(Console.ReadLine());

            int maxAttendaces = 0;
            double maxBonus = 0;

            for (int i = 1; i <= numberOfStudents; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                double totalBonus = Math.Ceiling((attendances / lectures) * (5 + bonus));

                if (attendances > maxAttendaces)
                {
                    maxAttendaces = attendances;
                }
                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                }

            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxAttendaces} lectures.");
        }
    }
}
