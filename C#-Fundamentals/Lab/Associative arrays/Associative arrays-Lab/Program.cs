using System;
using System.Collections.Generic;
using System.Linq;

namespace Associative_arrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();

                if (dictionary.ContainsKey(word))
                {
                    dictionary[word].Add(synonim);
                }

                else
                {
                    dictionary.Add(word, new List<string>() { synonim});
                }
                

              
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ",item.Value)}");
            }
            
           
        }
    }
}
