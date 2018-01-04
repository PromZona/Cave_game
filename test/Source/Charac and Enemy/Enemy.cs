using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Enemy
    {
        Random rnd = new Random(); 
        public double Health { get; set; }
        public int Maxhealth { get; set; }
        public double Damage { get; set; }
        List<DamageType> Resist = new List<DamageType>();
        DamageType damagetype;
             
        public double ReturnDamage()
        { 
            return Damage;
        }
        public Enemy(int difficult)
        {
            Maxhealth = Convert.ToInt32(100 * (difficult * 0.25));
            Health = Maxhealth;
            Damage = 10 * (difficult * 0.25);
            damagetype = (DamageType)rnd.Next(0, 11);
            //Добавляем резисты врагу в зависмости от сложности
            for(int i = 0; i < difficult; i++) Resist.Add((DamageType)rnd.Next(0,11));
        }

        public void AcceptDamage(double Damage, DamageType WeaponDamage)
        {
            foreach(DamageType t in Resist)
            {
                if(t == WeaponDamage)
                {
                    Health = Health - (Damage / 2);
                    break;
                }
            }

            Health = Health - Damage;
        }
        
        public double MakeDamage()
        {
            return Damage;
        }
    }
}
