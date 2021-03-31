using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterial = new Dictionary<string, int>();
            Dictionary<string, int> junkMatirilas = new Dictionary<string, int>();

            keyMaterial["shards"] = 0;
            keyMaterial["motes"] = 0;
            keyMaterial["fragments"] = 0;
            bool hasToBreak = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)// zashtoto vzimame po 2 navednush
                {
                    int quaintity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();// za da vzema sledvashtiq element a ne quanity !!!!

                    if (material == "shards" || material == "motes" || material == "fragments")
                    {
                        keyMaterial[material] += quaintity;

                        if (keyMaterial[material] >= 250)
                        {
                            keyMaterial[material] -= 250;

                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }

                            hasToBreak = true;
                            break;//za da sprem for cikula.
                        }
                    }
                    else
                    {
                        if (!junkMatirilas.ContainsKey(material))
                        {
                            junkMatirilas.Add(material, 0);
                        }
                        junkMatirilas[material] += quaintity;
                    }

                }

                if (hasToBreak)
                {
                    break;
                }
            }
            Dictionary<string, int> filtretKeyMatirilas = keyMaterial
                .OrderByDescending(v => v.Value)
                .ThenBy(k => k.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var kvp in filtretKeyMatirilas)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMatirilas.OrderBy(k=>k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}
