using System;

namespace Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                if (input * i > 10)
                {
                    if (i == 2 )
                    {
                        Console.WriteLine($"{input * i}");
                    }
                }
                else
                {
                    Console.WriteLine($"{input * i}");
                }
            }
            
        }
    }
}
