using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3_C.Models;

namespace Lab_3_C.Medicines
{
    internal class Bandage : Medicine
    {
        private int[] healing;
        public int[] Healing { get { return healing; } }

        public Bandage()
        {
            Name = "Бинт";
            Description = "Восстановление +20 - +30";
            healing = new int[] { 20, 30 };
        }

        public int GetHeal() { 
            Random random = new Random();
            return random.Next(Healing[0] - 1, Healing[1]);
        }
    }
}
