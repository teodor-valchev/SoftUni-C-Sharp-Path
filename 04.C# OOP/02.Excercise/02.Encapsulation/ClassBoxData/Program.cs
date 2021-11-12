using System;

namespace _01.ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenghth = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = new Box(lenghth, width, height);
            double volume = box.Volume();
            double surfaceArea = box.SurfaceArea();
            double laterialSurcafeArea = box.LateralSurfaceArea();
            if (lenghth > 0 && width > 0 && height > 0)
            {
                Console.WriteLine($"Surface Area - {surfaceArea:f2}");
                Console.WriteLine($"Lateral Surface Area - {laterialSurcafeArea:f2}");
                Console.WriteLine($"Volume - {volume:f2}");
            }
         
        }
    }
}
