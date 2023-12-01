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

        public Brute(int hp, int damage, int xp)
            : base(hp, damage, xp)
        {
        }
    }
}


