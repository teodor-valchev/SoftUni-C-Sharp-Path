using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> output = new Dictionary<string, List<double>>();

            string command = Console.ReadLine();

            while (command!="buy")
            {
                string[] currentProducts = command.Split();
                string productName = currentProducts[0];
                double productPrice = double.Parse(currentProducts[1]);
                double quanity = double.Parse(currentProducts[2]);

                if (!output.ContainsKey(productName))
                {
                    List<double> priceAndQuanity = new List<double> { productPrice, quanity };
                    output.Add(productName, priceAndQuanity);
                }
                else
                {
                    output[productName][0] = productPrice;
                    output[productName][1] = output[productName][1] + quanity;
                }
                command = Console.ReadLine();

                
            }
            foreach (var item in output)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
