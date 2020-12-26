using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string water = Console.ReadLine();
            int numberOfDrinks = int.Parse(Console.ReadLine());
            PrintPrice(water, numberOfDrinks);
        }
        static void PrintPrice(string name,int number)
        {
            
            double price = 0;

            if (name=="coffee")
            {
                price += 1.50;
            }
            else if (name == "water")
            {
                price += 1.00;
            }
            else if (name == "coke")
            {
                price += 1.40;
            }
            else if (name == "snacks")
            {
                price += 2.00;
            }
            double result = price * number;
            Console.WriteLine($"{result:f2}");
        }
    }
}
