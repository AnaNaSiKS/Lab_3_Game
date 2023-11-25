﻿using Lab_3_C.Medicines;
using Lab_3_C.Models;
using Lab_3_C.Monsters;
using Lab_3_C.Objects;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;

namespace Lab_3_C
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Playground playground = new Playground();
            Hero _hero = new Hero(15, 15);
            Santa_Claus _santa_Claus = new Santa_Claus(25, 5);

            playground.monsters.Add(_santa_Claus);

            _hero.Inventory.Add(new Bandage());
            _hero.Inventory.Add(new Chocolate());
            _hero.Inventory.Add(new PowerEngineer());

            Console.CursorVisible = false;
            ConsoleKeyInfo k;

            Console.Clear();

            Console.SetCursorPosition(_santa_Claus.X, _santa_Claus.Y);
            Console.Write(_santa_Claus.MiniFace);

            Border();
            PlayerStatistic();
            SetWalls();
            ShowWalls();
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
                    {
                        if (CheckPlaygroundWalls(_hero.X, _hero.Y - 1) == false)
                        {
                            _hero.SetXY(_hero.X, _hero.Y - 1);
                        }
                    }
                }
                else if (k.Key == ConsoleKey.DownArrow)
                {
                    if (_hero.Y + 1 < Console.WindowHeight - 1)
                    {
                        if (CheckPlaygroundWalls(_hero.X, _hero.Y + 1) == false)
                        {
                            _hero.SetXY(_hero.X, _hero.Y + 1);
                        }
                    }
                }
                else if (k.Key == ConsoleKey.LeftArrow)
                {
                    if (_hero.X - 1 > 0)
                    {
                        if (CheckPlaygroundWalls(_hero.X - 1, _hero.Y) == false)
                        {
                            _hero.SetXY(_hero.X - 1, _hero.Y);
                        }
                    }
                }
                else if (k.Key == ConsoleKey.RightArrow)
                {
                    if (_hero.X + 1 < (Console.WindowWidth / 2) - 1)
                    {
                        if (CheckPlaygroundWalls(_hero.X + 1, _hero.Y) == false)
                        {
                            _hero.SetXY(_hero.X + 1, _hero.Y);
                        }
                    }
                }

                

                if (_hero.X == _santa_Claus.X && _hero.Y == _santa_Claus.Y)
                {
                    Attack(_hero, _santa_Claus);
                    
                }

            } while (k.Key != ConsoleKey.Escape);

            void Attack(Monster attacking, Monster defending)
            {
                ClearMonsterWindow();
                MobsStatistic(defending);
                do
                {
                    k = Console.ReadKey(true);

                    if (k.Key == ConsoleKey.D1)
                    {
                        attacking.StrikeBaseHit(defending, attacking.GetHit());
                        MobsStatistic(defending);
                    }
                    else if (k.Key == ConsoleKey.D2)
                    {
                        attacking.StrikeAbsoluteHit(defending, attacking.GetAbsoluteHit());
                        MobsStatistic(defending);
                    }
                    else if (k.Key == ConsoleKey.D3)
                    {
                        CheckMedicine(new Chocolate());
                    }
                    else if (k.Key == ConsoleKey.D4)
                    {
                        CheckMedicine(new Bandage());
                    }
                    else if (k.Key == ConsoleKey.D5)
                    {
                        CheckMedicine(new PowerEngineer());
                    }

                    Console.WriteLine(defending.IsDefeat);
                }
                while (defending.IsDefeat == false);
                Console.WriteLine("Выход из цикла");
            }

            void MobsStatistic(Monster monster)
            {
                ClearMonsterWindow();
                monster.ShowFace(20,8);
                Console.SetCursorPosition(23, 17);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(monster.Name);
                Console.SetCursorPosition(23, 19);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Здоровье {monster.Hp}");
                Console.SetCursorPosition(20, 20);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Базовая атака {monster.BasicHit[0]}/{monster.BasicHit[1]}");
                Console.SetCursorPosition(18, 21);
                Console.Write($"Абсолютная атака {monster.AbsoluteHit[0]}/{monster.AbsoluteHit[1]}");
                Console.SetCursorPosition(17, 22);
                Console.Write($"До абсолютного умения {monster.CooldownAbsoluteHit}");
                Console.SetCursorPosition(14, 24);
                Console.Write("1 - Обычная атака");
                Console.SetCursorPosition(14, 25);
                Console.Write("2 - Абсолютная атака");
                Console.SetCursorPosition(15, 26);
                Console.Write("3 - Использовать шоколад");
                Console.SetCursorPosition(15, 27);
                Console.Write("4 - Использовать бинт");
                Console.SetCursorPosition(15, 28);
                Console.Write("5 - Использовать энергетик");
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
                ClearPlayerWindow();
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

            void ClearMonsterWindow() 
            { 
                for (int i = 1; i < Console.WindowWidth / 2 ; i++)
                {
                    for (int j = 1; j < Console.WindowHeight - 1; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                    }
                }
            }

            void ClearPlayerWindow() 
            { 
            for (int i = Console.WindowWidth / 2 + 1; i < Console.WindowWidth - 1; i++)
                {
                    for (int j = 1; j < Console.WindowHeight - 2; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                    }
                }
            }


            void SetWalls() {
                int[,] walls = { {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,0,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,0,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 },
                                 {1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1,0,1,0 } };

                playground.walls = walls;
            }

            void ShowWalls() { 
                for (int i = 0; i < 28; i++)
                {
                    for (int j = 0; j < 58; j++)
                    {
                        if (playground.walls[i , j] == 1)
                        {
                            Console.SetCursorPosition(j + 1, i + 1);
                            Console.Write("#");
                        }
                    }
                }
            }

            bool CheckPlaygroundWalls(int x, int y) { 
                for (int i = 0; i < 28; i++)
                {
                    for (int j = 0; j < 58; j++)
                    {
                        if(playground.walls[i, j] == 1)
                        {
                            if (x == j + 1 && y == i + 1)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            void CheckPlaygroundMonster(int x, int y)
            {
                foreach (var mon in playground.monsters)
                {
                    if ( mon.X == x && mon.Y == y )
                    {
                        Attack(_hero, mon);
                    }
                }
            }

            void CheckMedicine(Medicine medicine) {
                if (medicine is Bandage)
                {
                    List<Bandage> bandages = _hero.Inventory.items.OfType<Bandage>().ToList();
                    if (bandages.Count > 0) 
                    {
                        Bandage bandage = new Bandage();
                        _hero.Hp += bandage.GetHeal();
                        _hero.Inventory.Remove(bandage);
                        PlayerStatistic();
                    };
                }
                else if (medicine is Chocolate)
                {
                    List<Chocolate> chocolates = _hero.Inventory.items.OfType<Chocolate>().ToList();
                    if (chocolates.Count > 0)
                    {
                        Chocolate chocolate = new Chocolate();
                        _hero.Hp += chocolate.Healing;
                        _hero.BasicHit[0] += chocolate.Gain;
                        _hero.BasicHit[1] += chocolate.Gain;
                        _hero.Inventory.Remove(chocolate);
                        PlayerStatistic();
                    };

                }
                else if (medicine is PowerEngineer)
                {
                    List<PowerEngineer> powerEngineers = _hero.Inventory.items.OfType<PowerEngineer>().ToList();
                    if (powerEngineers.Count > 0)
                    {
                        PowerEngineer powerEngineer = new PowerEngineer();
                        _hero.CooldownAbsoluteHit = 0;
                        _hero.Inventory.Remove(powerEngineer);
                        PlayerStatistic();
                    };
                }
            }
        }

    }
}