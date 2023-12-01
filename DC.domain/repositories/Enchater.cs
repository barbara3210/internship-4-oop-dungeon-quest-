using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonCrawler.Domain.repositories
{
    public class Enchater : Heroes
    {
        public Enchater() 
        {
            HealthPoints = 25;
            Damage = 100;
        }
        public Enchater(int hp, int damage, int xp)
        {
            HealthPoints = hp;
            Damage = damage;
            Experience = xp;
        }
        public override void Attack()
        {
            base.Attack();
        }
    }
}
