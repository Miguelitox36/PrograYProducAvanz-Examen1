﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograYProducAvanz_Examen1
{
    public class Game
    {
        private Player player;
        private Queue<Enemy> enemies = new Queue<Enemy>();
        private Stack<string> decisionHistory = new Stack<string>();
        private Dictionary<string, int> stats = new Dictionary<string, int>();

        public void Start()
        {
            Console.WriteLine("Bienvenido al RPG de consola.");
            Console.WriteLine("Nombre del jugador: ");
            string name = Console.ReadLine();

            int life = GetStat("vida", 100);
            int damage = 100 - life;

            player = new Player(name, life, damage);

            stats["vida"] = life;
            stats["daño"] = damage;

            enemies.Enqueue(new Enemy("Orco", 50, 5));
            enemies.Enqueue(new Enemy("Elfo", 30, 10));
            enemies.Enqueue(new Enemy("Muerto", 20, 8));

            while (enemies.Count > 0 && player.IsAlive)
            {
                Enemy current = enemies.Dequeue();
                Console.WriteLine($"\n¡Un enemigo aparece! {current.Name} - HP: {current.Health}");

                try
                {
                    Combat(current);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("¡Ocurrió un error en el combate: !" + ex.Message);
                }

                Console.WriteLine("¿Quieres usar poción? (s/n)");
                string decision = Console.ReadLine();
                decisionHistory.Push(decision);
                
                if (decision == "s")
                {
                    player.Heal(10);
                    player.Backpack.AddItem("Poción usada");
                }
            }

            Console.WriteLine(player.IsAlive ? "¡Has Ganado!" : "Has sido derrotado" );
            player.Backpack.ShowItems();

            Console.WriteLine("\nHistorial de decisiones: ");
            foreach (Enemy d in enemies)
                Console.WriteLine("- " + d);
        }

        private int GetStat(string statName, int max)
        {
            while (true)
            {
                Console.WriteLine($"Distribuye puntos a {statName} (máx {max}");
                if (int.TryParse(Console.ReadLine(), out int value) && value >= 0 && value <= max)
                    return value;

                Console.WriteLine("Valor inválido. Intenta de nuevo.");
            }
        }

        private void Combat(Enemy enemy)
        {
            while (player.IsAlive && enemy.IsAlive)
            {
                player.Attack(enemy);
                if (enemy.IsAlive)
                    enemy.Attack(player);
            }
        }
    }
}
