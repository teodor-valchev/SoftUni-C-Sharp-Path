using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int person1 = int.Parse(Console.ReadLine());
            int person2 = int.Parse(Console.ReadLine());
            int person3 = int.Parse(Console.ReadLine());

            int totalEmployees = person1 + person2 + person3;
            int totalCountOfPeople = int.Parse(Console.ReadLine());

            int hours = 0;
            while (totalCountOfPeople > 0)
            {
                hours++;
                totalCountOfPeople -= totalEmployees;
               


                if (hours % 4 == 0)
                {
                    hours++;
                }

            }
            
            Console.WriteLine($"Time needed: {hours}h.");
            
        }
    }
}
