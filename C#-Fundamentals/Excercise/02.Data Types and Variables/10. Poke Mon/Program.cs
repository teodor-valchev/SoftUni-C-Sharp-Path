using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int poke = 0;
            double tempPower = power * 0.5;

            while (power>=distance)
            {
                poke++;
                power -= distance;
             

                if (power==tempPower)
                {
                    power /= exhaustionFactor;
                }
             

            }
            Console.WriteLine(power);
            Console.WriteLine(poke);
        }
    }
}
