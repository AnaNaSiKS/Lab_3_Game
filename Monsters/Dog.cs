using Lab_3_C.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_3_C.Monsters
{
    internal class Dog: Monster
    {
        public Dog(int x, int y)
        {
            Name = "HotDog";
            MiniFace = "@";
            Random random = new Random();
            Hp = random.Next(60, 70);
            BasicHit = new int[] { 3, 5 };
            AbsoluteHit = new int[] { 20, 30 };
            MaxCooldownAbsoluteHit = 2;
            CooldownAbsoluteHit = MaxCooldownAbsoluteHit;
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
