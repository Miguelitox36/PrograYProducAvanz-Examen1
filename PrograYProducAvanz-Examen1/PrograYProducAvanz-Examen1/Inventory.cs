using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograYProducAvanz_Examen1
{
    public class Inventory<T>
    {
        private List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void ShowItems()
        {
            Console.WriteLine("Inventario: ");
            foreach (var item in items)
            {
                Console.WriteLine("- " + item);
            }
        }
    }
}
