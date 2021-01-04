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
                    price *= 0.1;
                }
            }
            else if (countFlowers > 90)
            {
                if (typeFlower == "Dahilas")
                {
                    price *= 0.15;
                }
            }
            else if (countFlowers > 80)
            {
                if (typeFlower == "Tulips")
                {
                    price *= 0.15;
                }
            }
            else if (countFlowers > 90)
            {
                if (typeFlower == "Dahilas")
                {
                    price *= 0.15;
                }
            }
            else if (countFlowers < 120)
            {
                if (typeFlower == "Narcissus")
                {
                    price *= 0.15;
                }
            }
            if (price>budget)
            {
                price -= budget;
                Console.WriteLine($"Not enough money, you need {price:f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {typeFlower} and {price} leva left.");
            }
        
            


        }
    }
}
