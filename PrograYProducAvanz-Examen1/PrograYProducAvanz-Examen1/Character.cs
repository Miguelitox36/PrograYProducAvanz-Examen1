using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograYProducAvanz_Examen1
{
    public abstract class Character : IAttackable
    {
        public string Name;
        public int Health;
        public int Damage;

        public Character(string name, int health, int damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;

        }

        public virtual void Attack(Character target)
        {
            target.Health -= Damage;
            Console.WriteLine($"{Name} ataca a {target.Name} por {Damage} de daño.");
        }

        public bool IsAlive => Health > 0;
    }
        
}
