using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_C.Models
{
    abstract class Object
    {
        private int x;
        private int y;
        private string face;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public string Face { get { return face; } set { face = value; } }
    }
}
