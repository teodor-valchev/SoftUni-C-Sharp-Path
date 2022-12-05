using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish.Contracts
{
    public class FreshwaterFish : Fish
    {
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
        }

        public override int Size => 5;
        public override void Eat()
        {
            Size += 3;
        }
    }
}
