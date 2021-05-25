using System;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishersCount = int.Parse(Console.ReadLine());
            double pricePerSeason = 0;

            switch (season)
            {
                case "Spring":
                    pricePerSeason = 3000;
                    break;
                case "Summer":
                    pricePerSeason = 4200;
                    break;
                case "Autumn":
                    pricePerSeason = 4200;
                    break;
                case "Winter":
                    pricePerSeason = 2600;
                    break;
                default:
                    break;
            }
            if (fishersCount<=6)
            {
                pricePerSeason *= 0.90;
            }
            else if (fishersCount>=7&&fishersCount<=11)
            {
                pricePerSeason *= 0.85;
            }
            else if (fishersCount>12)
            {
                pricePerSeason *= 0.75;
            }

            if (fishersCount%2==0&&season=="Winter" && season == "Spring" && season == "Summer")
            {
                pricePerSeason *= 0.95;
            }

            if (budget>pricePerSeason)
            {
                double left = Math.Abs( pricePerSeason - budget);
                Console.WriteLine($"Yes! You have {left:f2} leva left.");
            }
            else if (pricePerSeason>budget)
            {
                double notEnough =Math.Abs (budget - pricePerSeason);
                Console.WriteLine($"Not enough money! You need {notEnough:f2} leva.");
            }
            

        }
    }
}
