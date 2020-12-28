using System;

namespace _07._Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int progectsCount = int.Parse(Console.ReadLine());
            int timeNeeded = progectsCount * 3;
            Console.WriteLine($"The architect {name} will need {timeNeeded} hours to complete {progectsCount} project/s.");

        }
    }
}
