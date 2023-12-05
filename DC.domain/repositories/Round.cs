using DungeonCrawler.Domain.repositories.Heroes;
using DungeonCrawler.Domain.repositories.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories
{
    public class Round
    {
        public string HeroAction { get; }
        public string MonsterAction { get; }
        public int RoundNum { get; set; }

        public Round(string heroAction, string monsterAction, int roundNum)
        {
            HeroAction = heroAction;
            MonsterAction = monsterAction;
            RoundNum = roundNum;
        }

        private bool BeatingMove()
        {
            if (MonsterAction == "CounterAttack" && HeroAction == "DirectAttack")
                return true;
            else if(MonsterAction == "DirectAttack" && HeroAction == "SideAttack")
                return true;
            else if (MonsterAction == "SideAttack" && HeroAction== "CounterAttack")
                return true;
            return false;
        }
        public bool HeroWins(Hero hero, Monster monster)
        {
            Console.WriteLine("----------------------------------");

            if (HeroAction == MonsterAction)
            {
                Console.WriteLine("Both sides chose the same action");
                return false;
            }
            else if (BeatingMove())
            {
                hero.Attack(monster);
                if (monster.HealthPoints <= 0)
                {
                    Console.WriteLine("Hero wins the round!");
                    hero.GainXP(monster);
                    return true;
                }
                return false;
                    
            }
            else
            {
                monster.Attack(hero);
                
                if (hero.HealthPoints <= 0)
                    Console.WriteLine("Monster wins the round!");
                return false;

            }
        }


    }
}
