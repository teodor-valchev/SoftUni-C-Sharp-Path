using System;

namespace _07._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeinSecondsPerMeter = double.Parse(Console.ReadLine());

            double distanceInSecondsToSwim = distanceInMeters * timeinSecondsPerMeter;

            double addedTime =Math.Floor(distanceInMeters / 15) * 12.5;
            double totalTime = distanceInSecondsToSwim + addedTime;
            double timeLeft = totalTime - recordInSeconds;

            if (recordInSeconds<totalTime)
            {
                Console.WriteLine($"No, he failed! He was { timeLeft:f2} seconds slower.");
            }
            else
            {
                double winTime = distanceInSecondsToSwim + addedTime;
                Console.WriteLine($" Yes, he succeeded! The new world record is {winTime:f2} seconds.");
            }


        }
    }
}
