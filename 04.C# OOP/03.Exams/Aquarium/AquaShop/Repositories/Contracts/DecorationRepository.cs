using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories.Contracts
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => decorations.AsReadOnly();

        public void Add(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = decorations.Where(x => x.GetType().Name == type).FirstOrDefault();

            if (decorations!=null)
            {
                return decoration;
            }
            return null;
        }

        public bool Remove(IDecoration decoration) => decorations.Remove(decoration);
     
    }
}
