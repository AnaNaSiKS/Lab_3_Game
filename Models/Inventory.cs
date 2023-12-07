using Lab_3_C.Medicines;
using Lab_3_C.Monsters;
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
                Console.Write(" Инвентарь: пуст");
                y++;
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" Инвентарь:");
                y++;

                List<Bandage> bandages = items.OfType<Bandage>().ToList();
                List<Chocolate> chocolates = items.OfType<Chocolate>().ToList();
                List<PowerEngineer> powerEngineers = items.OfType<PowerEngineer>().ToList();

                if (bandages.Count > 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write($" {bandages[0].Name} ({bandages[0].Description}) x{bandages.Count}");
                    y++;
                }
                if (chocolates.Count > 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write($" {chocolates[0].Name} ({chocolates[0].Description}) x{chocolates.Count}");                    
                    y++;
                }
                if (powerEngineers.Count > 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write($" {powerEngineers[0].Name} ({powerEngineers[0].Description}) x{powerEngineers.Count}");
                    y++;
                }
            }
        }

        public void Add(Medicine medicine)
        {
            items.Add(medicine);
        }

        public void Remove(Medicine medicine)
        {
            items.Remove(medicine);
        }
    }
}
