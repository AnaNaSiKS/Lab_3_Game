using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_C.Models
{
    abstract class Medicine
    {
        private string name;
        private string description;

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
    }
}
