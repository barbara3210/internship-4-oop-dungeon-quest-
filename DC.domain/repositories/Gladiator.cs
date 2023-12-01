using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonCrawler.Domain.repositories
{
    public class Gladiator:Heroes
    {
        public Gladiator() 
        {
            HealthPoints = 100;
            Damage = 25;
        }

        public Gladiator(int hp,int damage, int xp) 
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
