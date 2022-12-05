using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();


            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = tokens[0];
                string cmd = tokens[1];

                if (cmd == "joined")
                {
                    if (!app.ContainsKey(vloggerName))
                    {
                        app.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        app[vloggerName].Add("following", new SortedSet<string>());
                        app[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (cmd == "followed")
                {
                    string vloggerNameTwo = tokens[2];

                    if (app.ContainsKey(vloggerName) && app.ContainsKey(vloggerNameTwo) && vloggerName != vloggerNameTwo)
                    {
                        app[vloggerName]["following"].Add(vloggerNameTwo);
                        app[vloggerNameTwo]["followers"].Add(vloggerName);
                    }
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedApp = app.OrderByDescending(kvp => kvp.Value["followers"].Count)
                .ThenBy(kvp => kvp.Value["following"].Count).ToDictionary(k => k.Key, v => v.Value);
            int count = 0;
            foreach (var item in sortedApp)
            {
                Console.WriteLine($"{++count}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");

                if (count == 1)
                {
                    foreach (var follower in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }

        }
    }
}
