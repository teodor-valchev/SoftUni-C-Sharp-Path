using System;

namespace _06._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetMovie = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double clothePrise = double.Parse(Console.ReadLine());

            double dekor = budgetMovie * 0.1;
            double clothesSum = people * clothePrise;
            if (people > 150)
            {
                clothesSum -= clothesSum * 0.10;// when you want to subtract procent from the total

            }

            double totalSumForMovie = dekor + clothesSum;
            double leftForMovie = budgetMovie - totalSumForMovie;

            if (totalSumForMovie >= budgetMovie)
            {
                double left = Math.Abs(budgetMovie - totalSumForMovie);
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard starts filming with {left:f2} leva left.");
            }

            else if (totalSumForMovie <= budgetMovie)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {leftForMovie:f2} leva left.");
            }



        }
    }
}
