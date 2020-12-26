using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
            int[] arr2 = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int sum = 0;
            

            for (int i = 0; i < arr1.Length; i++)
            {
                int currentnum1 = arr1[i];
                int curentnum2 = arr2[i];
                
                if (currentnum1==curentnum2)
                {
                    sum += currentnum1;
                    
                    
                }
                else if (currentnum1!=curentnum2)
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;

                }

            }
            Console.WriteLine($"Arrays are identical. Sum: {sum} ");

        }
      
    }
}
