using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawler.Domain.repositories.Monsters;

namespace DungeonCrawler.Domain.repositories.Heroes
{
    public abstract class Hero
    {
        public string Player { get; set; }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int Experience { get; set; }



        public Hero(string player, int hp, int d, int xp)
        {
            Player = player;
            HealthPoints = hp;
            Damage = d;
            Experience = xp;

        }

        public virtual void Attack(Monster monster) 
        {
            monster.HealthPoints -= Damage;
            if(monster.HealthPoints < 0)
            {
                monster.HealthPoints = 0;
            }

        }

        public virtual void GainXP(Monster monster)
        {
            int gain=monster.ExperienceWorth;
            Experience += gain;
            if (Experience >= 100)
            {
                LevelUp();
                Experience %= 100; 
            }

        }
        public bool IsDefeated()
        {
            if (HealthPoints == 0)
                return true;
            else
                return false;
        }
        public virtual void LevelUp()
        {
            
            HealthPoints += 10;
            Damage += 10;
            Console.WriteLine("(HERO) LEVEL UP");
        }

    }
}
