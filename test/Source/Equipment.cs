using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Equipment
    {
        Random rnd = new Random();
        public string Name;
        public double BonusDamage;
        public EquipType EquipTypeE;
        public EquipQuality EquipQualityE;
        public DamageType Resist;
        public DamageType damagetype;

        public Equipment(double bonusdamage, string name, EquipType type, EquipQuality quality)
        {
            Name = name;
            BonusDamage = bonusdamage;
            EquipTypeE = type;
            EquipQualityE = quality;
            switch (EquipQualityE)
            {
                case EquipQuality.Common:
                    BonusDamage *= 1;
                    Resist = DamageType.NULL;
                    damagetype = DamageType.NULL;
                    break;
                case EquipQuality.Rare:
                    BonusDamage *= 1.2;
                    AddResistAndDamage();
                    break;
                case EquipQuality.Mystic:
                    BonusDamage *= 1.4;
                    AddResistAndDamage();
                    break;
                case EquipQuality.Legendary:
                    BonusDamage *= 1.5;
                    AddResistAndDamage();
                    break;
            }
        }

        private void AddResistAndDamage()
        {
            if (EquipTypeE == EquipType.Weapon)
            {
                damagetype = (DamageType)rnd.Next(0, 8);
            }
            else
            {
                Resist = (DamageType)rnd.Next(0, 8);
            }
        }

    }
}
