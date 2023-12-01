using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawler.Domain.repositories.Monsters;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonCrawler.Domain.repositories.Heroes
{
    public class Enchater : Hero
    {
        //■	Ima najmanji HP i najveći damage
        public int Mana { get; private set; }

        public Enchater(string player, int hp, int damage, int xp, int mana)
            : base(player, hp, damage, xp)
        {
            HealthPoints = 30;
            Damage = 80;

            Mana = mana;
        }
        public override void Attack(Monster monster)
        {
            base.Attack(monster);
        }
    }
}
