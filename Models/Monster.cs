using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_C.Models
{
    public abstract class Monster
    {
        private int hp;
        private int maxHp;
        private int[] basicHit;
        private int[] absoluteHit;
        private int cooldownAbsoluteHit;
        private string miniFace { get; set; }
        private string name { get;set; }
        private int x;
        private int y;
        private bool isDefeat;
        private int maxCooldownAbsoluteHit;

        public int Hp { get { return hp; } set { hp = value; } }
        public int[] BasicHit { get { return basicHit; } set { basicHit = value; } }
        public int[] AbsoluteHit { get { return absoluteHit; } set { absoluteHit = value; } }
        public int CooldownAbsoluteHit { get { return cooldownAbsoluteHit; } set { cooldownAbsoluteHit = value; } }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public bool IsDefeat { get { return isDefeat; } set { isDefeat = value; } }
        public string MiniFace { get { return miniFace; } set { miniFace = value; } }   
        public string Name { get { return name; } set { name = value; } }
        public int MaxCooldownAbsoluteHit { get { return maxCooldownAbsoluteHit; } set { maxCooldownAbsoluteHit = value; } }

        public int MaxHp { get => maxHp; set => maxHp = value; }

        public virtual void StrikeBaseHit(Monster monster, int damage)
        {
            monster.Hp -= damage;
            if (monster.Hp <= 0)
            {
                monster.IsDefeat = true;
            }
            else monster.IsDefeat = false;
        }

        public virtual void StrikeAbsoluteHit(Monster monster, int damage)
        {
            monster.Hp -= damage;
            if (monster.Hp <= 0)
                monster.IsDefeat = true;
            else monster.IsDefeat = false;
        }
        public void SetXY(int x, int y) 
        { 
            X = x; 
            Y = y; 
        }
        public int GetHit()
        {
            Random random = new Random();
            return random.Next(BasicHit[0] - 1, BasicHit[1]);
        }

        public int GetAbsoluteHit()
        {
            Random random = new Random();
            return random.Next(AbsoluteHit[0] - 1, AbsoluteHit[1]);
        }

        public abstract void ShowFace(int x, int y);
    }
}
