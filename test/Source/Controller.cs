using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Controller
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
            Console.Clear();
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
                case "Помощь":
                    Help();
                    break;
                case "Параметры":
                    Character.ReturnHeroStats(ControlHero);
                    break;
                case "Лечиться":
                    if (ControlHero.Health < ControlHero.Maxhealth)
                    {
                        City.RegenHp(ControlHero);
                    }
                    else
                        Console.WriteLine("У вас максимально здоровья");
                    break;
                case "Город":
                    ControlHero.GoInTown();
                    break;
                case "Пещера":
                    ControlHero.GoInCave();
                    break;
                case "Бой":

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
        public static void Help()
        {
            Console.WriteLine("Выход - Выйти из приложения");
            Console.WriteLine("Урон - нанести себе 10 урона");
            Console.WriteLine("Генерация - Создает вам случайную экипировку");
            Console.WriteLine("Параметры - вывести все характеристики персонажа");
            Console.WriteLine("Лечиться - лечит вашего персонажа до максимума за 10 монет. Только в городе");
            Console.WriteLine("Город - чтобы отправиться в город. При условии что вы не находитесь в нем");
            Console.WriteLine("Пещера - чтобы отправиться в пещеру, если вы не в ней");
        }
    }
}
