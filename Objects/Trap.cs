using Lab_3_C.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_C.Objects
{
    internal class Trap : Models.Object
    {
        public Trap(int x, int y)
        {
            X = x;
            Y = y;
            Face = "¤";
        }

        public void Hit(Monster monster)
        {
            monster.Hp -= 10;  
        }
    }
}
