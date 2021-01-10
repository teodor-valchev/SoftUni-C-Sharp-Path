using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int totalLenght = width * lenght;
            bool hasCake = true;
            

            while (hasCake) 
            {
                string input = Console.ReadLine();
               
                if (input=="STOP")
                {

                    break;
                }
                int pieces = int.Parse(input);
                totalLenght -= pieces;

                if (totalLenght<0)
                {
                    hasCake = false;
                   
                }
                
           

            }
            if (hasCake)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(totalLenght)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{totalLenght} pieces are left.");
            }
        }
    }
}
