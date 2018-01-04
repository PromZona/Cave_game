using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Cave
    {
        Random rnd = new Random();
        static public int CaveDifficult;       
        public Enemy enemy;
        public Character hero;

        public Cave(int Difficult, Character character)
        {
            CaveDifficult = Difficult;
            hero = character;
            enemy = null;
        }

        public void Fight()
        {
            enemy = CreateEnemy();
            Console.WriteLine("Бой начался!");
            while (enemy.Health != 0 || hero.Health != 0)
            {
                ShowFightStatus();
                enemy.AcceptDamage(hero.MakeDamage(), hero.equipment[4].damagetype);
            }            
        }

        private Enemy CreateEnemy()
        {
            Enemy enemy = new Enemy(CaveDifficult);
            return enemy;
        }

        private void ShowFightStatus()
        {
            Console.WriteLine("            Hero              Enemy    ");
            Console.WriteLine("Здоровье: " + hero.Health + "             " + enemy.Health);
            Console.WriteLine();
        }
    }
}
