using System;

namespace _06._Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int sweets = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int gofrets = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakeSum = cakes * 45;
            double gofretsSum = gofrets * 5.80;
            double pancakeSum = pancakes * 3.20;
            double totalSumForDay = (cakeSum + gofretsSum + pancakeSum) * sweets;
            double totalSum = totalSumForDay * days;

            double expenses = totalSum / 8;
            double profit = totalSum - (totalSum / 8);
            Console.WriteLine(profit);
        }
    }
}
