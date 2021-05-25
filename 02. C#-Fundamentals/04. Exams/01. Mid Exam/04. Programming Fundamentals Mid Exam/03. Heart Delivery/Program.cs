using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int jumpedPosition = 0;
            string comand = Console.ReadLine();

            while (comand != "Love!")
            {
                string[] cmdArg = comand.Split();
                int lenght = int.Parse(cmdArg[1]);
                int startIndex = neighborhood[0];

                jumpedPosition += lenght;

                if (jumpedPosition >= 0 && jumpedPosition < neighborhood.Length)
                {
                    neighborhood[jumpedPosition] -= 2;
                }
                else
                {
                    jumpedPosition = 0;
                    neighborhood[jumpedPosition] -= 2;

                }

                if (neighborhood[jumpedPosition] == 0)
                {
                    Console.WriteLine($"Place {jumpedPosition} has Valentine's day.");
                }
                else if (neighborhood[jumpedPosition] < 0)
                {
                    Console.WriteLine($"Place {jumpedPosition} already had Valentine's day.");
                }
                comand = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {jumpedPosition}.");
            int successfulCount = neighborhood.Count(x => x == 0);
            int failCount = neighborhood.Count(x => x > 0);

            if (successfulCount > 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failCount} places.");
            }
        }
    }
}
