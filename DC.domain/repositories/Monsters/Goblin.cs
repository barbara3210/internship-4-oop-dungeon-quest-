using DungeonCrawler.Domain.repositories.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories.Monsters
{
   
    public class Goblin : Monster
    {
        Random random = new Random();
        public Goblin( int hp, int damage, int xp)
            : base( hp, damage, xp)
        {
            HealthPoints = random.Next(5,25);
            Damage = random.Next(5, 25);
            ExperienceWorth= random.Next(10, 25);
        }

        public override void Attack(Hero hero)
        {
            base.Attack(hero);
        }
        public override void AttackHit(int damage)
        {
            base.AttackHit(damage);
        }
    }
}
