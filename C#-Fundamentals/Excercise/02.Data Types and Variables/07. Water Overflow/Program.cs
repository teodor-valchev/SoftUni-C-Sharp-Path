using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int totalLiters = 0;

            for (int i = 0; i < lines; i++)
            {
                int littersToPour = int.Parse(Console.ReadLine());
                totalLiters += littersToPour;

                if (totalLiters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    totalLiters -= littersToPour;
                }
            }
            

            
            Console.WriteLine(totalLiters);
        }
    }
}
