using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());

            switch (product)
            {
                case "water":
                    PriceForWater(price);
                    break;
                case "coffee":
                    PriceForCoffee(price);
                    break;
                case "coke":
                    PriceForCoke(price);
                    break;
                case "snaks":
                    PriceForSnaks(price);
                    break;
                default:
                    break;
            }
        }

        private static void PriceForSnaks(double price)
        {
            Console.WriteLine(price*2.00);
        }

        private static void PriceForCoke(double price)
        {
            Console.WriteLine($"{price*1.40:f2}");
        }

        private static void PriceForCoffee(double price)
        {
            Console.WriteLine($"{price * 1.50:f2}");
        }

        private static void PriceForWater(double price)
        {
            Console.WriteLine($"{price * 1.00:f2}");
        }
    }
}
