using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] {" -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];
                string[] allCloathing = tokens.Skip(1).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>()
                    );
                }
                Dictionary<string, int> currentColourCloathing = wardrobe[color];
                foreach (var item in allCloathing)
                {
                    if (!currentColourCloathing.ContainsKey(item))
                    {
                        currentColourCloathing.Add(item, 0);
                    }
                    currentColourCloathing[item]++;
                }
  
            }

            string[] serchedData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clothing in color.Value)
                {

                    if (serchedData[0]==color.Key && serchedData[1] ==clothing.Key)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }
                 
                }
            }
        }
    }
}

