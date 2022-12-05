using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<IBakedFood> foodCollection;
        private List<IDrink> drinkCollection;
        private List<ITable> tableCollection;
        private decimal income;

        public Controller()
        {
            foodCollection = new List<IBakedFood>();
            drinkCollection = new List<IDrink>();
            tableCollection = new List<ITable>();
        }


        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            drinkCollection.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            foodCollection.Add(food);
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            tableCollection.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            var listTable = tableCollection.FindAll(x => x.IsReserved == false);

            StringBuilder sb = new StringBuilder();

            foreach (var table in listTable)
            {
              sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {   
            return $"Total income: {income:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tableCollection.Find(x => x.TableNumber == tableNumber);
            var bill = table.GetBill();
            income += bill;
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");
   
            return sb.ToString().TrimEnd();
                     
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            IDrink drink = drinkCollection.Find(x => x.Name == drinkName && x.Brand == drinkBrand);
            ITable table = tableCollection.Find(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            IBakedFood food = foodCollection.Find(x => x.Name == foodName);
            ITable table = tableCollection.Find(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tableCollection.Find(x => x.IsReserved == false && x.Capacity > numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";


        }
    }
}
