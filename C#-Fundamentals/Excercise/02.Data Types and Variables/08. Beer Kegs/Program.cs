using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegNumber = int.Parse(Console.ReadLine());
            string biggestKeg = "";
            double currentVolume = 0;


            for (int i = 1; i <= kegNumber; i++)
            {
                string modelOfKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > currentVolume)
                {
                    currentVolume = volume;
                    biggestKeg = modelOfKeg;

                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
