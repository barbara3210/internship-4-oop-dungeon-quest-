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
            CriticalChance = 0.2;
            StunChance = 0.2;
        }

        public override void Attack(Monster monster)
        {
            Random r= new Random();

            if(r.NextDouble()< CriticalChance)
            {
                int damageCritical = Damage * 2;
                monster.HeroAttack(damageCritical);
            }
            else
            {
                base.Attack(monster);
            }
            if (r.NextDouble() < StunChance)
            {
                //monster gubi iducu rundu
                Console.WriteLine($"(HERO) {monster.GetType().Name} is stunned!");
                monster.SkipNextRound();
            }
                        

        }
        public override void LevelUp()
        {
            base.LevelUp();
            CriticalChance += 0.05;
            StunChance += 0.05;
        }

    }
}
