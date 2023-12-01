using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories.Monsters
{
    //Malo HPa i damagea
    public class Goblin : Monster
    {
        Random random = new Random();
        public Goblin( int hp, int damage, int xp)
            : base( hp, damage, xp)
        {
           
        }
    }
}
