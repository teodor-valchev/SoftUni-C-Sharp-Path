using System;
using System.Linq;

namespace _01._Array_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ")
                           .Select(int.Parse)
                           .
                           ToArray();
            int max = 0;
            int min = 0;
            double sum = 0;
            double average = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count++;
                int minValue = arr[0];
                int maxValue = arr[0];
                if (minValue > arr[i])
                {
                    min = arr[i];

                }
                else if (maxValue < arr[i ])
                {
                    max = arr[i];
                }
                 sum+= arr[i];
                average=sum/count;
                
            }
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max =  {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = { average}");
        }
    }
}
