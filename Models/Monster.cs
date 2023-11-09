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
        private int[] basicHit;
        private int[] absoluteHit;
        private int cooldownAbsoluteHit;

        public int Hp { get { return hp; } set { hp = value; } }
        public int[] BasicHit { get { return basicHit; } set { basicHit = value; } }
        public int[] AbsoluteHit { get { return absoluteHit; } set { absoluteHit = value; } }
        public int CooldownAbsoluteHit { get { return cooldownAbsoluteHit; } set { cooldownAbsoluteHit = value; } }


        public virtual void StrikeBaseHit(Monster monster, int damage)
        {
            monster.Hp -= damage;
        }

        public virtual void StrikeAbsoluteHit(Monster monster, int damage)
        {
            monster.Hp -= damage;
        }

        public abstract void Show();

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

        public void CooldownOpMinus()
        {
            CooldownAbsoluteHit--;
        }

        public abstract void DoAnything();
    }
}
