﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3_C.Models;

namespace Lab_3_C.Monsters
{
    internal class Hero : Monster
    {
        public Inventory Inventory { get; set; }
        public Hero(int x, int y)
        {
            Random random = new Random();
  
            MaxHp = random.Next(100, 120);
            Hp = MaxHp;
            if (Hp > 110)
                BasicHit = new int[] { 4, 7 };
            else
                BasicHit = new int[] { 7, 10 };

            AbsoluteHit = new int[] { 45, 55 };

            MaxCooldownAbsoluteHit = 3;
            CooldownAbsoluteHit = MaxCooldownAbsoluteHit;

            MiniFace = "*";

            X = x;
            Y = y;

            Inventory = new Inventory();
        }

        public override void ShowFace(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("   (^_^)");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("  /  |  \\");
            Console.SetCursorPosition(x, y + 2);
            Console.Write(" |   |   |");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("  \\ | | /");
            Console.SetCursorPosition(x, y + 4);
            Console.Write("   |_|_|");
        }
    }
}
