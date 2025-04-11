using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograYProducAvanz_Examen1
{
   public class Player : Character
    {
        public Inventory<string> Backpack;

        public Player(string name, int health, int damage) : base(name, health, damage)
        {
            Backpack = new Inventory<string>();
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} se curó {amount} de vida.");
        }
    }
}
