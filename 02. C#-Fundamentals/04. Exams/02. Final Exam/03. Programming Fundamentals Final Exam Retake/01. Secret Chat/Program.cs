using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string input = Console.ReadLine();
            

            while (input != "Reveal")
            {
                string[] tokens = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);

                    encryptedMessage = encryptedMessage.Insert(index, " ");
                    Console.WriteLine(encryptedMessage);
                  


                }
                else if (command == "Reverse")
                {
                    string substring = tokens[1];


                    if (encryptedMessage.Contains(substring))
                    {
                        int lenght = substring.Length;
                        int index = encryptedMessage.Length - lenght;
                        string cut = encryptedMessage.Substring(index, lenght);

                        string reverse = "";
                        for (int i = cut.Length - 1; i >= 0; i--)
                        {
                            reverse += cut[i];
                        }
                        
                        encryptedMessage = encryptedMessage.Replace(substring, reverse);
                        Console.WriteLine(encryptedMessage);
                    }

                    else
                    {
                        Console.WriteLine("error");
                        input = Console.ReadLine();
                        continue;
                    }

                    

                }
                else if (command == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replace = tokens[2];

                    encryptedMessage = encryptedMessage.Replace(substring, replace);
                    Console.WriteLine(encryptedMessage);

                }

               
                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {encryptedMessage}");
        }
    }
}
