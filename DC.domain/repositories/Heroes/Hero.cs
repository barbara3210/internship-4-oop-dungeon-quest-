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

        public virtual void Attack(Monster monster) { }

        public virtual void LevelUp() { }

    }
}
