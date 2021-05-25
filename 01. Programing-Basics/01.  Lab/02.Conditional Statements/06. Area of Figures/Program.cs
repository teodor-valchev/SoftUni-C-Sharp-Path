using System;

namespace _06._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "square":
                    double a = int.Parse(Console.ReadLine());
                    double result = a * a;
                    Console.WriteLine($"{ result:f3}");
                    break;
                case "rectangle":
                    double b = double.Parse(Console.ReadLine());
                    double c = double.Parse(Console.ReadLine());
                    double result2 = b * c;

                    Console.WriteLine($"{result2:f3}");

                    break;
                case "circle":
                    double d = double.Parse(Console.ReadLine());

                    double result3 = Math.PI * d * d;
                    Console.WriteLine($"{result3:f3}");
                    break;
                case "triangle":
                    double e = double.Parse(Console.ReadLine());
                    double f = double.Parse(Console.ReadLine());
                    double result4 = (e * f)/2;
                    Console.WriteLine($"{result4:f3}");
                    break;
                default:
                    break;
            }

        }
    }
}
