using Lab_3_C.Models;
using Lab_3_C.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_C
{
    internal class Playground
    {
        public List<Monster> monsters = new List<Monster>();
        public List<Models.Object> objects = new List<Models.Object>();
        public int[,] walls = new int[28, 58];


        public void DeleteMonster(Monster monster) { 
            monsters.Remove(monster);
        }

        public void DeleteChest(Models.Object @object) {
            objects.Remove(@object);
        }

        public int CheckMonsters() { return monsters.Count; }
    }
}
