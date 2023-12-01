using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories
{
    public class Heroes
    {
        public Players player { get; set; }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int Experience { get; set; }



        public Heroes() 
        { 
        
        }

        public virtual void Attack() { }

    }
}
