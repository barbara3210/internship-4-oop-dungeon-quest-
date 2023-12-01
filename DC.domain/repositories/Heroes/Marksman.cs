using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawler.Domain.repositories.Monsters;

namespace DungeonCrawler.Domain.repositories.Heroes
{
    public class Marksman : Hero
    {
        //■	Ima umjeren HP i damage
        public double CriticalChance { get; set; }
        public double StunChance { get; set; }


        public Marksman(string player, int hp, int damage, int xp)
            : base(player, hp, damage, xp)
        {
            HealthPoints = 60;
            Damage = 45;
        }
        

    }
}
