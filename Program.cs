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
            Hero _hero = new Hero(2, 2);

            SetGame();

            Console.CursorVisible = false;
            ConsoleKeyInfo k;

            Play();

            void Play()
            {

                CheckWictory();
                if (_hero.Hp <= 0)
                {
                    ShowLose();
                    return;
                }
                Console.Clear();

                Border();
                PlayerStatistic();
                ShowPlayground();
                do
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(_hero.X, _hero.Y);
                    Console.Write(_hero.MiniFace);
                    Console.ForegroundColor = ConsoleColor.White;

                    k = Console.ReadKey(true);

                    Console.SetCursorPosition(_hero.X, _hero.Y);
                    Console.Write(" ");
                    if (k.Key == ConsoleKey.UpArrow)
                    {
                        if (_hero.Y - 1 > 0)
                        {
                            if (CheckPlaygroundWalls(_hero.X, _hero.Y - 1) == false)
                            {
                                CheckPlaygroundMonster(_hero.X, _hero.Y - 1);
                                CheckChest(_hero.X, _hero.Y - 1);
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
                                CheckPlaygroundMonster(_hero.X, _hero.Y + 1);
                                CheckChest(_hero.X, _hero.Y + 1);
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
                                CheckPlaygroundMonster(_hero.X - 1, _hero.Y);
                                CheckChest(_hero.X - 1, _hero.Y);
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
                                CheckPlaygroundMonster(_hero.X + 1, _hero.Y);
                                CheckChest(_hero.X + 1, _hero.Y);
                                _hero.SetXY(_hero.X + 1, _hero.Y);
                            }
                        }
                    }
                } while (k.Key != ConsoleKey.Escape);
            }


            void Attack(Monster attacking, Monster defending)
            {
                PlayerStatistic();
                MobsStatistic(defending);

                while (defending.IsDefeat == false)
                {

                    k = Console.ReadKey(true);

                    if (k.Key == ConsoleKey.D1)
                    {
                        attacking.StrikeBaseHit(defending, attacking.GetHit());
                    }
                    else if (k.Key == ConsoleKey.D2)
                    {
                        if (attacking.CooldownAbsoluteHit <= 0)
                        {
                            attacking.StrikeAbsoluteHit(defending, attacking.GetAbsoluteHit());
                            attacking.CooldownAbsoluteHit = attacking.MaxCooldownAbsoluteHit + 1;
                        }
                        else continue;
                    }
                    else if (k.Key == ConsoleKey.D3)
                    {
                        CheckMedicine(new Chocolate());
                        continue;
                    }
                    else if (k.Key == ConsoleKey.D4)
                    {
                        CheckMedicine(new Bandage());
                        continue;
                    }
                    else if (k.Key == ConsoleKey.D5)
                    {
                        CheckMedicine(new PowerEngineer());
                        continue;
                    }
                    else { continue; }

                    if (defending.CooldownAbsoluteHit <= 0)
                    {
                        defending.StrikeAbsoluteHit(attacking, defending.GetAbsoluteHit());
                        defending.CooldownAbsoluteHit = defending.MaxCooldownAbsoluteHit + 1;
                    }
                    else
                    {
                        defending.StrikeBaseHit(attacking, defending.GetHit());
                    }



                    defending.CooldownAbsoluteHit--;
                    if (attacking.CooldownAbsoluteHit > 0)
                        attacking.CooldownAbsoluteHit--;

                    MobsStatistic(defending);
                    PlayerStatistic();

                    if (attacking.IsDefeat == true)
                    {
                        ShowLose();
                    }
                };

                playground.monsters.Remove(defending);

                CheckWictory();
                Play();
            }


            #region Set
            void SetWalls()
            {
                int[,] walls = { {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,0,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1 },//1
                                 {1,0,0,0,1,1,0,0,0,0,0,0,0,1,1,1,1,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,1,1,0,0,1,0,0,0,1,1,0,0,1 },//2
                                 {1,0,0,0,0,0,0,1,1,0,1,1,0,0,0,1,1,0,1,1,1,1,1,0,0,0,0,1,1,1,0,0,1,1,0,1,0,0,0,0,1,0,1,0,0,0,1,1,1,1,0,0,0,0,0,0,1,1 },//3
                                 {1,0,1,1,1,1,1,0,1,0,1,1,0,1,0,0,0,0,1,0,0,0,1,0,1,1,0,1,1,0,0,1,1,1,0,1,1,1,1,1,0,0,1,1,1,0,0,0,0,0,0,1,1,0,0,1,1,1 },//4
                                 {1,0,1,1,0,0,0,0,1,0,1,1,0,1,0,0,0,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,0,0,1,1,1,1 },//5
                                 {1,0,0,0,1,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,0,1,0,0,1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0 },//6
                                 {1,0,1,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,1,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,0,1,1,0,0,1,1,1,1,1,1 },//7
                                 {1,0,1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,1,0,1,0,0,1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1 },//8
                                 {1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },//9
                                 {1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,0,1,0,1,1,1,0,0,1,0,1,1,1,0,0,0,1,0,0,0,1,1,0,0,1,0,0,0,1,1,0,1,1,1,1,1,0,1,1,0,1,1 },//10
                                 {1,0,1,1,1,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,1,1,0,1,0,0,0,0,1,1,1,0,1,1,0,0,1,0,0,1,0,0,1,1,1,1,0,1,0,0,0,1,0,1,1,0,1,1 },//11
                                 {1,0,1,0,0,1,0,1,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1,0,1,1,1,1,0,0,0,1,0,1,0,0,1,0,0,1,1,0,1,1 },//12
                                 {1,0,1,1,1,1,0,1,1,0,0,1,1,1,1,1,1,1,1,0,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,0,1,0,1,1,1,0,0,1,0,1,0,1,1 },//13
                                 {1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,1,0,0,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,1,1,0,1,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0 },//14
                                 {1,0,1,0,1,1,0,1,1,0,1,1,1,1,1,1,0,1,1,0,1,0,0,1,1,0,1,1,1,0,0,0,0,0,1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,0,0,0,1,0,1,1 },//15
                                 {1,0,1,0,0,0,0,1,1,0,1,0,0,0,0,1,0,1,1,0,1,0,0,0,1,0,1,0,0,0,1,1,1,0,0,0,0,1,1,1,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,0,0,1 },//16
                                 {1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,0,1,1,0,0,1,1,1,0,1,1,1,1,0,0,0,0,1,1,0,0,0,0,1,1 },//17
                                 {1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,0,0,1,1,0,1,0,0,1,0,1,1,0,1,1,0,1,1,0,1,0 },//18
                                 {1,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,1,1,1,1,0,1,1,0,0,1,0,1,1,0,1,0 },//19
                                 {1,0,1,0,0,0,0,0,1,1,0,1,1,1,1,0,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,1,0,0,0,0,1,0 },//20
                                 {1,0,1,1,1,1,1,1,1,1,0,1,0,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,1,1,1,1,0,1,0,1,0,0,0,1,1,0,1,0 },//21
                                 {1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,0,1,1,0,1,0 },//22
                                 {1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,1,1,1,1,1,0,1,1,1,0,1,1,1,1,0,1,1,1,1,0,0,1,1,1,0,1,1,0,1,1 },//23
                                 {1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,1,1,0,0,0,0,0,1,1,0,0,0,0,1,1 },//24
                                 {1,0,0,0,0,0,0,1,1,0,1,1,1,1,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0,0,1,1,0,0,0,0,0,1,0,0,1,0,1,0,0,1,1,1,1,0,1,1 },//25
                                 {1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,0,1,1,1,0,0,0,1,1,0,1,1,0,0,0,0,0,0,1,1 },//26
                                 {1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,0,0,0,1,0,0,1,1,1,0,0,0,1,0,0,0,0,0,0,0,1,1 },//27
                                 {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1 } };//28
                              //  1 2 3 4 5 6 7 8 9 10  12  14  16  18  20  22  24  26  28  30  32  34  36  38  40  42  44  46  48  50  52  54  56  58
                              //                      11  13  15  17  19  21  23  25  27  29  31  33  35  37  39  41  43  45  47  49  51  53  55  57
                playground.walls = walls;
            }

            void SetChest()
            {
                playground.objects.Add(new Chest(3, 26));
                playground.objects.Add(new Chest(2, 27));
                playground.objects.Add(new Chest(25, 24));
                playground.objects.Add(new Chest(26, 24));
                playground.objects.Add(new Chest(7, 9));
                playground.objects.Add(new Chest(17, 5));
                playground.objects.Add(new Chest(13, 19));
                playground.objects.Add(new Chest(23, 22));
                playground.objects.Add(new Chest(23, 23));
                playground.objects.Add(new Chest(52, 27));
                playground.objects.Add(new Chest(50, 14));
                playground.objects.Add(new Chest(41, 21));
                playground.objects.Add(new Chest(25, 13));
                playground.objects.Add(new Chest(34, 9));
                playground.objects.Add(new Chest(52, 3));
            }

            void SetMonsters()
            {
                playground.monsters.Add(new Santa_Claus(5, 25));
                playground.monsters.Add(new CouldDog(26, 21));
                playground.monsters.Add(new Dog(28, 21));
                playground.monsters.Add(new Dog(32, 22));
                playground.monsters.Add(new Santa_Claus(53, 27));
            }

            void SetGame()
            {
                SetWalls();
                SetChest();
                SetMonsters();
            }

            void SetPlay()
            {
                playground = new Playground();
                SetGame();

                _hero = new Hero(2, 2);

                Play();
            }
            #endregion

            #region Check
            bool CheckPlaygroundWalls(int x, int y)
            {
                for (int i = 0; i < 28; i++)
                {
                    for (int j = 0; j < 58; j++)
                    {
                        if (playground.walls[i, j] == 1)
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

            void CheckWictory()
            {
                if (playground.CheckMonsters() <= 0) ShowWictory();
            }

            void CheckPlaygroundMonster(int x, int y)
            {
                try
                {
                    foreach (var mon in playground.monsters)
                    {
                        if (mon.X == x && mon.Y == y)
                        {
                            Attack(_hero, mon);
                        }
                    }
                }
                catch { }
            }

            void CheckChest(int x, int y)
            {
                List<Chest> chests = playground.objects.OfType<Chest>().ToList();

                if (chests != null)
                {
                    foreach (var chest in chests)
                    {
                        if (chest.X == x && chest.Y == y)
                        {
                            _hero.Inventory.Add(chest.ReturnItems());
                            playground.DeleteChest(chest);
                            ShowPlayground();
                            PlayerStatistic();
                        }
                    }
                }
            }

            bool CheckMedicine(Medicine medicine)
            {
                if (medicine is Bandage)
                {
                    List<Bandage> bandages = _hero.Inventory.items.OfType<Bandage>().ToList();
                    if (bandages.Count > 0)
                    {
                        _hero.Hp += bandages[0].GetHeal();
                        if (_hero.Hp > _hero.MaxHp) _hero.Hp = _hero.MaxHp;
                        _hero.Inventory.Remove(bandages[0]);
                        PlayerStatistic();
                        return true;
                    };
                }
                else if (medicine is Chocolate)
                {
                    List<Chocolate> chocolates = _hero.Inventory.items.OfType<Chocolate>().ToList();
                    if (chocolates.Count > 0)
                    {
                        _hero.Hp += chocolates[0].Healing;
                        if (_hero.Hp > _hero.MaxHp) _hero.Hp = _hero.MaxHp;
                        _hero.BasicHit[0] += chocolates[0].Gain;
                        _hero.BasicHit[1] += chocolates[0].Gain;
                        _hero.Inventory.Remove(chocolates[0]);
                        PlayerStatistic();
                        return true;
                    };

                }
                else if (medicine is PowerEngineer)
                {
                    List<PowerEngineer> powerEngineers = _hero.Inventory.items.OfType<PowerEngineer>().ToList();
                    if (powerEngineers.Count > 0)
                    {
                        _hero.CooldownAbsoluteHit = 0;
                        _hero.Inventory.Remove(powerEngineers[0]);
                        PlayerStatistic();
                        return true;
                    };
                }
                return false;
            }

            #endregion

            #region Clear
            void ClearMonsterWindow()
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

            #endregion

            #region Show
            void ShowChest()
            {
                foreach (var chest in playground.objects)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(chest.X, chest.Y);
                    Console.Write(chest.Face);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            void ShowMonster()
            {
                foreach (var monster in playground.monsters)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(monster.X, monster.Y);
                    Console.Write(monster.MiniFace);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            void ShowWalls()
            {
                for (int i = 0; i < 28; i++)
                {
                    for (int j = 0; j < 58; j++)
                    {
                        if (playground.walls[i, j] == 1)
                        {
                            Console.SetCursorPosition(j + 1, i + 1);
                            Console.Write("#");
                        }
                    }
                }
            }

            void ShowPlayground()
            {
                ClearMonsterWindow();

                ShowMonster();
                ShowWalls();
                ShowChest();
            }

            void ShowLose()
            {
                Console.Clear();
                Console.WriteLine("Вы програли");
                Console.WriteLine("Чтобы начать заново нажмите 1");

                k = Console.ReadKey(true);

                if (k.Key == ConsoleKey.D1)
                {
                    SetPlay();
                }
            }

                void ShowWictory()
                {
                    Console.Clear();
                    Console.WriteLine("Вы выиграли");

                    Console.WriteLine("Чтобы начать заново нажмите 1");

                    k = Console.ReadKey(true);

                    if (k.Key == ConsoleKey.D1)
                    {
                        SetPlay();
                    }
            }

                void MobsStatistic(Monster monster)
                {
                    ClearMonsterWindow();
                    monster.ShowFace(22, 10);
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
                        Console.SetCursorPosition(0, i);
                        Console.Write($"║");

                        Console.SetCursorPosition(Console.WindowWidth - 1, i);
                        Console.Write("║");

                        Console.SetCursorPosition(Console.WindowWidth / 2, i);
                        Console.Write("║");
                    }
                }

                void PlayerStatistic()
                {
                    //24 max
                    ClearPlayerWindow();
                    _hero.ShowFace(86, 12);
                    Console.SetCursorPosition(85, 19);
                    Console.Write($"Здоровье {_hero.Hp}");
                    Console.SetCursorPosition(82, 20);
                    Console.Write($"Базовая атака {_hero.BasicHit[0]}/{_hero.BasicHit[1]}");
                    Console.SetCursorPosition(80, 21);
                    Console.Write($"Абсолютная атака {_hero.AbsoluteHit[0]}/{_hero.AbsoluteHit[1]}");
                    Console.SetCursorPosition(79, 22);
                    Console.Write($"До абсолютного умения {_hero.CooldownAbsoluteHit}");
                    _hero.Inventory.Show(61, 23);

                    Console.SetCursorPosition(63, 3);
                    Console.Write($"↑←<> - Ходить");
                    Console.SetCursorPosition(63, 4);
                    Console.Write($"! - сундук");
                    Console.SetCursorPosition(63, 5);
                    Console.Write($"@ - Обычный противник");
                    Console.SetCursorPosition(63, 6);
                    Console.Write($"% - Элитный противник");
                    Console.SetCursorPosition(63, 7);
                    Console.Write($"* - Вы");
            }
                #endregion
        }

    }
}