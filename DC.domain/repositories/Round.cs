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

        public Round(string heroAction, string monsterAction)
        {
            HeroAction = heroAction;
            MonsterAction = monsterAction;
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
        public void RoundStat()
        {
            if (HeroAction == MonsterAction)
            {
                Console.WriteLine("Both sides chose the same action");
            }
            else if (BeatingMove())
            {
                Console.WriteLine("Hero wins the round!");
            }
            else
            {
                Console.WriteLine("Monster wins the round!");
            }
        }

    }
}
