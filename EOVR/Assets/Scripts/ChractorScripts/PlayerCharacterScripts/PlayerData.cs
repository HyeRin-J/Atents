using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerData
{
    public class CharacterData
    {

        public enum CHARACTERCLASS
        { SWORDMAN, DRAGOON, WARROCK, MEDIC, BARD }
        public enum EQUIPMENTTYPE
        { WEAPON, ARMOR, SUBARMOR, ACCESSORY }
        public enum NEEDS
        { None, Sword, Raiper, Axe, Bow, Staff, Gun, Sheild }
        public struct PLUSPROPERTY
        {
            public int pStats;
            public int mStats;
            public PlusProperty plusProperty1;
            public int plusValue1;
            public PlusProperty plusProperty2;
            public int plusValue2;
        }
        public struct Stats
        {
            public int MAXHP;
            public int MAXTP;
            public int STR;
            public int INT;
            public int VIT;
            public int WIS;
            public int AGI;
            public int LUK;
        }

    }
    public class SkillData
    {
        public enum NEEDS
        { None, Sword, Raiper, Axe, Bow, Staff, Gun, Sheild }
        public enum TYPE
        { Passive, Active }
        public enum DMGTYPE
        { None, Physics, Magical, StatUp, Guard, Buff, Debuff, Heal, Charge, Delayed }
        public enum PATKTYPE
        { None, Cut, Bash, Melee }
        public enum MATKTYPE
        { None, Fire, Ice, Lightening, Magical, All }
        public enum ALLIES
        { None, Enemy, Allies }
        public enum AREATYPE
        { None, Single, Row, Area, Myself }
        public enum RANGE
        { None, Near, Ranged }
        public delegate void PassiveSkill(GameObject actor);

    }



}
