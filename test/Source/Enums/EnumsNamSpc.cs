using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public enum EquipType
    {
        Helmet = 1, Armor = 2, Boots = 3, Weapon = 4
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

    public enum DamageType
    {
        NULL, Prick, Crush, Hack, Fire, Cold, Ground, Wind, Light, Dark
    }

    public enum Skills
    {
        Attack, SlashAttack, SneakyAttack, StunAttack, FireBall, Exhaust, Heal, HardHeal
    }
}
