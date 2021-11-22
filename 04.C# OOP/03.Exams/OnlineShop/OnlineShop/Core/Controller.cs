using OnlineShop.Common.Constants;
using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using IComponent = OnlineShop.Models.Products.Components.IComponent;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                IComponent isFound = components.Find(x => x.Id == id);

                if (isFound != null)
                {
                    throw new ArgumentException(ExceptionMessages.ExistingComponentId);
                }

                IComputer comp = computers.Find(x => x.Id == computerId);

                if (comp!=null)
                {
                    computers.Add(comp);
                }
                components.Add(component);
           
                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                IComponent isFound = components.Find(x => x.Id == id);

                if (isFound != null)
                {
                    throw new ArgumentException(ExceptionMessages.ExistingComponentId);
                }

                IComputer comp = computers.Find(x => x.Id == computerId);
                if (comp != null)
                {
                    comp.AddComponent(isFound);
                }
                components.Add(component);

                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                IComponent isFound = components.Find(x => x.Id == id);

                if (isFound != null)
                {
                    throw new ArgumentException(ExceptionMessages.ExistingComponentId);
                }

                IComputer comp = computers.Find(x => x.Id == computerId);
                if (comp != null)
                {
                    comp.AddComponent(isFound);
                }
                components.Add(component);

                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                IComponent isFound = components.Find(x => x.Id == id);

                if (isFound != null)
                {
                    throw new ArgumentException(ExceptionMessages.ExistingComponentId);
                }

                IComputer comp = computers.Find(x => x.Id == computerId);
                if (comp != null)
                {
                    comp.AddComponent(isFound);
                }
                components.Add(component);

                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                IComponent isFound = components.Find(x => x.Id == id);

                if (isFound != null)
                {
                    throw new ArgumentException(ExceptionMessages.ExistingComponentId);
                }

                IComputer comp = computers.Find(x => x.Id == computerId);
                if (comp != null)
                {
                    comp.AddComponent(isFound);
                }
                components.Add(component);

                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else if (componentType == "VideoCard")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                IComponent isFound = components.Find(x => x.Id == id);

                if (isFound != null)
                {
                    throw new ArgumentException(ExceptionMessages.ExistingComponentId);
                }

                IComputer comp = computers.Find(x => x.Id == computerId);
                if (comp != null)
                {
                    comp.AddComponent(isFound);
                }
                components.Add(component);

                return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = new DesktopComputer(id, manufacturer, model, price);
            IComputer laptop = new Laptop(id, manufacturer, model, price);

            if (computerType == computer.GetType().Name)
            {
                IComputer search = computers.Where(x => x.Id == id).FirstOrDefault();

                if (search != null)
                {
                    throw new ArgumentException(ExceptionMessages.ExistingComputerId);
                }

                computers.Add(computer);
                return string.Format(SuccessMessages.AddedComputer, id);
            }
            else if (computerType == laptop.GetType().Name)
            {
                IComputer search = computers.Where(x => x.Id == id).FirstOrDefault();
                if (search != null)
                {
                    throw new ArgumentException(ExceptionMessages.ExistingComputerId);
                }
                computers.Add(laptop);
                return string.Format(SuccessMessages.AddedComputer, id);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            return "s";
        }

        public string BuyBest(decimal budget)
        {
            return "s";
        }

        public string BuyComputer(int id)
        {
            return "s";
        }

        public string GetComputerData(int id)
        {
            IComputer computer = computers.Where(x => x.Id == id).FirstOrDefault();

            if (computer != null)
            {
                return computer.ToString();
            }
            return null;
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComponent component = components.Where(x => x.GetType().Name == componentType).FirstOrDefault();
            IComputer comp = computers.Where(x => x.Id == computerId).FirstOrDefault();


            if (component != null && comp != null)
            {

                comp.RemoveComponent(componentType);
                components.Remove(component);
                return string.Format(SuccessMessages.RemovedComponent, componentType, computerId);
            }

            throw new ArgumentException(ExceptionMessages.NotExistingComputerId);

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            return "s";
        }
    }
}
