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
        public int Healing { get; set; }
        public int Gain { get; set; }

        public Chocolate() {
            Name = "Шоколад";
            Description = "Шоколад Snickers. Восстанавливает здоровье в размере 5 очков и усиляет силу атаки на 10 очков";
            Healing = 5;
            Gain = 10;
        }
    }
}
