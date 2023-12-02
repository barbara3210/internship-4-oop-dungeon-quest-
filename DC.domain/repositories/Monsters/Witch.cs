using DungeonCrawler.Domain.repositories.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories.Monsters
{
    public class Witch : Monster
    {
        Random random = new Random();

        public Witch( int hp, int damage, int xp)
            : base(hp, damage, xp)
        {
            HealthPoints = random.Next(20, 100);
            Damage = random.Next(20, 80);
            ExperienceWorth = random.Next(50, 80);
        }

        public override void Attack(Hero hero)
        {

        }

        public void TwoNewMonsters()
        {
            Random random = new Random();
            if (HealthPoints == 0)
            {
                int rndHP=random.Next(2,25);
                int rndXP = random.Next(2, 25);
                int rndD = random.Next(2, 25);

                new Goblin(rndHP, rndD, rndXP);
                new Goblin(rndHP, rndD, rndXP);

            }
        }
    }
}
