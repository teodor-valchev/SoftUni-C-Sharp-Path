using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Legendary_Farming
{
    class Program
    {



        static void Main(string[] args)
        {
            Dictionary<string, int> keyMatirial = new Dictionary<string, int>();
            Dictionary<string, int> junkMatirial = new Dictionary<string, int>();
            keyMatirial["shards"] = 0;
            keyMatirial["motes"] = 0;
            keyMatirial["fragments"] = 0;
            bool hasToBreak = false;

            while (true)
            {

                string[] input = Console.ReadLine().Split();


                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string materials = input[i + 1].ToLower();

                    if (materials == "shards" || materials == "motes" || materials == "fragments")
                    {
                        keyMatirial[materials] += quantity;

                        if (keyMatirial[materials] >= 250)
                        {
                            keyMatirial[materials] -= 250;
                            if (materials == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }

                            else if (materials == "motes")
                            {


                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            else if (materials == "fragments")
                            {


                                Console.WriteLine("Valanyr obtained!");

                            }

                            hasToBreak = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMatirial.ContainsKey(materials))
                        {
                            junkMatirial.Add(materials, 0);
                        }
                        junkMatirial[materials] += quantity;

                    }
                }

                if (hasToBreak)
                {
                    break;
                }

            }
            Dictionary<string, int> filtredKeyMatirials = keyMatirial.OrderByDescending(v => v.Value).ThenBy(k => k.Key).ToDictionary(a => a.Key, a => a.Value);

            foreach (var kvp in filtredKeyMatirials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMatirial.OrderBy(k => k.Key))
            {


            }
        }
    }
}



        
