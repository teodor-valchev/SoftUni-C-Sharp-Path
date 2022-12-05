using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;

            switch (dayOfWeek)
            {
                case "Friday":
                    if (groupType== "Students")
                    {
                        
                        price += 8.45;
                    }
                    else if (groupType== "Business")
                    {
                        price += 10.90;
                    }
                    else if (groupType == "Regular")
                    {
                        price += 15;
                    }
                    
                    break;
                case "Saturday":
                    if (groupType == "Students")
                    {
                        price += 9.80;
                    }
                    else if (groupType == "Business")
                    {
                        price += 15.60;
                    }
                    else if (groupType == "Regular")
                    {
                        price += 20;
                    }
                    break;
                case "Sunday":
                    if (groupType == "Students")
                    {
                        price += 10.46;
                    }
                    else if (groupType == "Business")
                    {
                        price += 16;
                    }
                    else if (groupType == "Regular")
                    {
                        price += 22.50;
                    }
                    break;
                default:

                    break;
            }
            double totalPrice = price * group;

            if (group>=30)
            {
                if (groupType=="Students")
                {
                    totalPrice *= 0.85;
                }
                else if (groupType == "Bussiness")
                {
                    group -= 10;

                    double newPrice = totalPrice * group;
                    totalPrice = newPrice;

                }
            }
            else if (group >= 100)
            {
                if (groupType == "Bussiness")
                {
                    group -= 10;

                    double newPrice = totalPrice * group;
                    totalPrice = newPrice;

                }
            }
            else if (group>=10&&group<=20)
            {
                if (groupType == "Regular")
                {
                    totalPrice -= 2;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");

        }
    }
}
