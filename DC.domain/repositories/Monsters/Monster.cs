using DungeonCrawler.Domain.repositories.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories.Monsters
{
    public abstract class Monster
    {
        
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int ExperienceWorth { get; set; }

        protected Monster( int hp, int damage, int xp)
        {
            HealthPoints = hp;
            Damage = damage;
            ExperienceWorth = xp;
        }

        public virtual void HeroAttack(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints < 0)
            {
                HealthPoints = 0;
            }
        }
        public virtual void Attack(Hero hero)
        {
            hero.HealthPoints -= Damage;
            if (hero.HealthPoints <= 0)
            {
                hero.HealthPoints = 0;
            }
        }

    }
}
