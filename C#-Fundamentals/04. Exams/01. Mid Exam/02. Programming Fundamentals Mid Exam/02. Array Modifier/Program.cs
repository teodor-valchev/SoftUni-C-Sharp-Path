using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] cmdArg = command.Split();
                string name = cmdArg[0];
               

                if (name =="swap")
                {
                    int firstIndex = int.Parse(cmdArg[1]);
                    int secondIndex = int.Parse(cmdArg[2]);

                    int temp = numbers[firstIndex];

                    numbers[firstIndex] = numbers[secondIndex];
                    numbers[secondIndex] = temp;
                    temp = secondIndex;
                   
                }
                else if (name == "multiply")
                {
                    int firstIndex = int.Parse(cmdArg[1]);
                    int secondIndex = int.Parse(cmdArg[2]);

                    int saveIndex = numbers[1];
                  int result =  numbers[firstIndex] *= numbers[secondIndex];
                    saveIndex=result;


                }
                else if (name =="decrease")
                {
                    for (int i = 0; i <= numbers.Length-1; i++)
                    {
                        numbers[i] -= 1;
                        
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", " , numbers));
        }
    }
}
