using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> heroes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int hp = int.Parse(tokens[1]);
                int mp = int.Parse(tokens[2]);

                heroes.Add(name, new Dictionary<string, int>()
                {
                    {"hp" ,hp},
                    {"mp",mp }
                });
            }

            int maxHp = 100;
            int maxMp = 200;

            string command = Console.ReadLine();

            //CastSpell – {hero name} – {MP needed} – {spell name} 
            while (command != "End")
            {
                string[] tokens = command.Split(" - ");
                string name = tokens[0];
                string heroName = tokens[1];

                if (name == "CastSpell")
                {
                    
                    int mpNeeded = int.Parse(tokens[2]);
                    string spellName = tokens[3];

                    if (heroes[heroName]["mp"] > mpNeeded)
                    {
                        heroes[heroName]["mp"] -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName]["mp"]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                //TakeDamage – {hero name} – {damage} – {attacker}
                else if (name == "TakeDamage")
                {
                    
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];

                    heroes[heroName]["hp"] -= damage;

                    if (heroes[heroName]["hp"] > 0)
                    {
                       
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName]["hp"]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);
                        
                    }
                   
                }
                //Recharge – {hero name} – {amount}
                else if (name == "Recharge")
                {
                    
                    int amountMp = int.Parse(tokens[2]);
                    int cuurentMp = heroes[heroName]["mp"];
                    heroes[heroName]["mp"] += amountMp;
                    int tempMP = amountMp;

                    if (heroes[heroName]["mp"]>200)
                    {

                        int fullMp = 200;
                        fullMp -= cuurentMp;
                        
                        heroes[heroName]["mp"] = maxMp;
                       
                        Console.WriteLine($"{heroName} recharged for {fullMp} MP!");
                        
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {tempMP} MP!");
                    }



                }

                else if (name == "Heal")
                {
                    
                    int amountHp = int.Parse(tokens[2]);
                    int cuurentHp = heroes[heroName]["hp"];
                    heroes[heroName]["hp"] += amountHp;
                    int tempHP = amountHp;

                    if (heroes[heroName]["hp"] > 100)
                    {

                        int fullHp = 100;
                        fullHp -= cuurentHp;

                        heroes[heroName]["hp"] = maxHp;

                        Console.WriteLine($"{heroName} healed for {fullHp} HP!");

                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {tempHP} HP!");
                    }

                }

                command = Console.ReadLine();
            }

            heroes = heroes.OrderByDescending(h => h.Value["hp"])
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var hero in heroes)
            {
                int hp = hero.Value["hp"];
                int mp = hero.Value["mp"];
                Console.WriteLine($"{hero.Key}");                             
                Console.WriteLine($"  HP: {hp}");                
                Console.WriteLine($"  MP: {mp}");
            }
            
        }
    }
}
