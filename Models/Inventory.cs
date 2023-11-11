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

        public void Show(int x, int y)
        {
            if (items.Count == 0)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" Инвентарь пуст");
                y++;
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" Инвентарь:");
                y++;
                foreach (var item in items)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" " + item.Name + $" ({item.Description})");
                    y++;
                }
            }
        }

        public void Add(Medicine medicine)
        {
            items.Add(medicine);
        }
    }
}
