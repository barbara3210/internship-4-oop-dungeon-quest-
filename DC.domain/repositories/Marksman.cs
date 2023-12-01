using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories
{
    public class Marksman:Heroes
    {
        public bool CriticalChance { get; set; }
        public bool StunChance { get; set; }

        public Marksman() 
        {
            HealthPoints = 50;
            Damage = 50;
        }

        public Marksman(int hp, int damage, int xp)
        {
            HealthPoints = hp;
            Damage = damage;
            Experience = xp;

        }
        public override void Attack()
        {
            base.Attack();
        }

    }
}
