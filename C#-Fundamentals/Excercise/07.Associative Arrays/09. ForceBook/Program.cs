using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var userBySide = new Dictionary<string, string>();
            var sideByUsers = new Dictionary<string, int>();

            string input = string.Empty;
            string side = string.Empty;
            string user = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    GetAddedDictinaries(userBySide, sideByUsers, input, side, user);
                }
                else if (input.Contains(" -> "))
                {
                    GetDictinaries(userBySide, sideByUsers, input, side, user);
                }
            }
            PrintResult(sideByUsers, userBySide);
        }

        private static void GetDictinaries
            (Dictionary<string, string> userBySide, Dictionary<string, int> sideByUsers, string input, string side, string user)
        {
            string[] inputCommand = input.Split(" -> ");

            user = inputCommand[0];
            side = inputCommand[1];

            if (userBySide.ContainsKey(user) && userBySide[user] != side && sideByUsers.ContainsKey(userBySide[user]))
            {
                sideByUsers[userBySide[user]]--;

                if (!sideByUsers.ContainsKey(side))
                {
                    sideByUsers.Add(side, 0);
                }
                sideByUsers[side]++;

                userBySide[user] = side;
            }
            else if (!userBySide.ContainsKey(user))
            {
                if (!sideByUsers.ContainsKey(side))
                {
                    sideByUsers.Add(side, 0);
                }
                sideByUsers[side]++;
                userBySide[user] = side;
            }
            Console.WriteLine($"{user} joins the {side} side!");
        }

        private static void GetAddedDictinaries
            (Dictionary<string, string> userBySide, Dictionary<string, int> sideByUsers, string input, string side, string user)
        {
            string[] inputCommand = input.Split(" | ");

            side = inputCommand[0];
            user = inputCommand[1];

            if (!userBySide.ContainsKey(user))
            {
                userBySide.Add(user, side);

                if (!sideByUsers.ContainsKey(side))
                {
                    sideByUsers.Add(side, 0);
                }
                sideByUsers[side]++;
            }
        }

        private static void PrintResult(Dictionary<string, int> sideByUsers, Dictionary<string, string> userBySide)
        {
            foreach (var kvp in sideByUsers.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value}");

                    foreach (var item in userBySide.OrderBy(k => k.Key))
                    {
                        if (item.Value == kvp.Key)
                        {
                            Console.WriteLine($"! {item.Key}");
                        }
                    }
                }
            }
        }
    }
}
