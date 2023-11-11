using System;
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
        private static string name;
        private string face;
        private string miniFace;

        public string Name { get { return name; } set { name = value; } }
        public string Face { get { return face; } set { face = value; } }
        public string MiniFace { get { return miniFace; } set { miniFace = value; } }

        public Santa_Claus(int x, int y)
        {
            Name = "Santa Claus";
            Face = "⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠛⠉⠁⠄⠄⠄⠄⠄⠄⠉⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⣿⡿⠋⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠹⣿⣿⣿⣿⣿⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⣏⣀⣤⣤⣠⠤⠶⠶⠒⠒⠒⠒⠲⠶⢤⣄⣀⡀⢹⣿⣿⣿⣿⣿⣿" +
                "\r\n⣿⠋⠁⠄⠈⠙⢿⣿⠃⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⠙⠛⢻⣿⣿⣿⣿⣿" +
                "\r\n⡇⠄⠄⠄⠄⠄⢸⣿⠄⠄⢀⣀⣀⣀⣀⣀⣀⣀⠄⠄⠄⠄⠄⠄⠈⣿⣿⣿⣿⣿" +
                "\r\n⣿⣄⠄⠄⠄⣀⡾⠛⠚⠉⣡⡶⠋⠁⠄⠈⣿⣿⠟⠐⠒⠐⢶⡒⠒⠻⣿⣿⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⡏⠄⠄⢀⣾⣿⣇⡴⠛⡛⣷⣿⣿⡦⠒⠲⣦⡀⣿⡄⠄⠈⢻⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⡀⠄⠄⡞⠉⠄⠈⢹⣿⠛⠉⠉⠉⠙⢿⡶⠛⠉⠻⣿⠄⠄⠄⣿⣿" +
                "\r\n⣿⣿⣿⡿⣿⢷⣄⣀⣇⣠⠴⠒⢻⡇⠄⠄⠄⠄⠄⢀⡶⣄⡀⠄⢸⠄⠄⣰⣿⣿" +
                "\r\n⣿⣿⣿⠃⢻⡆⠄⠄⠄⠄⠄⠄⠄⠙⠦⢤⣤⡤⠴⠛⠄⠄⠉⠙⠛⠛⢋⡟⣿⣿" +
                "\r\n⣿⣿⣿⠄⠄⠙⢦⡀⠄⠄⠄⠄⠄⠄⢀⡼⠙⢦⡀⠄⠄⠄⠄⠄⢀⣠⠞⠄⢹⣿" +
                "\r\n⣿⣿⣿⠄⠄⠄⠄⠙⠓⠲⠤⠤⠶⠚⠛⠢⠤⠖⠋⠓⠒⠶⠖⠒⠋⠄⠄⠄⢸⣿" +
                "\r\n⣿⣿⣿⡆⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣾⣿" +
                "\r\n⣿⣿⣿⣿⡄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣴⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⣦⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣠⣾⣿⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⣿⣿⣦⣄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣀⣴⣾⣿⣿⣿⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣤⡀⠄⠄⠄⠄⠄⠄⣀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣤⡀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿" +
                "\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿";
            miniFace = "%";
            Random random = new Random();
            Hp = random.Next(120, 150);
            BasicHit = new int[] { 5, 10 };
            AbsoluteHit = new int[] { 40, 60 };
            CooldownAbsoluteHit = 5;
            X = x;
            Y = y;
        }

        public override void Show()
        {
            //Console.WriteLine(Face);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Здоровье " + Hp);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Базовая атака " + BasicHit[0] + "-" + BasicHit[1] + "\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Абсолютное умение " + AbsoluteHit[0] + "-" + AbsoluteHit[1] + "\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("До абсолютного умения " + CooldownAbsoluteHit + " ходов");

            Console.ForegroundColor = ConsoleColor.White;
        }


        public override void DoAnything()
        {

        }
    }
}
