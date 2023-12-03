﻿using System;
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
        
        public int Mana { get; private set; }

        public Enchater(string player, int hp, int damage, int xp)
            : base(player, hp, damage, xp)
        {
            HealthPoints = 30;
            Damage = 80;

            Mana = 100;
        }
        public override void Attack(Monster monster)
        {
            if (Mana > 0)
            {
                base.Attack(monster);
                Mana -= monster.HealthPoints;
            }
            else
            {
                Console.WriteLine("No more mana");
                Mana = 100;
            }
            
        }

        public void UseManaToHeal(int manaToUse)
        {
            if (Mana >= manaToUse)
            {
                HealthPoints += Mana;
                Mana -= manaToUse;
                Console.WriteLine($"Used {manaToUse} mana to restore HP");
            }
            else
            {
                Console.WriteLine("Not enough mana to perform this action.");
            }
        }

        public override void LevelUp()
        {
            
            HealthPoints += 10;
            Damage += 10;
            Mana += 10;
        }
    }
}
