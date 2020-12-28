using System;

namespace _09._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareMeters = double.Parse(Console.ReadLine());
            double finalPrice = squareMeters * 7.61;
            double discount = finalPrice * 0.82;
            double realDiscount = finalPrice - discount;
            Console.WriteLine($"The final price is: {discount:f2} lv.");
            Console.WriteLine($"The discount is: {realDiscount:f2} lv.");
        }
    }
}
