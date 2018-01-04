using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class City
    {
        public static void RegenHp(Character Hero)
        {
            if (Hero.Gold >= 10 && Hero.place == Place.Town && Hero.Health != Hero.Maxhealth)
            {
                Hero.Gold = Hero.Gold - 10;
                Hero.Health = Hero.Maxhealth;
                Console.WriteLine("С вас сняли: 10 золотых  " + "У вас сейчас золота: " + Hero.Gold);
                Console.WriteLine("Ваше здоровье восстановлено. Нынешнее здоровье: " + Hero.Health);
            }
            if (Hero.Gold < 10)
            {
                Console.WriteLine("У вас недостаточно золота");
            }
            if (Hero.place != Place.Town)
            {
                if (Hero.place == Place.Cave)
                {
                    Console.WriteLine("Вы в пещере, и не можете сейчас лечиться");
                }
            }
            if (Hero.place == Place.Dead)
            {
                Console.WriteLine("Вы мертвы! Введите <Воскреснуть>");
            }
            if (Hero.Health == Hero.Maxhealth)
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
}
