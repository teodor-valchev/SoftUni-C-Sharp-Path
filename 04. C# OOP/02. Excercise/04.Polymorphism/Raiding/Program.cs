using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBaseHero> raidGroup = new List<IBaseHero>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Paladin")
                {
                    IBaseHero paladin = new Paladin(name);
                    raidGroup.Add(paladin);
                }
                else if (heroType == "Rogue")
                {
                    IBaseHero rogue = new Rogue(name);
                }
                else if (heroType == "Warrior")
                {
                    IBaseHero warrior = new Warrior(name);
                    raidGroup.Add(warrior);
                }
                else if (heroType == "Druid")
                {
                    IBaseHero druid = new Druid(name);
                    raidGroup.Add(druid);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossHp = int.Parse(Console.ReadLine());
            foreach (var person in raidGroup)
            {
                Console.WriteLine(person.CastAbility());
                bossHp -= person.Power;
            }
            
            if (bossHp <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }


        }
    }
}
