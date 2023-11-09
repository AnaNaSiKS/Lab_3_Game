using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_C.Models
{
    internal class Inventory
    {
        public List<Medicine> items;
        public Inventory()
        {
            items = new List<Medicine>();
        }

        public void Show()
        {
            if (items.Count == 0)
                Console.WriteLine("Инвентарь пуст");
            else
            {
                Console.WriteLine("Инвентарь:");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Name + $" ({item.Description})");
                }
            }
        }

        public void Add(Medicine medicine)
        {
            items.Add(medicine);
        }
    }
}
