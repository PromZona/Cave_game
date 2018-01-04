using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Character
    {
        public double Health { get; set; }
        public int Maxhealth { get; set; }
        public double Damage { get; set; }
        public int Gold { get; set; }
        public Place place { get; set; }
        public List<DamageType> Resist = new List<DamageType>();
        public DamageType damagetype;
        public bool[] skills = new bool[7];

        public Character(int maxhealth, double damage, int gold, bool[] skils)
        {
            Maxhealth = maxhealth;
            Health = Maxhealth;
            Damage = damage;
            Gold = gold;
            skills = skils;
            place = Place.Town;
            skills[0] = true;
        }

        public void GoInTown()
        {
            if (Place.Cave == place)
            {
                place = Place.Town;
                Console.WriteLine("Ты пошел в город... Поздравляю!!! Ты в городе");
            }
            else
            {
                Console.WriteLine("Ты уже в городе");
            }
        }

        public void GoInCave()
        {
            if (Place.Town == place)
            {
                place = Place.Cave;
                Console.WriteLine("Ты пошел в пещеру... Поздравляю!!! Ты в пещере");
                Console.WriteLine("Введи <Бой> - для битвы или <Город> - чтобы отправиться в город");
            }
            else
            {
                Console.WriteLine("Ты уже в пещере");
            }
        }

        public static void ReturnHeroStats(Character Hero)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Золото: " + Hero.Gold);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Твоя Сила: " + Hero.Damage);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Твоя здоровье сейчас: " + Hero.Health + " Твое Максимальное здоровье: " + Hero.Maxhealth);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Твои предметы: Название / Урон / Качество");
            for (int i = 0; i < Hero.equipment.Length; i++)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write(Hero.equipment[i].EquipTypeE + " " + Hero.equipment[i].Name + " Урон: " + Hero.equipment[i].BonusDamage + " Качество: ");
                    switch (Hero.equipment[i].EquipQualityE)
                    {
                        case EquipQuality.Common:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Обычное");
                            Console.ResetColor();
                            break;
                        case EquipQuality.Legendary:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Легендарное");
                            Console.ResetColor();
                            break;
                        case EquipQuality.Mystic:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Мистическое");
                            Console.ResetColor();
                            break;
                        case EquipQuality.Rare:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Редкое");
                            Console.ResetColor();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("У вас еще нет предмета");
                }
            }
        }

        public void WearEquip(Equipment[] equip)
        {
            Resist = new List<DamageType>();
            Damage = 0;
            for (int i = 0; i < equip.Length; i++)
            {
                Damage += equip[i].BonusDamage;
                if(equip[i].Resist != DamageType.NULL)
                {
                    Resist.Add(equip[i].Resist);
                }
                
                if (equip[i].damagetype != DamageType.NULL)
                {
                    damagetype = equip[i].damagetype;
                }
            }
        }

        public Equipment[] equipment = new Equipment[3];

        public Treasure[] HeroTreasures = new Treasure[9];

        public void AcceptDamage (double Damage, DamageType WeaponDamage)
        {
            foreach (DamageType t in Resist)
            {
                if (t == WeaponDamage)
                {
                    Health = Health - (Damage / 2);
                    break;
                }
            }

            Health = Health - Damage;
        }

        public double MakeDamage()
        {
            Console.WriteLine("Выберите Действие:");
            for (int i = 0; i < skills.Length; i++)
            {
                if (skills[i])
                {
                    switch(i)
                    {
                        case 0:
                            Console.WriteLine("Обычная атака");
                            break;
                    }

                }
            }
            string Command = Console.ReadLine();

            switch (Command)
            {
                case "обычная атака":
                    return Damage;
            }

            return 2;
        }
    }
}
