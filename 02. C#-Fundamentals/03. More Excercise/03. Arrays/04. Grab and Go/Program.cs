using System;
using System.Linq;

namespace _04._Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int existNumber = int.Parse(Console.ReadLine());
            int sum = 0;
           

            for (int i = 0; i < array.Length; i++)
            {
                int numberToBeFound = array[i];
                if (existNumber==array[i])
                {
                    sum += array[i];
                }
                

              

            }
            Console.WriteLine(sum);
           
        }
    }
}
