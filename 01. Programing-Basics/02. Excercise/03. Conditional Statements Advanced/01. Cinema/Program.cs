using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int clone = int.Parse(Console.ReadLine());
            double income = 0;

            switch (type)
            {
                case "Premiere":income += 12;
                    
                    break;
                case "Normal":income += 7.50;
                    break;
                case "Discount":
                    income += 5;
                    break;
                default:
                    break;
            }
            double total = rows * clone *income;
            Console.WriteLine($"{total:f2} leva");
                

        }
    }
}
