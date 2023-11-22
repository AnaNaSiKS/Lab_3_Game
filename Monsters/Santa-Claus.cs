﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3_C.Models;

namespace Lab_3_C.Monsters
{
    internal class Santa_Claus : Monster
    {
        public Santa_Claus(int x, int y)
        {
            Name = "Santa Claus";
            MiniFace = "%";
            Random random = new Random();
            Hp = random.Next(120, 150);
            BasicHit = new int[] { 5, 10 };
            AbsoluteHit = new int[] { 40, 60 };
            CooldownAbsoluteHit = 5;
            X = x;
            Y = y;
        }

        public override void ShowFace(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("|||||||||||||||||");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|||||||||||||||||");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("|||||||||||||||||");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("|||||||||||||||||");
            Console.SetCursorPosition(x, y + 4);
            Console.Write("|||||||||||||||||");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("|||||||||||||||||");
            Console.SetCursorPosition(x, y + 6);
            Console.Write("|||||||||||||||||");
        }
    }
}
