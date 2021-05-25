using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] arr2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var elementTwo in arr2)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] == elementTwo)
                    {
                        Console.Write(elementTwo + " ");
                    }
                }
            }
         
        }
    }
}
