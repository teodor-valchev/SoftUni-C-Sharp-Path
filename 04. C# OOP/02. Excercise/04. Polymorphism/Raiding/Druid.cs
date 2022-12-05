using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name, int power)
        {
            Name = name;
        }

        public override string Name { get; set; }
        public override int Power { get;}

        public override string CastAbility()
        {           
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
