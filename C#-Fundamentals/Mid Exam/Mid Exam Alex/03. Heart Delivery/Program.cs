using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int jumpredPosition = 0;

            string command = Console.ReadLine();

            while (command != "Love!")
            {
                string[] cmdArgs = command.Split();
                int jumpLenght = int.Parse(cmdArgs[1]);

                jumpredPosition += jumpLenght;

                if (jumpredPosition >= 0 && jumpredPosition < neighborhood.Length)
                {
                    neighborhood[jumpredPosition] -= 2;
                }
                else
                {
                    jumpredPosition = 0;
                    neighborhood[jumpredPosition] -= 2;
                }

                if (neighborhood[jumpredPosition] == 0)
                {
                    Console.WriteLine($"Place {jumpredPosition} has Valentine's day.");
                }

                else if (neighborhood[jumpredPosition] < 0)
                {
                    Console.WriteLine($"Place {jumpredPosition} already had Valentine's day.");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {jumpredPosition}.");
            int successCount = neighborhood.Count(x => x == 0);
            int failCount = neighborhood.Count(x => x > 0);

            if (failCount==0)
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
