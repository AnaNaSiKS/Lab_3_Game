using Lab_3_C.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_C.Medicines
{
    internal class Chocolate : Medicine
    {
        private int healing;
        private int gain;
        public int Healing { get { return healing; } }
        public int Gain { get { return gain; }}

        public Chocolate() {
            Name = "Шоколад";
            Description = "Восстановление +5. Базовая атака +10";
            healing = 5;
            gain = 10;
        }

        
    }
}
