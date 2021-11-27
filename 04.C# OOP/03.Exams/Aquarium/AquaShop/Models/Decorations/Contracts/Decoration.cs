using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations.Contracts
{
    public abstract class Decoration : IDecoration
    {
        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }

        public int Comfort { get;  }

        public decimal Price { get; }
    }
}
