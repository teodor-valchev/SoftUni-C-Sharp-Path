using System;

namespace _01._Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int broiButilkiPrepaat = int.Parse(Console.ReadLine());
                string broiSudove = Console.ReadLine();

                int sudove = 0;
                int counter = 1;
                double totalMlPreparat = broiButilkiPrepaat * 750;
                double izrazhodvanPreparatChinii = 0;
                double izrazhodvanPreparatTendjeri = 0;
                double izrazhodvanPreparat = 0;
                double broiChinii = 0;
                double broiTendjeri = 0;





                while (broiSudove != "End")
                {
                    sudove = int.Parse(broiSudove);


                    if (counter % 3 == 0)
                    {
                        izrazhodvanPreparatTendjeri = sudove * 15;
                        totalMlPreparat = (totalMlPreparat - izrazhodvanPreparatTendjeri);
                        broiTendjeri += sudove;
                        izrazhodvanPreparat = izrazhodvanPreparatTendjeri;


                    }
                    else
                    {
                        izrazhodvanPreparatChinii = sudove * 5;
                        totalMlPreparat = (totalMlPreparat - izrazhodvanPreparatChinii);
                        broiChinii += sudove;
                        izrazhodvanPreparat = izrazhodvanPreparatChinii;

                    }




                    if (totalMlPreparat <= 0)
                    {

                        Console.WriteLine($"Not enough detergent, {Math.Abs(totalMlPreparat)} ml. more necessary!");
                        return;

                    }
                    broiSudove = Console.ReadLine();

                    counter++;
                }
                if (totalMlPreparat >= 0)
                {

                    Console.WriteLine("Detergent was enough!");
                    Console.WriteLine($"{broiChinii} dishes and {broiTendjeri} pots were washed.");
                    Console.WriteLine($"Leftover detergent {totalMlPreparat} ml.");
                }
                else
                {

                    Console.WriteLine($"Not enough detergent, {Math.Abs(totalMlPreparat)} ml. more necessary!");
                }
            }
    }
}
