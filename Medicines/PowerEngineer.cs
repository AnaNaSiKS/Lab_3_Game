using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3_C.Models;

namespace Lab_3_C.Medicines
{
    internal class PowerEngineer : Medicine
    {
        private int removeCooldown;
        public int RemoveCooldown { get { return removeCooldown; } }
        public PowerEngineer()
        {
            Name = "Энергетик";
            Description = "Востанавливает ультимативную способность персонажу";
            removeCooldown = 20;
        }
    }
}
