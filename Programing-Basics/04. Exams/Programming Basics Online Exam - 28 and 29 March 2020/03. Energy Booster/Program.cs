using System;

namespace _03._Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int sets = int.Parse(Console.ReadLine());
            double price = 0;

            switch (fruit)
            {
                
                case "Watermelon":
                    if (size=="big")
                    {
                        price += 28.70 * 5;
                       
                    }
                    else if (size=="small")
                    {
                        price += 56 * 2;
                    }
                    break;
                case "Mango":
                    if (size == "big")
                    {
                        price += 19.60 * 5;
                    }
                    else if (size == "small")
                    {
                        price += 36.66 * 2;
                    }
                    break;
                case "Pineapple":
                    if (size == "big")
                    {
                        price += 24.80 * 5;
                    }
                    else if (size == "small")
                    {
                        price += 42.10 * 2;
                    }
                    break;
                case "Raspberry":
                    if (size == "big")
                    {
                        price += 15.20 * 5;
                    }
                    else if (size == "small")
                    {
                        price += 20 * 2;
                    }
                    break;
            }
            double priceSets = price * sets;
           

            if (priceSets>400&&priceSets<=1000)
            {
                priceSets *= 0.85;
            }
            else if (priceSets>1000)
            {
                priceSets *= 0.50;
            }
            Console.WriteLine($"{priceSets:f2} lv.");
        }
    }
}
