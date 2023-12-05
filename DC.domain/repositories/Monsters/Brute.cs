using DungeonCrawler.Domain.repositories.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories.Monsters
{
    //Velik HPa i solidan damage
    public class Brute : Monster
    {
        Random random = new Random();

        public Brute( int hp, int damage, int xp,bool isStunned)
            : base( hp, damage, xp, isStunned)
        {
            HealthPoints = random.Next(50, 80);
            Damage = random.Next(30, 80);
            ExperienceWorth = random.Next(30, 60);
        }

        public override void Attack(Hero hero)
        {
            Random random = new Random();
            double chance = random.NextDouble();
            
            if (chance > 0.5)
            {
                Console.WriteLine("(MONSTER) STRONG ATTACK");
                int damageStrongAttack = (int)(hero.HealthPoints * 0.2);
                hero.HealthPoints-=damageStrongAttack;

                if (hero.HealthPoints < 0)
                    hero.HealthPoints = 0;

            }
            else { base.Attack(hero); }
            

        }


        
    }
}


