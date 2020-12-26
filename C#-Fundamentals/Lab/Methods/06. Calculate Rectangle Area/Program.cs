using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
             double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
             double area = CalculateArea(a, b);
            Console.WriteLine(area);
            

        }
        static double CalculateArea(double width,double height)
        {
            return  width * height;
        }
    }
}
