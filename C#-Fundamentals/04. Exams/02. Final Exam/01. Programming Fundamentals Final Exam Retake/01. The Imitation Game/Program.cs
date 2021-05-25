using System;
using System.Text;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();

            while (command!= "Decode")
            {
                string[] tokens = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                if (name== "ChangeAll")
                {
                    string contains = tokens[1];
                    string change = tokens[2];

                    message.LastIndexOf(contains);
                   message = message.Replace(contains, change);
                }

                else if (name == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string value = tokens[2];

                   message= message.Insert(index, value);
                }

                else if (name == "Move")
                {
                    StringBuilder sb = new StringBuilder();
                    int n = int.Parse(tokens[1]);

                    string first = message.Substring(0, n);
                    string second = message.Substring(n);

                    sb.Append(second);
                    sb.Append(first);
                    message = sb.ToString();
                  

                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
