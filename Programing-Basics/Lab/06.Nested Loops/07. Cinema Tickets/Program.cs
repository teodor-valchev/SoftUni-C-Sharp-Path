using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsTickets = 0;
            int standardTickets = 0;
            int kidsTickets = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input=="Finish")
                {
                    break;
                }
                int freeSpots = int.Parse(Console.ReadLine());
                int currentFreeSports = freeSpots;
                while (currentFreeSports>0)
                {
                    string tickeType = Console.ReadLine();
                    if (tickeType == "End")
                    {
                        break;
                    }
                    currentFreeSports--;

                    if (tickeType=="standard")
                    {
                        standardTickets++;
                    }
                 
                    else if (tickeType=="student")
                    {
                        studentsTickets++;
                    }
                    else if (tickeType == "kid")
                    {
                        kidsTickets++;
                    }


                }
                double freeSpotsInPercentage =100- (currentFreeSports * 1.0 / freeSpots*100);
                Console.WriteLine($"{input} - {freeSpotsInPercentage:f2}% full.");
            }
            int totalTiktes = standardTickets + studentsTickets + kidsTickets;
            double studentTickets = studentsTickets * 1.0 / totalTiktes * 100;
            double standardTicketsTotal = standardTickets * 1.0 / totalTiktes * 100;
            double kidsTicketsTotal = kidsTickets * 1.0 / totalTiktes * 100;

            Console.WriteLine($"Total tickets: {totalTiktes}");

            Console.WriteLine($"{studentTickets:f2}% student tickets.");
            Console.WriteLine($"{standardTicketsTotal:f2}% standard tickets.");
            Console.WriteLine($"{kidsTicketsTotal:f2}% kids tickets.");
        }
        
    }
}
