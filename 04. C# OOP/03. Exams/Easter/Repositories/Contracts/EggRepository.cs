using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Repositories.Contracts
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;
        public EggRepository()
        {
            eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => eggs.AsReadOnly();

        public void Add(IEgg Egg) => eggs.Add(Egg);
       

        public IEgg FindByName(string name)
        {
            var serchedEgg = eggs.Find(e => e.Name == name);
            if (serchedEgg == null)
            {
                return null;
            }
            return serchedEgg;
        }

        public bool Remove(IEgg Egg)=> eggs.Remove(Egg);

    }
}
