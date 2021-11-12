using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
   public class Warrior : BaseHero
    {
        public Warrior(string name)
        {
            Name = name;
            Power = 100;
        }
        public override string Name { get; set; }
        public override int Power { get;}


        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
