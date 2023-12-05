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
        public bool DjumbusAttack { get; set; }

        Random random = new Random();

        public Witch( int hp, int damage, int xp, bool isStunned)
            : base(hp, damage, xp, isStunned)
        {
            HealthPoints = random.Next(20, 100);
            Damage = random.Next(20, 80);
            ExperienceWorth = random.Next(50, 80);
            DjumbusAttack = false;
        }

        public override void Attack(Hero hero)
        {
            
            double chance = random.NextDouble();

            if (chance<0.2)
            {
                Djumbus(hero);
                DjumbusAttack=true;
            }
            else
            {
                base.Attack(hero);
            }

        }
        private void Djumbus(Hero hero)
        {
            Console.WriteLine("(MONSTER) !DJUMBUS!");
            HealthPoints = random.Next(1, 101);
            hero.HealthPoints = random.Next(1, 101);
            
        }
        public void DjumbusMonsters(Monster[] monsters)
        {
            if(DjumbusAttack)
            {
                foreach (var monster in monsters)
                {
                    monster.HealthPoints = random.Next(1, 101);
                }
            }
          
        }
        public void TwoNewMonsters()
        {
            
            if (HealthPoints == 0)
            {
                int rndHP=random.Next(2,25);
                int rndXP = random.Next(2, 25);
                int rndD = random.Next(2, 25);

                new Goblin(rndHP, rndD, rndXP,false);
                new Goblin(rndHP, rndD, rndXP,false);

            }
        }
    }
}
