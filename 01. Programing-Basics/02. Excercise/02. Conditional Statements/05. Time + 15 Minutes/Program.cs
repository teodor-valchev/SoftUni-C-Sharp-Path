using System;

namespace _05._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            
            if (minutes>=45)
            {
                hour += 1;
                minutes += 15-60;
                if (hour == 24)
                {
                    hour = 0;
                }
            }
            else 
            {
                minutes += 15;
            }

            Console.WriteLine($"{hour}:{minutes:D2}");
          
        }
    }
}
