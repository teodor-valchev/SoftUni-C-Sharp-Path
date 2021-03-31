using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> output = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();
                string task = cmdArg[0];
                string username = cmdArg[1];

                if (task == "register")
                {
                    string licensePlateNumber = cmdArg[2];

                    if (!output.ContainsKey(username))
                    {
                        output.Add(username, licensePlateNumber);
                        Console.WriteLine($"{ username}  registered { licensePlateNumber}  successfully");

                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else if (task == "unregister")
                {
                    if (!output.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        output.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
