using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, string>> composers = new Dictionary<string, Dictionary<string, string>>(n);



            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("|");
                string piece = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];

                composers.Add(piece, new Dictionary<string, string>()
                {
                    {"composer",composer },
                    {"key",key }
                });
            }


            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] tokens = command.Split("|");
                string name = tokens[0];
                string piece = tokens[1];

                if (name == "Add")
                {
                    string composer = tokens[2];
                    string key = tokens[3];

                    if (!composers.ContainsKey(piece))
                    {
                        composers.Add(piece, new Dictionary<string, string>()
                {
                    {"composer",composer },
                    {"key",key }
                });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }

                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (name=="Remove")
                {
                    if (!composers.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        Console.WriteLine($"Successfully removed {piece}!");
                        composers.Remove(piece);
                    }
                }
                else if (name== "ChangeKey")
                {
                    string changeKey = tokens[2];
                    string currentKey = composers[piece]["key"];

                    if (composers.ContainsKey(piece))
                    {
                        //composers.Remove(currentKey);
                        composers[piece]["key"]=changeKey;

                        Console.WriteLine($"Changed the key of {piece} to {changeKey}!");
                        
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }


            composers = composers.OrderBy(c => c.Key).ThenBy(c => c.Value["composer"])
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var composer in composers)
            {
                string singer = composer.Value["composer"];
                string key = composer.Value["key"];

                Console.WriteLine($"{composer.Key} -> Composer: {singer}, Key: {key}");


            }

        }
    }
}
