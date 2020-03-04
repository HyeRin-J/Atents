using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonData
{
    public class MonsterCharacterData
    {
        public enum MonsterClass //몬스터 종류
        {
            Normal,
            BigMonster,
            FOE,
            BOSS
        }

        public struct Mstats  //몬스터스탯
        {
            public int Hp;    
            public int pAtk;   
            public int mAtk;  
            public int pDef;   
            public int mDef;
            public int mExp;
        }

        public struct MResist //몬스터 상태이상 저항
        {
            public enum PhysicsResist
            {
                Cut,
                Melee,
                Bash,
            }

            public enum MagicalResist
            {
                Fire,
                Ice,
                Lightening,
            }

            public enum StstusResist
            {
                Poison,
                Paralyze,
                Confusion,
                Sleep,
            }
        }

        public string dropItems; //드랍아이템       
    }

    public class MSkillData //몬스터 스킬데이터
    {
        public enum DMGTYPE
        { None, Physics, Magical, Guard, Buff, Debuff, Heal, Charge }
        public enum PATKTYPE
        { None, Cut, Bash, Melee }
        public enum MATKTYPE
        { None, Fire, Ice, Lightening, All }
        public enum ALLIES
        { None, Allies, Enemy }
        public enum AREATYPE
        { None, Single, Row, Area, Myself }
        public enum RANGE
        { None, Near, Ranged }       
    }
}
