using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removeString = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            int index = text.IndexOf(removeString);

            while (index != -1)
            {
                text = text.Remove(index, removeString.Length);

                index = text.IndexOf(removeString);
            }

            Console.WriteLine(text);
        }
    }
}
