using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@#+)(?<name>[a-zA-Z\d]{3,}[A-Z])(@#+)";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());
            List<char> validBarcode = new List<char>();

            
            for (int i = 0; i < n; i++)
            {
                string products = Console.ReadLine();
                Match match = regex.Match(products);

                if (match.Success)
                {
                    string name = match.Groups[3].Value;
                    string temp = string.Empty;

                    for (int j = 0; j < name.Length; j++)
                    {
                        char current = name[j];
                        
                        if (char.IsDigit(current))
                        {
                            temp += current;
                        }

                        
                    }
                    if (temp == "")
                    {
                        Console.WriteLine("product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {temp}");
                    }


                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
               
            }
        }
    }
}
