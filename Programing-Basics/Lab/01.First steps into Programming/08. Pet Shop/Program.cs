using System;

namespace _08._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogCount = int.Parse(Console.ReadLine());
            int restAnimalsCount = int.Parse(Console.ReadLine());
            double dogFood = dogCount * 2.50;
            double leftFood = restAnimalsCount * 4;
            double sum = dogFood + leftFood;
            Console.WriteLine($"{sum} lv.");
        }
    }
}
