using System;

namespace _04._Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            string result = Console.ReadLine();

            if (result=="m")
            {
                double result3 = a /1000;
               
                Console.WriteLine($"{ result3:f3}");
                
            }
            else if (result=="cm")
            {
                double result2 = a * 100;
                Console.WriteLine($"{ result2:f3}");
            }
            else if (result == "mm")
            {
                double result4 = a * 10;
                Console.WriteLine($"{ result4:f3}");
            }

        }
    }
}
