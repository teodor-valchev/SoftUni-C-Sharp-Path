using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            
            
                switch (typeFlower)
                {
                    case "Roses":
                        price = countFlowers * 5;
                        break;
                    case "Dahlias":
                        price = countFlowers * 3.80;
                        break;
                    case "Tulips":
                        price = countFlowers * 2.80;
                        break;
                    case "Narcissus":
                        price = countFlowers * 3;
                        break;
                    case "Gladioulus":
                        price = countFlowers * 2.50;
                        break;

                    default:
                        break;
                }
            if (countFlowers>80)
            {
                if (typeFlower=="Roses")
                {
                    price = price - 0.10 * price;
                }
            }
             else if (countFlowers > 90)
            {
                if (typeFlower == "Dahilas")
                {
                    price = 0.85 * price;
                }
            }
             else if (countFlowers > 80)
            {
                if (typeFlower == "Tulips")
                {
                    price = price - 0.15 * price;
                }
            }
             else if (countFlowers > 90)
            {
                if (typeFlower == "Dahilas")
                {
                    price = price + 0.15 * price;
                    //price = 1.2*price;
                }
            }
           else  if (countFlowers < 120)
            {
                if (typeFlower == "Narcissus")
                {
                    price = price + 0.20 * price;
                }
            }
            if (price>=budget)
            {
                double leftSum = budget - price;
                Console.WriteLine($"Not enough money, you need {leftSum:f2} leva more.");
            }
            else
            {
                double needSum = price - budget;
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {typeFlower} and {needSum:f2} leva left.");
            }
        
            


        }
    }
}
