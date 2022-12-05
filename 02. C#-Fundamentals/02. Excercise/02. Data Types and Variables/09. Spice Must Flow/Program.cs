using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yeld = int.Parse(Console.ReadLine());
            int days = 0;
            int collect = 0;

            if (yeld >= 100)
            {
                while (yeld >= 100)
                {
                    days++;
                    collect += yeld;
                    yeld -= 10;

                }
                collect -= (days + 1) * 26;
                Console.WriteLine(days);
                Console.WriteLine(collect);
            }
            else
            {
                Console.WriteLine(days);
                Console.WriteLine(collect);
            }

        }
    }
}
