using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame
{

    class Pokemon
    {

        public string Name { get; set; }
        public string ChosenChar { get; set; }
        public float Level { get; set; }
        public float HpMulti { get; set; }
        public float DamageMulti { get; set; }
        public float BaseDamage { get; set; }
        public float BaseHp { get; set; }
        public float Hp { get; set; }
        public float Damage { get; set; }
        public bool Active { get; set; }
        public bool Inventory { get; set; }
        public bool EnemyActive { get; set; }
        public string Type { get; set; }


        public Pokemon(string name, string chosenChar, float level, float hpMulti, float damageMulti, float baseHp, float baseDamage, bool active, bool inventory, bool enemyActive, string type)
        {
            Name = name;
            ChosenChar = chosenChar;
            Level = level;
            HpMulti = hpMulti;
            DamageMulti = damageMulti;
            BaseDamage = baseDamage;
            BaseHp = baseHp;
            Hp = baseHp;
            Damage = baseDamage;
            Active = active;
            Inventory = inventory;
            EnemyActive = enemyActive;
            Type = type;

        }



    }
}
