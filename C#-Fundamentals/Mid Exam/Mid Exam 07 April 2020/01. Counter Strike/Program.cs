using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int wins = 0;
            int battle = 0;
            bool notEnoughEnergy = false;

            while (command != "End of battle")
            {
                battle++;
                int distance = int.Parse(command);
                energy -= distance;
                wins++;

                if (battle % 3 == 0)
                {
                    energy += wins;
                }

                if (energy < 0)
                {
                    energy = 0;
                    notEnoughEnergy = true;
                    break;
                }



                command = Console.ReadLine();
            }

            if (notEnoughEnergy)
            {
                Console.WriteLine($"Not enough energy! Game ends with { wins - 1 } won battles and { energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
