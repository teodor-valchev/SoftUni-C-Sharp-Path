using System;
using System.Collections.Generic;

namespace Guild
{
    public class Guild
    {
        public List<Player> roaster;

        public Guild(string name, int capacity)
        {

            Name = name;
            Capacity = capacity;
            roaster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roaster.Count;

        public void AddPlayer(Player player)
        {
            if (roaster.Count < Capacity)
            {
                roaster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = roaster.Find(p => p.Name == name);
            if (player != null)
            {
                roaster.Remove(player);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Player player = roaster.Find(p => p.Name == name);

            if (player.Rank == "Trial")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = roaster.Find(p => p.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] players = roaster.FindAll(p => p.Class == clas).ToArray();
            roaster.RemoveAll(p => p.Class == clas);

            return players;
        }

        public string Report()
        {
            return $"Players in the guild: {Name}"+Environment.NewLine+string.Join(Environment.NewLine,roaster);
        }

    }
}
