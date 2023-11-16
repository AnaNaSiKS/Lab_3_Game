﻿using Lab_3_C.Medicines;
using Lab_3_C.Models;
using Lab_3_C.Monsters;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;

namespace Lab_3_C
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Monster> monsters = new List<Monster>();
            Hero _hero = new Hero(15, 15);
            Santa_Claus _santa_Claus = new Santa_Claus(25, 5);

            _santa_Claus.Show();
            _hero.Show();


            _santa_Claus.Show();

            _hero.Inventory.Add(new Bandage());
            _hero.Inventory.Add(new Chocolate());
            _hero.Inventory.Add(new PowerEngineer());
            _hero.Show();

            Console.CursorVisible = false;
            ConsoleKeyInfo k;

            Console.Clear();

            Console.SetCursorPosition(_santa_Claus.X, _santa_Claus.Y);
            Console.Write(_santa_Claus.MiniFace);

            Border();
            PlayerStatistic();
            
            do
            {
                
                

                Console.SetCursorPosition(_hero.X, _hero.Y);
                Console.Write(_hero.MiniFace);

                k = Console.ReadKey(true);
                
                Console.SetCursorPosition(_hero.X, _hero.Y);
                Console.Write(" ");
                if (k.Key == ConsoleKey.UpArrow)
                {
                    if (_hero.Y - 1 > 0)
                        _hero.SetXY(_hero.X, _hero.Y - 1);
                }
                else if (k.Key == ConsoleKey.DownArrow)
                {
                    if (_hero.Y + 1 < Console.WindowHeight - 1)
                        _hero.SetXY(_hero.X, _hero.Y + 1);
                }
                else if (k.Key == ConsoleKey.LeftArrow)
                {
                    if (_hero.X - 1 > 0)
                        _hero.SetXY(_hero.X - 1, _hero.Y);
                }
                else if (k.Key == ConsoleKey.RightArrow)
                {
                    if (_hero.X + 1 < (Console.WindowWidth / 2) - 1)
                        _hero.SetXY(_hero.X + 1, _hero.Y);
                }

                

                if (_hero.X == _santa_Claus.X && _hero.Y == _santa_Claus.Y)
                {
                    Attack(_hero, _santa_Claus);
                    
                }

            } while (k.Key != ConsoleKey.Escape); // выходим из цикла по нажатию Esc

            void Attack(Monster attacking, Monster defending)
            {
                AttackWindow();

                MobsStatistic(defending);
            }


            void MobsStatistic(Monster monster)
            {
                Console.SetCursorPosition(23, 19);
                Console.Write($"Здоровье {monster.Hp}");
                Console.SetCursorPosition(20, 20);
                Console.Write($"Базовая атака {monster.BasicHit[0]}/{monster.BasicHit[1]}");
                Console.SetCursorPosition(18, 21);
                Console.Write($"Абсолютная атака {monster.AbsoluteHit[0]}/{monster.AbsoluteHit[1]}");
                Console.SetCursorPosition(17, 22);
                Console.Write($"До абсолютного умения {monster.CooldownAbsoluteHit}");
            }


            void Border()
            {
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("═");

                    Console.SetCursorPosition(i, Console.WindowHeight - 1);
                    Console.Write("═");
                }

                for (int i = 1; i < Console.WindowHeight - 1; i++)
                {
                    Console.SetCursorPosition(0, i );
                    Console.Write($"║");

                    Console.SetCursorPosition(Console.WindowWidth - 1 , i);
                    Console.Write("║");

                    Console.SetCursorPosition(Console.WindowWidth / 2, i);
                    Console.Write("║");
                }
            }

            void PlayerStatistic()
            {
                //24 max
                Console.SetCursorPosition(85, 19);
                Console.Write($"Здоровье {_hero.Hp}");
                Console.SetCursorPosition(82, 20);
                Console.Write($"Базовая атака {_hero.BasicHit[0]}/{_hero.BasicHit[1]}");
                Console.SetCursorPosition(80, 21);
                Console.Write($"Абсолютная атака {_hero.AbsoluteHit[0]}/{_hero.AbsoluteHit[1]}");
                Console.SetCursorPosition(79,22);
                Console.Write($"До абсолютного умения {_hero.CooldownAbsoluteHit}");
                _hero.Inventory.Show(61,23);
            }

            void AttackWindow() 
            { 
                for (int i = 1; i < Console.WindowWidth / 2; i++)
                {
                    for (int j = 1; j < Console.WindowHeight - 1; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                    }
                }
            }
        }

    }
}