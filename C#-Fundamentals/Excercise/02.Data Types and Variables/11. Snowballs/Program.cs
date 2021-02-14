using System;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowBalls = int.Parse(Console.ReadLine());
            double highestValue = 0;
            int biggestBall = 0;
            int biggestTime = 0;
            int biggestQuality = 0;


            for (int i = 1; i <= numberOfSnowBalls; i++)
            {
                int now = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

                double result = (now / time) ;
                double snowballValue = Math.Pow(result, quality);

                if (snowballValue>highestValue)
                {
                    highestValue = snowballValue;
                    biggestBall = now;
                    biggestTime = time;
                    biggestQuality = quality;
                  
                }
               


            }
            Console.WriteLine($"{biggestBall} : {biggestTime} = {highestValue} ({biggestQuality})");


        }
    }
}
