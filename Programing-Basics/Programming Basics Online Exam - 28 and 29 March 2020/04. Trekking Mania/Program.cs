using System;

namespace _04._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupNumber = int.Parse(Console.ReadLine());
            double musala = 0;
            double monbaln = 0;
            double kilimandgaro = 0;
            double K2 = 0;
            double everest = 0;
            double totalPeople = 0;

            for (int i = 1; i <= groupNumber; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());

                if (peopleInGroup >= 1 && peopleInGroup <= 5)
                {
                    musala += peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    monbaln += peopleInGroup;
                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    kilimandgaro += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    K2 += peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    everest += peopleInGroup;
                }
                totalPeople += peopleInGroup;
            }
            double musalaClimversInPercentage = musala / totalPeople * 100;
            double monbalnClimversInPercentage = monbaln / totalPeople * 100;
            double kilimandgaroClimversInPercentage = kilimandgaro / totalPeople * 100;
            double k2ClimversInPercentage = K2 / totalPeople * 100;
            double everestClimversInPercentage = everest / totalPeople * 100;
            Console.WriteLine($"{ musalaClimversInPercentage:f2}%");
            Console.WriteLine($"{monbalnClimversInPercentage:f2}%");
            Console.WriteLine($"{kilimandgaroClimversInPercentage:f2}%");
            Console.WriteLine($"{k2ClimversInPercentage:f2}%");
            Console.WriteLine($"{everestClimversInPercentage:f2}%");

        }
    }
}
