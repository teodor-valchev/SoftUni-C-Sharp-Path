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
                string UserName = cmdArg[1];

                if (task=="register")
                {
                    string licensePlateNumber = cmdArg[2];
                    if (!output.ContainsKey(UserName))
                    {
                        output.Add(UserName, licensePlateNumber);
                        Console.WriteLine($"{UserName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else if (task=="unregister")
                {
                    if (output.ContainsKey(UserName))
                    {
                        Console.WriteLine($"ERROR: user {UserName} not found");
                    }
                    else
                    {
                        output.Remove(UserName);
                            Console.WriteLine($"{UserName} unregistered successfully");
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
