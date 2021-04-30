using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRoom = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            int health = 100;
            int bitcoins = 0;
            int rooms = 0;
            int tempHealth = 0;
            




            foreach (var item in dungeonRoom)
            {
                string[] cmdArg = item.Split();
                string name = cmdArg[0];
                int number = int.Parse(cmdArg[1]);

                if (name == "potion")
                {
                    

                    if (health < 100)
                    {
                        tempHealth = health;
                        
                        health += number;

                        

                        if (health > 100)
                        {
                            int diff = 100- tempHealth; 
                            health = 100;
                           
                          
                            Console.WriteLine($"You healed for {diff} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                            continue;

                        }
                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {health} hp.");



                    }

                }
                else if (name == "chest")
                {
                    bitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }

                rooms++;
                if (name != "potion" && name != "chest")
                {
                    health -= number;
                  
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {name}.");
                        Console.WriteLine($"Best room: {rooms}");
                        rooms++;
                        break;
                    }
                    Console.WriteLine($"You slayed {name}.");
                }
                
                
              
            }
            if (health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");

            }
        }
    }
}
       
            

        
