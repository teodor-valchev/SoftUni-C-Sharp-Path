using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                if (numbers < 200)
                {
                    p1++;
                }
                else if (numbers >= 200 && numbers <= 399)
                {
                    p2++;
                }
                else if (numbers >= 400 && numbers <= 599)
                {
                    p3++;
                }
                else if (numbers >= 600 && numbers <= 799)
                {
                    p4++;
                }
                else if (numbers >= 800)
                {
                    p5++;
                }

            }
            Console.WriteLine($"p1 = {1.0 * p1 / n * 100:f2}%");
            Console.WriteLine($"p2 = {1.0 * p2 / n * 100:f2}%");
            Console.WriteLine($"p3 = {1.0 * p3 / n * 100:f2}%");
            Console.WriteLine($"p4 = {1.0 * p4 / n * 100:f2}%");
            Console.WriteLine($"p5 = {1.0 * p5 / n * 100:f2}%");
        }
    }
}
