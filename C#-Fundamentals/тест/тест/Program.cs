using System;

namespace тест
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstemployee = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int peopleCount = int.Parse(Console.ReadLine());


            int totalPeoplePerHour = firstemployee + second + third;
            int hours = 0;
            while (peopleCount>0)
            {
                peopleCount -= totalPeoplePerHour;
                hours++;

                if (hours%4==0)
                {
                    hours++;
                }

            }
            Console.WriteLine($"Time needed: {hours}h");

        }
    }
}
