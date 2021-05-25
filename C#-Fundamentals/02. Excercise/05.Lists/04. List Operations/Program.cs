using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command.ToUpper()!= "END")
            {
                string[] tokens = command
                    .Split("", StringSplitOptions.RemoveEmptyEntries);
               
                

                if (tokens[0].ToUpper()=="ADD")
                {
                    numbers.Add(int.Parse(tokens[1]));
                }
                else if (tokens[0].ToUpper() == "INSERT")
                {
                    int index = int.Parse(tokens[2]);
                    

                    if (isValidIndex(index,numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, int.Parse(tokens[1]));
                    }
                }
                else if (tokens[0].ToUpper() == "REMOVE")
                {
                    int index = int.Parse(tokens[1]);

                    if (isValidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }

                else if (tokens[0].ToUpper() == "SHIFT LEFT")
                {
                    int rotations = int.Parse(tokens[2]);

                    for (int i = 0; i < rotations; i++)
                    {
                        int firstElement = numbers[0];
                        for (int j = 0; j < numbers.Count; j++)
                        {
                            numbers[j] = numbers[j + 1];
                        }
                        numbers[numbers.Count - 1] = firstElement;
                    }

                    
                    
                }
                else if (tokens[0].ToUpper() == "SHIFT RIGHT")
                {
                    int rotations = int.Parse(tokens[2]);

                    for (int i = 0; i < rotations; i++)
                    {
                        int lastElement = numbers[numbers.Count-1];

                        for (int j = numbers.Count-1; j >0; j--)
                        {
                            numbers[j] = numbers[j - 1];
                        }
                        numbers[0]=lastElement;
                    }



                }


                command = Console.ReadLine();
            }
            Console.Write(string.Join(" ",numbers));
        } 

        public static bool isValidIndex(int index , int count)
        {
            return index > count || index < 0;
        }
    }
}
