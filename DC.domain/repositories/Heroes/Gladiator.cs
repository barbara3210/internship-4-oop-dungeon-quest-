using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawler.Domain.repositories.Monsters;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonCrawler.Domain.repositories.Heroes
{
    public class Gladiator : Hero
    {

        //■	Ima najveći HP i najmanji Damage
        public Gladiator(string player, int hp, int damage, int xp)
            : base(player, hp, damage, xp)
        {
            
        }
        public override void Attack(Monster monster)
        {

            if (RagePossible(HealthPoints))
            {
                int doubleDamage = Damage * 2;
                monster.HeroAttack(doubleDamage);

                int rageHealth = (int)(0.15 * HealthPoints);
                HealthPoints -= rageHealth;

            }
            else { base.Attack(monster); }


        }

        public bool RagePossible(int hp)
        {
            if (hp <= 10)
            {
                Console.WriteLine("Health is too low for a rage attack");
                return false;
            }
            string choice;
            do
            {
                Console.WriteLine("Do you want RAGE attack? Y/N");
                var c = Console.ReadLine();
                if (c != null)
                {
                    choice = c.ToLower();
                    if (choice == "y")
                    {
                        return true;
                    }
                    else if (choice == "n")
                    {
                        return false;
                    }
                }
            }
            while (true);

        }


        public override void LevelUp()
        {

            base.LevelUp();
        }


    }
}
