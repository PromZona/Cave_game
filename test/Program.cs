﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Character Hero = new Character()
            {
                MaxHealth = 100,
                Health = 100,   
                Place = Place.Town
            };
            Controller Control = new Controller(Hero);

            //Основной игровой цикл
            Game:
            do
            {           
                Console.WriteLine("Введите команду. Список команд - <Помощь>");
                Controller.ReadCommand();
            } while (Controller.WantExit == false);

            //Ниже код для выхода  из игры
            Exit:
            Console.WriteLine("Вы уверены что хотите выйти? д - да, н - нет");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "да":
                    break;
                case "Да":
                    break;
                case "нет":
                    Controller.WantExit = false;
                    goto Game;
                case "Нет":
                    Controller.WantExit = false;
                    goto Game;
                default:
                    goto Exit;                 
            }
            Console.WriteLine("Нажмите любую кнопку...");
            Console.ReadKey();
        }
    }

    public class Controller
    {
        private static bool wantexit = false;
        private static string command;
        private static Character ControlHero;
        static Random rnd = new Random();

        public static bool WantExit
        {
            get
            {
                return wantexit;
            }
            set
            {
                wantexit = value;
            }
        }

        public Controller(Character Hero)
        {
            ControlHero = Hero;
        }
        public static void ReadCommand()
        {
            command = Console.ReadLine();

            switch (command)
            {
                case "Выход":
                    Exit();
                    break;
                case "Урон":
                    ControlHero.Health -= 10;
                    break;
                case "Генерация":
                    Generate();
                    break;
                case "Параметры":
                    Character.ReturnHeroStats(ControlHero);
                    break;
                case "Лечиться":
                    if (ControlHero.Health < ControlHero.MaxHealth)
                    {
                        City.RegenHp(ControlHero);
                    }
                    else
                        Console.WriteLine("У вас максимально здоровья");
                    break;
                default:
                    Console.WriteLine("Команду не определить.");
                    break;
            }
        }
        public static void Exit()
        {
            wantexit = true;
        }
        public static void Generate()
        {
            EquipType[] Types = new EquipType[4] { EquipType.Helmet, EquipType.Armor, EquipType.Boots, EquipType.Weapon };

            for (int i = 0; i < ControlHero.equipment.Length; i++)
            {
                ControlHero.equipment[i] = new Equipment(rnd.Next(1, 20), Convert.ToString((EquipName)rnd.Next(11)), Types[i], (EquipQuality)rnd.Next(3));
            }
            ControlHero.WearEquip(ControlHero.equipment);
            Console.WriteLine("Экипировка сгенерирована");
        }

    }

    public class Character
    {
        static private double health;
        static private int maxhealth;
        static private double damage;
        static private int gold;
        static private Place place;

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public int MaxHealth
        {
            get
            {
                return maxhealth;
            }
            set
            {
                maxhealth = value;
            }
        }
        public double Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }
        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                gold = value;
            }
        }
        public Place Place
        {
            get
            {
                return place;
            }
            set
            {
                place = value;
            }
        }

        private void GoInTown()
        {
            place = Place.Town;
        }

        private void GoInCave()
        {
            place = Place.Cave;
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
            Console.WriteLine("Твоя здоровье сейчас: " + Hero.Health + " Твое Максимальное здоровье: " + Hero.MaxHealth);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Твои предметы: Название / Урон / Качество");
            for (int i = 0; i < Hero.equipment.Length; i++)
            {
                Console.WriteLine();
                Console.Write(Hero.equipment[i].GetEquipType +" "+ Hero.equipment[i].Name + " Урон: " + Hero.equipment[i].BonusDamage + " Качество: ");
                switch (Hero.equipment[i].GetEquipQuality)
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
        }

        public void WearEquip(Equipment[] equip)
        {
            damage = 0;
            for (int i = 0; i < equip.Length; i++)
            {
                damage += equip[i].BonusDamage;
            }
        }

        public Equipment[] equipment = new Equipment[4];

        public Treasure[] HeroTreasures = new Treasure[9];
    }

    public class City
    {
        public static void RegenHp(Character Hero)
        {
            if (Hero.Gold >= 10 && Hero.Place == Place.Town && Hero.Health != Hero.MaxHealth)
            {
                Hero.Gold = Hero.Gold - 10;
                Hero.Health = Hero.MaxHealth;
                Console.WriteLine("С вас сняли: 10 золотых  " + "У вас сейчас золота: " + Hero.Gold);
                Console.WriteLine("Ваше здоровье восстановлено. Нынешнее здоровье: " + Hero.Health);
            }
            if (Hero.Gold < 10)
            {
                Console.WriteLine("У вас недостаточно золота");
            }
            if (Hero.Place != Place.Town)
            {
                if (Hero.Place == Place.Cave)
                {
                    Console.WriteLine("Вы в пещере, и не можете сейчас лечиться");
                }
            }
            if (Hero.Place == Place.Dead)
            {
                Console.WriteLine("Вы мертвы! Введите <Воскреснуть>");
            }
            if (Hero.Health == Hero.MaxHealth)
            {
                Console.WriteLine("твое здоровье максимально: " + Hero.Health);
            }
        }

        public static void ProdatGovno(Character Hero)
        {
            for (int x = 0; x < Hero.HeroTreasures.Length; x++)
            {
                if (Hero.HeroTreasures[x] != Treasure.Empty)
                {
                    Hero.HeroTreasures[x] = Treasure.Empty;
                    Hero.Gold += 20;
                }
            }
        }
    }

    public class Equipment
    {
        private string name;
        private double bonusdamage;
        private EquipType EquipTypeE;
        private EquipQuality EquipQualityE;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public double BonusDamage
        {
            get
            {
                return bonusdamage;
            }
            set
            {
                bonusdamage = value;
            }
        }
        public EquipQuality GetEquipQuality
        {
            get
            {
                return EquipQualityE;
            }
        }
        public EquipQuality SetEquipQuality
        {
            set
            {
                EquipQualityE = value;
            }
        }
        public EquipType GetEquipType
        {
            get
            {
                return EquipTypeE;
            }
        }

        public Equipment(double BonusDamage, string Name, EquipType Type, EquipQuality Quality)
        {
            name = Name;
            bonusdamage = BonusDamage;
            EquipTypeE = Type;
            EquipQualityE = Quality;
            switch (EquipQualityE)
            {
                case EquipQuality.Common:
                    bonusdamage *= 1;
                    break;
                case EquipQuality.Rare:
                    bonusdamage *= 1.2;
                    break;
                case EquipQuality.Mystic:
                    bonusdamage *= 1.4;
                    break;
                case EquipQuality.Legendary:
                    bonusdamage *= 1.5;
                    break;
            }
               
        }

    }

    public enum EquipType
    {
         Helmet = 1, Armor = 2 , Boots = 3, Weapon= 4
    }

    public enum Place
    {
        Dead, Town, Cave
    }

    public enum Treasure
    {
        Diamonds, Spoon, Empty
    }

    public enum EquipName
    {
        ExcellentEquip, OldEquip, AbsolutTheBestEquip, UnNormal, GreatLord, Botrk, Reveange, Sunshine,
        Com, Realter, Tort, NeTort
    }

    public enum EquipQuality
    {
        Common, Rare, Mystic, Legendary
    }

}