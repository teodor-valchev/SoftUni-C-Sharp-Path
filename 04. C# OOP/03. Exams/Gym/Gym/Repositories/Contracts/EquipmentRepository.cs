using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Repositories.Contracts
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipments;
        public EquipmentRepository()
        {
            equipments = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => equipments.AsReadOnly();

        public void Add(IEquipment equipment) => equipments.Add(equipment);


        public IEquipment FindByType(string type)
        {
            var serchedEquipment = equipments.Find(x => x.GetType().Name == type);
            if (serchedEquipment == null)
            {
                return null;
            }
            return serchedEquipment;
        }

        public bool Remove(IEquipment equipment) => equipments.Remove(equipment);

    }
}
