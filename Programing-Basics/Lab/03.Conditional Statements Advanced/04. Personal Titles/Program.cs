using System;

namespace _04._Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = int.Parse(Console.ReadLine());
            char type = char.Parse(Console.ReadLine());

            if (age>=16)
            {
                if (type=='m')
                {
                    Console.WriteLine("Mr.");
                }
                else if (type=='f')
                {
                    Console.WriteLine("Ms.");
                }
            }
            else if (age<=16)
            {
                if (type=='m')
                {
                    Console.WriteLine("Master");
                }
                else if (type=='f')
                {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}
