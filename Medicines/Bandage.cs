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
        public int[] Healing { get { return healing; } set { healing = value; } }

        public Bandage()
        {
            Name = "Бинт";
            Description = "Восстановление +20 - +30";
            Healing = new int[] { 20, 30 };
        }
    }
}
