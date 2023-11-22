using Lab_3_C.Medicines;
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

            } while (k.Key != ConsoleKey.Escape);

            void Attack(Monster attacking, Monster defending)
            {
                AttackWindow();

                MobsStatistic(defending);
            }


            void MobsStatistic(Monster monster)
            {
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

            void CheckPleyground(int x, int y) { 
                
            }
        }

    }
}