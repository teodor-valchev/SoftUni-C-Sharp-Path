using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {

        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance => components.Count == 0 ? base.OverallPerformance : components.Average(x => x.OverallPerformance);
        public override decimal Price => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        public SerializationInfo ExceptionMessage { get; private set; }

        public void AddComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component, GetType().Name, Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Contains(peripheral))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = components.Where(x => x.Model == componentType).FirstOrDefault();

            if (components.Count == 0 && component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id));
            }

            components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = peripherals.Where(x => x.Model == peripheralType).FirstOrDefault();

            if (components.Count == 0 && peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }
            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {OverallPerformance}. Price: {Price} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})");
            sb.AppendLine($"Components ({components.Count}):");
            foreach (var component in components)
            {
                sb.AppendLine($"{component}");
            }
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripherals.Average(x => x.OverallPerformance)}):");

            foreach (var periphel in peripherals)
            {
                sb.AppendLine($"{periphel}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
