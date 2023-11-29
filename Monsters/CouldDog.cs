using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_3_C.Monsters
{
    internal class CouldDog: Models.Monster
    {
        public CouldDog(int x, int y)
        {
            Name = "ColdDog";
            MiniFace = "@";
            Random random = new Random();
            Hp = random.Next(50, 60);
            BasicHit = new int[] { 5, 7 };
            AbsoluteHit = new int[] { 30, 35 };
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
