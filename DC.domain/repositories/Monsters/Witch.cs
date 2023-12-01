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
            
        }
    }
}
