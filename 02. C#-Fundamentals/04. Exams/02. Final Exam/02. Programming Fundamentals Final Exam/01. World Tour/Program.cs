using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] tokens = command.Split();
                string name = tokens[0];
                string[] splite = name.Split(":");
                string name2 = splite[0];
                

                if (name == "Add")
                {
                    string stop = tokens[1];
                    string[] split = stop.Split(":");
                    int index = int.Parse(split[1]);
                    string replace = split[2];

                    if (index > 0 && index <= stops.Length - 1)
                    {
                        stops = stops.Insert(index, replace);
                    }
                    


                }
                else if (name == "Remove")
                {
                    string stop = tokens[1];
                    string[] split = stop.Split(":");
                    int startIndex = int.Parse(split[1]);
                    int endIndex = int.Parse(split[2]);

                    if (startIndex>=0 && endIndex<=stops.Length-1)
                    {
                       string first= stops.Substring(0,startIndex);
                        string second = stops.Substring(startIndex, endIndex - startIndex);
                        string three = stops.Substring(endIndex+1);

                        stops = first + three;


                    }
                  
                }

                else if (name2 == "Switch")
                {
                    string old = splite[1];
                    string newString = splite[2];

                    if (stops.Contains(old))
                    {
                        stops = stops.Replace(old, newString);
                        
                    }
                }

                Console.WriteLine(stops);
                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
