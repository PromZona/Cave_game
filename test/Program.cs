using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Character Hero = new Character(100, 10, 100, new bool[7]);
            Controller Control = new Controller(Hero);

        //Основной игровой цикл
        Game:
            do
            {
                Console.WriteLine("Введите команду. Список команд - <Помощь>");
                Controller.ReadCommand();
            } while (Controller.WantExit == false);

        //код для выхода  из игры
        Exit:
            Console.WriteLine("Вы уверены что хотите выйти? да/нет");
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
}