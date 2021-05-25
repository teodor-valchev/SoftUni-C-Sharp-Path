using System;

namespace _05._Suitcases_load
{
    class Program
    {
        static void Main(string[] args)
        {
            double load = double.Parse(Console.ReadLine());
            int suitcase = 0;
            bool goalReached = false;
            while (goalReached==false)
            {
                string input = Console.ReadLine();
                
                if (input=="End")
                {
                    goalReached = true;
                    break;

                }
                double suitcaseVolume = double.Parse(input);
                suitcase++;
                if (suitcase%3==0)
                {
                    suitcaseVolume += 7.2;
                }
                
                double totalBagage = load - suitcaseVolume;

                if (load<totalBagage)
                {
                    break;
                }
                


            }
            if (goalReached)
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
                Console.WriteLine($"Statistic: {suitcase} suitcases loaded.");
            }
            else
            {
                Console.WriteLine("No more space!");
                Console.WriteLine($"Statistic: {suitcase+1} suitcases loaded.");
            }

        }
    }
}
