﻿using DungeonCrawler.Domain.repositories.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Domain.repositories.Monsters
{
    public abstract class Monster
    {
        
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int ExperienceWorth { get; set; }
        public bool IsStunned { get; set; }

        protected Monster( int hp, int damage, int xp, bool isStunned)
        {
            HealthPoints = hp;
            Damage = damage;
            ExperienceWorth = xp;
            IsStunned = isStunned;
        }

        public virtual void HeroAttack(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints < 0)
            {
                HealthPoints = 0;
            }
        }
        public virtual void Attack(Hero hero)
        {
            hero.HealthPoints -= Damage;
            if (hero.HealthPoints <= 0)
            {
                hero.HealthPoints = 0;
            }
            Console.WriteLine("(MONSTER) Preformed attack!");
        }
        public virtual void SkipNextRound()
        {
            IsStunned = true;
        }
        public bool IsDefeated()
        {
            if (HealthPoints == 0)
                return true;
            else
                return false;
        }

    }
}
