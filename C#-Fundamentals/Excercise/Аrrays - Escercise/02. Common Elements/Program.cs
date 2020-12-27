using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(" ");// split защото искат по празно място 
            string[] array2 = Console.ReadLine().Split(" ");
            foreach (string elementTwo in array2)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    if (elementTwo == array1[i])
                    {
                        Console.Write(elementTwo + " ");
                        break;
                    }
                }
            }
        }
    }
}
