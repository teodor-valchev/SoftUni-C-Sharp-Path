using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string contestInput = Console.ReadLine();

            while (contestInput != "end of contests")
            {
                string[] tokens = contestInput.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];

                contests.Add(contest, password);


                contestInput = Console.ReadLine();
            }
            SortedDictionary<string, Dictionary<string, int>> userSubmissons = new SortedDictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();


            while (command != "end of submissions")
            {
                string[] tokens = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contests.ContainsKey(contest) || contests[contest] != password)
                {
                    command = Console.ReadLine();
                    continue;
                }
                if (!userSubmissons.ContainsKey(username))
                {
                    userSubmissons.Add(username, new Dictionary<string, int>());
                }
                if (!userSubmissons[username].ContainsKey(contest))
                {
                    userSubmissons[username].Add(contest, points);
                }
                else
                {
                    int oldPoints = userSubmissons[username][contest];

                    if (points > oldPoints)
                    {
                        userSubmissons[username][contest] = points;
                    }
                }

                command = Console.ReadLine();
            }
            KeyValuePair<string, Dictionary<string, int>> bestCanditate = userSubmissons.OrderByDescending(kvp => kvp.Value.Values.Sum()).First();
            int totalPoints = bestCanditate.Value.Values.Sum();
            Console.WriteLine($"Best candidate is {bestCanditate.Key} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in userSubmissons)
            {
                Console.WriteLine(user.Key);

                foreach (var contestData in user.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {contestData.Key} -> {contestData.Value}");
                }
            }

        }
    }
}
