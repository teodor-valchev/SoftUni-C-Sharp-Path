using System;

namespace _02._Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeInSecondsPerOneMetert = double.Parse(Console.ReadLine());
            double totalSeconds = distance * timeInSecondsPerOneMetert;
            double addedTime = Math.Floor(distance / 50) * 30;
            double totalTime = totalSeconds + addedTime;

            if (record < totalTime)
            {
                Console.WriteLine($"No! He was {totalTime - record:f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($" Yes! The new record is {totalTime:f2} seconds.");   
            }
        }
    }
}
