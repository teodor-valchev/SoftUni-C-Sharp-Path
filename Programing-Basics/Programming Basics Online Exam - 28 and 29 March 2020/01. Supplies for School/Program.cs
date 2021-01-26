using System;

namespace _01._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            double penPacket = double.Parse(Console.ReadLine());
            double markersPacket = double.Parse(Console.ReadLine());
            double litterCleaningForBoard = double.Parse(Console.ReadLine());
            double discountPercantage = double.Parse(Console.ReadLine());

            double penPacketSum = penPacket * 5.80;
            double markersPacketSum = markersPacket * 7.20;
            double priceCleaning = litterCleaningForBoard * 1.20;
            double sumOfAllProducts = penPacketSum + markersPacketSum + priceCleaning;

            double totalSum = sumOfAllProducts - (sumOfAllProducts*discountPercantage/100);

            Console.WriteLine($"{totalSum:f3}");
            





        }
    }
}
