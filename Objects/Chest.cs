using Lab_3_C.Medicines;
using Lab_3_C.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_C.Objects
{
    internal class Chest: Models.Object
    {
        public Chest(int x, int y) {
            X = x;
            Y = y;
            Face = "!";
        }

        public Medicine ReturnItems() { 
            Random random = new Random();
            int rd = random.Next(3);
            if (rd == 0)
            {
                return new Bandage();
            }
            else if (rd == 1)
            {
                return new Chocolate();
            }
            else if (rd == 2)
            {
                return new PowerEngineer();
            }
            else return null;
        }
    }
}
