using System;

namespace Mid_Exam_Alex
{
    class Program
    {
        static void Main(string[] args)
        {
            int person1 = int.Parse(Console.ReadLine());
            int person2 = int.Parse(Console.ReadLine());
            int person3 = int.Parse(Console.ReadLine());
            int totalHelp = person1 + person2 + person3;

            int totalPeopleCount = int.Parse(Console.ReadLine());
            int hour = 0;

            while (totalPeopleCount > 0)
            {
                totalPeopleCount -= totalHelp;
                hour++;
                if (hour % 4 == 0)
                {
                    hour++;
                }

            }

            Console.WriteLine($"Time needed: {hour}h.");
        }
    }
}
