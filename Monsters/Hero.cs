using System;
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

        private string miniFace;

        public string MiniFace { get { return miniFace; } set { miniFace = value; } }
        public Hero(int x, int y)
        {
            Random random = new Random();
            Hp = random.Next(100, 120);

            if (Hp > 110)
                BasicHit = new int[] { 4, 7 };
            else
                BasicHit = new int[] { 7, 10 };

            AbsoluteHit = new int[] { 45, 55 };

            CooldownAbsoluteHit = 3;

            MiniFace = "*";

            X = x;
            Y = y;

            Inventory = new Inventory();
        }

        public override void Show()
        {
            Console.WriteLine("Герой");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Здоровье {Hp}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Урон {BasicHit[0]}|{BasicHit[1]}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Урон абсолютного умения {AbsoluteHit[0]}|{AbsoluteHit[1]}");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"До абсолютного умения {CooldownAbsoluteHit} ходов");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void DoAnything()
        {
            //    Console.WriteLine("Совершите действие: \n1. Атаковать обычной атакой \n2. Атаковать абсолютным умением\n3. Инвентарь");
            //    var action = Convert.ToInt32(Console.ReadLine());

            //    switch (action)
            //    {
            //        case 1: 
            //            Console.WriteLine(); 
            //            break;
            //    }
        }
    }
}
