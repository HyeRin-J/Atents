using System.Collections;
using System.Collections.Generic;
using PlayerData;
using UnityEngine;

namespace Skill
{
    public enum ATTACKTYPE
    {
        PHYSICAL = 0,
        MAGIC = 1
    }
    public enum SKILLLIST
    {
        SwordMan_PhysicalAttackBoost = 1101,
        SwordMan_DoubleAttack = 1102,
        SwordMan_PhysicalDefenseBoost = 1103,
        SwordMan_HPBoost = 1104,
        SwordMan_TPBoost = 1105,
        SwordMan_SwordMastery = 1111,
        SwordMan_RaisingEdge = 1112,
        SwordMan_Tornado = 1113,
        SwordMan_SpiralSlice = 1114,
        SwordMan_SwordTempest = 1115,
        SwordMan_AxeMastery = 1121,
        SwordMan_BoomerangAxe = 1122,
        SwordMan_BraveSmash = 1123,
        SwordMan_PowerGain = 1124,
        SwordMan_HeavyShock = 1125,
        SwordMan_WarCry = 1131,
        SwordMan_SwordBreak = 1132,
        SwordMan_FlameCharge = 1141,
        SwordMan_IceCharge = 1142,
        SwordMan_ShockCharge = 1143,
        SwordMan_TryCharge = 1144,

        Dragoon_ShieldMastery = 2101,
        Dragoon_HeavyWeaponMastery = 2102,
        Dragoon_HPBoost = 2103,
        Dragoon_ShieldThrow = 2104,
        Dragoon_BarrageWall = 2105,
        Dragoon_BurstCannon = 2106,
        Dragoon_LineGuard = 2111,
        Dragoon_MaterialGuard = 2112,
        Dragoon_HealGuard = 2113,
        Dragoon_GunMount = 2114,
        Dragoon_CounterGuard = 2115,
        Dragoon_DivideGuard = 2116,
        Dragoon_FullGuard = 2117,
        Dragoon_SoulGuard = 2118,
        Dragoon_DefenseFormation = 2121,
        Dragoon_DragonRoar = 2122,
        Dragoon_DragonsProtection = 2123,

        Warrock_MagicDefenseBoost = 3101,
        Warrock_TPBoost = 3102,
        Warrock_MagicMastery = 3103,
        Warrock_HighSpeedCasting = 3104,
        Warrock_AmpRewh = 3105,
        Warrock_MagicShield = 3106,
        Warrock_AntiMagic = 3107,
        Warrock_LifeDrain = 3108,
        Warrock_CompressSpell = 3111,
        Warrock_MultipleSpell = 3112,
        Warrock_FireBall = 3121,
        Warrock_IcecleLance = 3122,
        Warrock_Lighting = 3123,
        Warrock_WindStorm = 3124,
        Warrock_EarthSpike = 3125,
        Warrock_StoneShower = 3126,
        Warrock_Alter = 3127,

        Medic_StaffMastery = 4101,
        Medic_MagicDefenceBoost = 4102,
        Medic_Refresh = 4111,
        Medic_OverHeal = 4112,
        Medic_AntiBody = 4113,
        Medic_Resurrection = 4114,
        Medic_LastHeal = 4115,
        Medic_Healing = 4121,
        Medic_LineHeal = 4122,
        Medic_DelayHeal = 4123,
        Medic_ChaseHeal = 4124,
        Medic_AreaHeal = 4125,
        Medic_FullRecovery = 4126,
        Medic_StarDrop = 4131,
        Medic_MedicalRod = 4132,
        Medic_HeavyStrike = 4143,

        Bard_PhysicalDefenseBoost = 5101,
        Bard_HPBoost = 5102,
        Bard_TPBoost = 5103,
        Bard_SongMastery = 5104,
        Bard_ViolentBattleSong = 5111,
        Bard_DuetOfScanda = 5121,
        Bard_HolyProtectionSong = 5112,
        Bard_SavagesMarch = 5122,
        Bard_DuetOfLife = 5123,
        Bard_MelodyOfWiseEye = 5113,
        Bard_FlameFantasia = 5124,
        Bard_FreezingFantasia = 5125,
        Bard_ThunderFantasia = 5126,
        Bard_MelodyOfAgriculture = 5114,
        Bard_RequiemOfNesa = 5127,
        Bard_DuetOfVitality = 5128,
        Bard_SoundResonance = 5131,

        //몬스터 스킬명
        Monster_Unknown = 500,
        Monster_Tackle101 = 501, //몸통박치기
        Monster_Bufu102 = 502,
        Monster_Mabufu103 = 503,
        Monster_Buchikamashi104 = 504,
        Monster_Tarukaja104 = 505,
        Monster_Cleave = 506,
        Monster_StunningSlice = 507,
        Monster_PoisonSlice = 508,
        Monster_LullabySong = 509,
        Monster_TwinSlash = 510,        //브루탈 슬래시
        Monster_BestialRoar108 = 511,
        Monster_ThornChains109 = 512,
        Monster_Rakunda109 = 513,
        Monster_Bufu110 = 514,
        Monster_ThornChains110 = 515,
        Monster_FangSmash111 = 516,        //이부수기
        Monster_KidneySmash111 = 517,      //내장부수기
        Monster_BindingCry112 = 518,       //바인드보이스
        Monster_ThornCuffs112 = 519,
        Monster_Zio = 520,
        Monster_FireDance114 = 521,
        Monster_Tarukaja114 = 522,
        Monster_IceDance115 = 523,
        Monster_Media = 524,
        Monster_MowDown116 = 525,          //후려치기
        Monster_ThornShackles = 526,
        Monster_ElecDance117 = 527,
        Monster_SpiderWeb117 = 528,
        Monster_Mabufu118 = 529,
        Monster_ThornChains118 = 530,
        Monster_DoubleShot = 531,
        Monster_SingleShot = 532,
        Monster_Stona = 533,            //컨퓨전페트리
        Monster_PowerCharge120 = 534,
        Monster_PoisonBreath121 = 535,
        Monster_ButterflyDance = 536,
        Monster_Tentarafoo122 = 537,
        Monster_ThornCuffs122 = 538,
        Monster_ElecDance123 = 539,
        Monster_MindCharge = 540,       //컨센트레이트
        Monster_Diarahan124 = 541,
        Monster_LifeWall124 = 542,      //보디베리어
        Monster_StabShower = 543,
        Monster_Tarukaja125 = 544,
        Monster_Garula = 545,
        Monster_Magarula = 546,
        Monster_WindCorrosion = 547,
        Monster_MightySwing127 = 548,      //강살참
        Monster_Rakunda127 = 549,
        Monster_BroadShot = 550,         //호라이즈샷
        Monster_PowerCharge128 = 551,
        Monster_FangSmash129 = 552,        //이부수기
        Monster_KidneySmash129 = 553,      //내장부수기
        Monster_Masukunda129 = 554,
        Monster_Zionga = 555,
        Monster_Mazionga130 = 556,
        Monster_ElecCorrosion = 557,
        Monster_AssaultShot131 = 558,
        Monster_BestialRoar131 = 559,
        Monster_LifeWall132 = 560,      //보디베리어
        Monster_Matarukaja = 561,
        Monster_Agilao = 562,
        Monster_Maragion133 = 563,
        Monster_FireCorrosion = 564,
        Monster_HardSlash134 = 565,        //하이슬래쉬
        Monster_HeatWave = 566,
        Monster_Marakunda = 567,
        Monster_SilentSong135 = 568,
        Monster_MuscleDown = 569,
        Monster_Spiderweb135 = 570,
        Monster_Tousatsujin = 571,       //동살인
        Monster_ScorchingBlast = 572,    //작열발파
        Monster_Masukunda136 = 573,
        Monster_Bufula = 574,
        Monster_Mabufula137 = 575,
        Monster_IceCorrosion = 576,
        Monster_Maragi201 = 577,
        Monster_ThornChains201 = 578,
        Monster_EvilSmile = 579,
        Monster_Diarahan202 = 580,
        Monster_Megido = 581,
        Monster_BestialRoar203 = 582,
        Monster_Rakunda203 = 583,
        Monster_MightySwing301 = 584,
        Monster_AssaultShot301 = 585,
        Monster_PoisonBreath301 = 586,
        Monster_LightningSmash = 587,   //자전쇄,
        Monster_Mazio = 588,
        Monster_BindingCry302 = 589,
        Monster_MowDown303 = 590,
        Monster_Mabufu303 = 591,
        Monster_Tentarafoo303 = 592,
        Monster_GiganticFist = 593,
        Monster_BestialRoar304 = 594,
        Monster_SilentSong304 = 595,
        Monster_AssaultShot305 = 596,
        Monster_Maragi305 = 597,
        Monster_Tarukaja305 = 598,
        Monster_Maragion306 = 599,
        Monster_Mazionga306 = 600,
        Monster_Mabufula306 = 601,
        Monster_MowDown401 = 602,
        Monster_FireDance401 = 603,
        Monster_IceDance401 = 604,
        Monster_Vow = 605,              //서약의말
        Monster_HolyWrath = 606,        //천벌
        Monster_HardSlash402 = 607
    }


    public class SkillImplementation : MonoBehaviour
    {
        public int GetCommonDamage(PlayerCharacter pc,int[] attackType,float skillPercent, BattleMonster monster,ATTACKTYPE atktype)   //공통 기본 데미지 계산식
        {
            float randomDamage,increaseAttack;  //랜덤데미지,공격력 증감량
            float weaknessDamage = GetWeaknessRate(attackType, monster.monsterCharacter.monStatRecord.Weakness);   //약점 배율 계산
            int playerAtk, monsterDef;          
            if(atktype == ATTACKTYPE.PHYSICAL)//물리공격스킬일 경우
            {
                playerAtk = pc.physicalAtk;
                monsterDef = monster.monsterCharacter.monStatRecord.Pdef;
                increaseAttack = pc.increasePhysicalAttackbySkill + pc.increasePhysicalAttackbyBuff;
            }
            else                              //마법공격스킬일 경우
            {
                playerAtk = pc.magicAtk;
                monsterDef = monster.monsterCharacter.monStatRecord.Mdef;
                increaseAttack = pc.increaseMagicAttackbySkill + pc.increaseMagicAttackbyBuff;
            }
            if (playerAtk < monsterDef * 3)     //랜덤 데미지 계산
                randomDamage = 0.95f;
            else if (playerAtk == monsterDef * 3)
                randomDamage = 1.0f;
            else
                randomDamage = 1.05f;
            int baseAtk = playerAtk - monsterDef;//기본 데미지
            float damage = baseAtk + baseAtk * increaseAttack;//스킬 증감률 연산       
            damage = damage * pc.independentIncreaseRate * skillPercent * randomDamage;//독립 공격력,스킬배수,랜덤 데미지 연산
            damage = damage * weaknessDamage;//약점 연산
            if (CriticalHit() < 10)         //크리티컬 연산
                damage = damage * 1.5f;
            return (int)damage;
        }
        private float GetWeaknessRate(int[] attackType, int[] weakness)          //약점속성에 대한 배율 계산
        {
            float weaknessRate = 1f;
            float weak = 1;
            for (int i = 0; i < attackType.Length; i++)
            {
                if (attackType[i] == 1)
                {
                    if (weakness[i] == 4)
                        weaknessRate *= 1.5f;
                    else if (weakness[i] == 1)
                        weak *= 0.5f;
                }
            }
            if (weaknessRate == 1f)
            {
                weaknessRate = weak;
            }
            return weaknessRate;
        }
        private int CriticalHit()
        {
            return UnityEngine.Random.Range(1, 100);
        }
        #region SwordMan
        private int[] SwordManCheck(PlayerCharacter actor)                      //소드맨 스킬에 의한 추가 속성 확인
        {
            SwordManCharacter swordMan = actor.gameObject.GetComponent<SwordManCharacter>();
            int[] skillCheck;
            if (swordMan.flameCharge == true)
            {
                skillCheck = new int[6] { 0, 0, 0, 1, 0, 0 };
                actor.independentIncreaseRate = swordMan.flameChargeRate;
                swordMan.Reset();
            }
            else if (swordMan.iceCharge == true)
            {
                skillCheck = new int[6] { 0, 0, 0, 1, 1, 0 };
                actor.independentIncreaseRate = swordMan.iceChargeRate;
                swordMan.Reset();
            }
            else if (swordMan.shockCharge == true)
            {
                skillCheck = new int[6] { 0, 0, 0, 0, 0, 1 };
                actor.independentIncreaseRate = swordMan.shockChargeRate;
                swordMan.Reset();
            }
            else if (swordMan.tryCharge == true)
            {
                skillCheck = new int[6] { 0, 0, 0, 1, 1, 1 };
                actor.independentIncreaseRate = swordMan.tryChargeRate;
                swordMan.Reset();
            }
            else
            {
                skillCheck = new int[6] { 0, 0, 0, 0, 0, 0 };
                actor.independentIncreaseRate = 1f;
            }
            return skillCheck;
        }
        
       
        public int SwordMan_PhysicalAttackBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill PhysicalAttackBoost  = _SwordMan_PhysicalAttackBoost;
            pc.passiveSkill -= PhysicalAttackBoost;
            pc.passiveSkill += PhysicalAttackBoost;
            return 0;
        }
        private void _SwordMan_PhysicalAttackBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_PhysicalAttackBoost;           
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.increasePhysicalAttackbySkill += (skillPercent - 1);
        }
        public int SwordMan_DoubleAttack(GameObject actor)
        {
            return 0;
        }
        public int SwordMan_PhysicalDefenseBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill PhysicalDefenseBoost = _SwordMan_PhysicalDefenseBoost;
            pc.passiveSkill -= PhysicalDefenseBoost;
            pc.passiveSkill += PhysicalDefenseBoost;
            return 0;
        }
        private void _SwordMan_PhysicalDefenseBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_PhysicalDefenseBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.increasePhysicalDefensebySkill += (skillPercent - 1);
        }
        public int SwordMan_HPBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill HPBoost = _SwordMan_HPBoost;
            pc.passiveSkill -= HPBoost;
            pc.passiveSkill += HPBoost;
            return 0;
        }
        private void _SwordMan_HPBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_HPBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            CharacterData.Stats stats = pc.GetCharacterStats();
            stats.MAXHP = (int)(stats.MAXHP * (skillPercent - 1));
            stats.MAXTP = 0;
            pc.SetTotalStats(stats);

        }
        public int SwordMan_TPBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill TPBoost = _SwordMan_TPBoost;
            pc.passiveSkill -= TPBoost;
            pc.passiveSkill += TPBoost;
            return 0;
        }
        private void _SwordMan_TPBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_TPBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            CharacterData.Stats stats = pc.GetCharacterStats();
            stats.MAXHP = 0;
            stats.MAXTP = (int)(stats.MAXTP * (skillPercent - 1));
            pc.SetTotalStats(stats);
        }
        public int SwordMan_SwordMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill SwordMastery = _SwordMan_SwordMastery;
            pc.passiveSkill -= SwordMastery;
            pc.passiveSkill += SwordMastery;
            return 0;
        }
        private void _SwordMan_SwordMastery(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_SwordMastery;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            if (10100 < pc.weapon && pc.weapon < 10200)
            {
                pc.increasePhysicalAttackbySkill += (skillPercent - 1);
            }
        }
        public int SwordMan_RaisingEdge(GameObject actor, GameObject[] target)//지정 단일 근접 참격
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_RaisingEdge;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;
        }
        public int SwordMan_Tornado(GameObject actor, GameObject[] target)//지정 1열 근접 참격
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_Tornado;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;
        }
        public int SwordMan_SpiralSlice(GameObject actor, GameObject[] target)//랜덤 단일 근접 참격
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_SpiralSlice;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;
        }
        public int SwordMan_SwordTempest(GameObject actor, GameObject[] target)//지정 전체 원격 참격
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_RaisingEdge;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent,monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;
        }

        public int SwordMan_AxeMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill AxeMastery = _SwordMan_AxeMastery;
            pc.passiveSkill -= AxeMastery;
            pc.passiveSkill += AxeMastery;
            return 0;
        }
        private void _SwordMan_AxeMastery(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_AxeMastery;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            if (10300 < pc.weapon && pc.weapon < 10400)
            {
                pc.increasePhysicalAttackbySkill += (skillPercent - 1);
            }
        }
        public int SwordMan_BoomerangAxe(GameObject actor, GameObject[] target)//지정 단일 원격 파괴
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_BoomerangAxe;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;
        }
        public int SwordMan_BraveSmash(GameObject actor, GameObject[] target)//지정 단일 근접 파괴 확률혼란
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_BraveSmash;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
                //확률 혼란 추가 예정
            }
            return 0;
        }
        public int SwordMan_PowerGain(GameObject actor, GameObject[] target)//지정 단일 근접 파괴
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_PowerGain;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;

        }
        public int SwordMan_HeavyShock(GameObject actor, GameObject[] target)//지정 단일 근접 파괴 (반복 실행시 공격력,tp소모량 2배 3회중첩)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_HeavyShock;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            int useCount = pc.GetComponent<SwordManCharacter>().heavyShockCount;
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                float damage;
                monsters[i] = target[i].GetComponent<BattleMonster>();
                damage = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
                damage = damage * Mathf.Pow(2, useCount);
                monsters[i].monDamageAmount = (int)damage;                
                //별도 함수 추가예정(횟수에따른 효과)
            }
            if (useCount <= 3)
                useCount++;
            pc.GetComponent<SwordManCharacter>().heavyShockCount = useCount;

            return 0;
        }
        public int SwordMan_WarCry(GameObject actor, GameObject[] Target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.SwordMan_WarCry;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < Target.Length; i++)
            {
                Target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        //일정 턴간 자신의 물리,마법공격력을 상승시키고 물리,마법 방어력을 감소시킨다.
        public int SwordMan_WarCry(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_WarCry;   //스킬 번호
            //저장된 스킬 레벨
            BattlePlayer.BuffSkillsInfo skillinfo = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber));
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트

            pc.increasePhysicalAttackbyBuff += (skillPercent - 1);  //물리공격력 증가
            pc.increaseMagicAttackbyBuff += (skillPercent - 1);     //마법공격력 증가
            pc.increasePhysicalDefensebyBuff -= skillPercent; //물리방어력 감소
            pc.increaseMagicDefensebyBuff -= skillPercent;    //마법방어력 감소
            return 0;
        }
        public int SwordMan_SwordBreak(GameObject actor, GameObject[] target)//지정 단일 근접 파괴  3턴공격력 감소 
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.SwordMan_SwordBreak;
            int[] attackType = SwordManCheck(pc);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
                //타겟 공력력 감소 디버프(함수) 추가 예정
                BattleMonster.DebuffSkillsInfo skillinfo = new BattleMonster.DebuffSkillsInfo();
                skillinfo.duration = 3;
                skillinfo.debuffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
                monsters[i].debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int SwordMan_SwordBreak(GameObject actor)//몬스터 방어력 감소 부분
        {
           BattleMonster bc = actor.GetComponent<BattleMonster>();
           //Monstercharacter mc = actor.GetComponent<Monstercharacter>();
           int skillNumber = (int)SKILLLIST.SwordMan_SwordBreak;   //스킬 번호
           BattleMonster.DebuffSkillsInfo skillinfo = actor.GetComponent<BattleMonster>().debuffSkills.Find(x => (x.debuffs.nID == skillNumber));
           int skillLevel = actor.GetComponent<BattleMonster>().debuffSkills.Find(x => (x.debuffs.nID == skillNumber)).skillLevel;
           float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트
           
           bc.monsterPatkRatio -= skillPercent ;  //물리공격력 감소
           bc.monsterMatkRatio -= skillPercent ;  //마법공격력 감소
            return 0;
        }
        public int SwordMan_FlameCharge(GameObject actor, GameObject[] target)//자신 속성부여 공격력상승 1턴            
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SwordManCharacter swordMan = pc.GetComponent<SwordManCharacter>();
            SkillData.PassiveSkill flameCharge = _SwordMan_FlameCharge;
            int skillNumber = (int)SKILLLIST.SwordMan_FlameCharge;
            swordMan.flameCharge = true;
           swordMan.flameChargeRate = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.chargeDuration = 2;                                          //이번턴 포함 2턴간 지속
            pc.chargeSkill = flameCharge;
            return 0;
        }
        private void _SwordMan_FlameCharge(GameObject actor)          //chargeSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SwordManCharacter swordMan = pc.GetComponent<SwordManCharacter>();
            pc.chargeDuration--;
            if (pc.chargeDuration >= 0)
                return;
            pc.ChargeSkillReset();
            swordMan.flameChargeRate = 0;
            swordMan.flameCharge = false;
        }
        public int SwordMan_IceCharge(GameObject actor, GameObject[] target)//자신 속성부여 공격력상승 1턴
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SwordManCharacter swordMan = pc.GetComponent<SwordManCharacter>();
            SkillData.PassiveSkill iceCharge = _SwordMan_IceCharge;
            int skillNumber = (int)SKILLLIST.SwordMan_IceCharge;
            swordMan.iceCharge = true;
            swordMan.iceChargeRate = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.chargeDuration = 2;                                          
            pc.chargeSkill = iceCharge;
            return 0;
        }
        private void _SwordMan_IceCharge(GameObject actor)          //chargeSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SwordManCharacter swordMan = pc.GetComponent<SwordManCharacter>();
            pc.chargeDuration--;
            if (pc.chargeDuration >= 0)
                return;
            pc.ChargeSkillReset();
            swordMan.iceChargeRate = 0;
            swordMan.iceCharge = false;
        }
        public int SwordMan_ShockCharge(GameObject actor, GameObject[] target)//자신 속성부여 공격력상승 1턴
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SwordManCharacter swordMan = pc.GetComponent<SwordManCharacter>();
            SkillData.PassiveSkill shockCharge = _SwordMan_ShockCharge;
            int skillNumber = (int)SKILLLIST.SwordMan_ShockCharge;
            swordMan.shockCharge = true;
            swordMan.shockChargeRate = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.chargeDuration = 2;
            pc.chargeSkill = shockCharge;
            return 0;
        }
        private void _SwordMan_ShockCharge(GameObject actor)          //chargeSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SwordManCharacter swordMan = pc.GetComponent<SwordManCharacter>();
            pc.chargeDuration--;
            if (pc.chargeDuration >= 0)
                return;
            pc.ChargeSkillReset();
            swordMan.shockChargeRate = 0;
            swordMan.shockCharge = false;
        }
        public int SwordMan_TryCharge(GameObject actor,GameObject[] target)//자신 속성부여 공격력상승 1턴
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SwordManCharacter swordMan = pc.GetComponent<SwordManCharacter>();
            SkillData.PassiveSkill tryCharge = _SwordMan_TryCharge;
            int skillNumber = (int)SKILLLIST.SwordMan_TryCharge;
            swordMan.tryCharge = true;
            swordMan.tryChargeRate = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.chargeDuration = 2;
            pc.chargeSkill = tryCharge;
            return 0;
        }
        private void _SwordMan_TryCharge(GameObject actor)          //chargeSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SwordManCharacter swordMan = pc.GetComponent<SwordManCharacter>();
            pc.chargeDuration--;
            
            if (pc.chargeDuration >= 0)
                return;
            pc.ChargeSkillReset();
            swordMan.tryChargeRate = 0;
            swordMan.tryCharge = false;
        }
        #endregion
        #region Dragoon
        private void GunMountCondition(PlayerCharacter actorPC, int skillnumber = 0)
        {
            DragoonCharacter character = actorPC.gameObject.GetComponent<DragoonCharacter>();
            if (TableMgr.Instance.character_SkillsTable.GetRecord(skillnumber).DmgType == SkillData.DMGTYPE.Guard)
            {
                character.isGuardActivation = true;
            }
            else
                character.isGuardActivation = false;
        }
        public int Dragoon_ShieldMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill ShieldMastery = _Dragoon_ShieldMastery;
            pc.passiveSkill -= ShieldMastery;
            pc.passiveSkill += ShieldMastery;
            return 0;
        }
        private void _Dragoon_ShieldMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_ShieldMastery;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.increasePhysicalDefensebySkill += (skillPercent - 1);
        }
        public int Dragoon_HeavyWeaponMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill HeavyWeaponMastery = _Dragoon_HeavyWeaponMastery;
            pc.passiveSkill += HeavyWeaponMastery;
            pc.passiveSkill -= HeavyWeaponMastery;
            return 0;
        }
        private void _Dragoon_HeavyWeaponMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_HeavyWeaponMastery;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.increasePhysicalAttackbySkill += (skillPercent - 1);
        }
        public int Dragoon_HPBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill HPBoost = _Dragoon_HPBoost;
            pc.passiveSkill -= HPBoost;
            pc.passiveSkill += HPBoost;
            return 0;
        }
        private void _Dragoon_HPBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_HPBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            CharacterData.Stats stats = pc.GetCharacterStats();
            stats.MAXHP = (int)(stats.MAXHP * (skillPercent - 1));
            stats.MAXTP = 0;
            pc.SetTotalStats(stats);
        }
        public int Dragoon_ShieldThrow(GameObject actor,GameObject[] target)//지정 단일 원격 참격
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            pc.gameObject.GetComponent<DragoonCharacter>().guard();
            int skillNumber = (int)SKILLLIST.Dragoon_ShieldThrow;
            GunMountCondition(pc, skillNumber);
            int[] attackType = new int[6] { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);

            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;
        }
        public int Dragoon_BarrageWall(GameObject actor,GameObject[] target)//지정 단체 원격 파괴 3턴공격력감소
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_BarrageWall;
            GunMountCondition(pc, skillNumber);
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
                //타겟 공력력 감소 디버프(함수) 추가 예정
                BattleMonster.DebuffSkillsInfo skillinfo = new BattleMonster.DebuffSkillsInfo();
                skillinfo.duration = 3;
                skillinfo.debuffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
                monsters[i].debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Dragoon_BarrageWall(GameObject actor)//몬스터 방어력 감소 부분
        {
            // pc = actor.GetComponent<BattlePlayer>().playerInfo;
            //int skillNumber = (int)SKILLLIST.SwordMan_WarCry;   //스킬 번호
            //float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber)); //스킬 퍼센트
            //
            //pc.increasePhysicalAttackbyBuff += (skillPercent - 1);  //물리공격력 증가
            //pc.increaseMagicAttackbyBuff += (skillPercent - 1);     //마법공격력 증가
            //pc.increasePhysicalDefensebyBuff -= skillPercent; //물리방어력 감소
            //pc.increaseMagicDefensebyBuff -= skillPercent;    //마법방어력 감소
            return 0;
        }
        public int Dragoon_BurstCannon(GameObject actor,GameObject[] target)//지정 단일 원격 화,빙,전,돌격 
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_BurstCannon;
            int[] attackType = { 0, 1, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()
            {
                for (int i = 0; i < target.Length; i++)
                {
                    monsters[i] = target[i].GetComponent<BattleMonster>();
                    monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);                    
                }
                return 0;
            };
            return 0;
        }
        public int Dragoon_LineGuard(GameObject actor, GameObject[] target)//지정 1열  1턴 물리피격뎀 감소
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_LineGuard;
            GunMountCondition(pc, skillNumber);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().playerInfo.increasePhysicalDefensebySkill += skillPercent;
            }

            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()
            {
                for (int i = 0; i < target.Length; i++)
                {
                    target[i].GetComponent<BattlePlayer>().playerInfo.increasePhysicalDefensebySkill += skillPercent;
                }
                return 0;
            };
            return 0;
        }
        public int Dragoon_MaterialGuard(GameObject actor, GameObject[] target)//지정 1열  1턴 마법피격뎀 감소
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_MaterialGuard;
            GunMountCondition(pc, skillNumber);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().playerInfo.increaseMagicDefensebySkill += skillPercent;
            }

            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()//건마운트용 클로저
            {
                for (int i = 0; i < target.Length; i++)
                {
                    target[i].GetComponent<BattlePlayer>().playerInfo.increaseMagicDefensebySkill += skillPercent;
                }
                return 0;
            };
            return 0;
        }
        public int Dragoon_HealGuard(GameObject actor,GameObject[] target)//지정 1열  1턴 물리피격뎀 감소 회복
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_HealGuard;
            GunMountCondition(pc, skillNumber);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            float skillAdditionalEffectPercent = SkillManager.instance.GetSkillAdditionalEffectPercent(skillNumber, pc.GetSkillLevel(skillNumber));//부가효과 확률
            for (int i = 0; i < target.Length; i++)
            {
                PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                targetPc.increasePhysicalDefensebySkill += skillPercent;
                target[i].GetComponent<BattlePlayer>().healAmount = (int)skillAdditionalEffectPercent;
            }

            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()//건마운트용 클로저
            {
                for (int i = 0; i < target.Length; i++)
                {
                    PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                    targetPc.increasePhysicalDefensebySkill += skillPercent;
                    target[i].GetComponent<BattlePlayer>().healAmount = (int)skillAdditionalEffectPercent;
                }
                return 0;
            };
            return 0;
        }
        public int Dragoon_GunMount(GameObject actor, GameObject[] target)//지정 단일 원격 파괴 가드유지
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            pc.gameObject.GetComponent<DragoonCharacter>().guard();
            int skillNumber = (int)SKILLLIST.Dragoon_GunMount;
            GunMountCondition(pc, skillNumber);//건마운트 연속 사용 가능???
            int[] attackType = new int[6] { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);

            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;
        }
        public int Dragoon_CounterGuard(GameObject actor,GameObject[] target)//지정 단일 피해감소 반격(공격)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_CounterGuard;
            GunMountCondition(pc, skillNumber);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            float skillAdditionalEffectPercent = SkillManager.instance.GetSkillAdditionalEffectPercent(skillNumber, pc.GetSkillLevel(skillNumber));//부가효과 확률
            for (int i = 0; i < target.Length; i++)
            {
                PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                targetPc.isCountGuard = true;//사용여부
                targetPc.increasePhysicalDefensebySkill += skillPercent;
                targetPc.countAttacker = pc;
                targetPc.CountDamagePercent = skillAdditionalEffectPercent;//배율
                //필요한거:카운터 사용여부,때릴 대상(battleplayer.damagedbymonster),때릴 무기(드라군 공격력),배율
            }

            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()//건마운트용 클로저
            {
                for (int i = 0; i < target.Length; i++)
                {
                    PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                    targetPc.isDivideGuard = true;
                    targetPc.increasePhysicalDefensebySkill += skillPercent;
                    targetPc.SoulGuardActivePercent = skillAdditionalEffectPercent;
                }
                return 0;
            };
            return 0;
        }
        public int Dragoon_DivideGuard(GameObject actor,GameObject[] target)//지정 단일 대신피해 1턴
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_DivideGuard;
            GunMountCondition(pc, skillNumber);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            for (int i = 0; i < target.Length; i++)
            {
                PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                targetPc.isDivideGuard = true;
                targetPc.divideTarget = actor.GetComponent<BattlePlayer>();
                targetPc.increasePhysicalDefensebyBuff += skillPercent;
                Debug.Log(targetPc.increasePhysicalDefensebyBuff);
            }

            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()//건마운트용 클로저
            {
                for (int i = 0; i < target.Length; i++)
                {
                    PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                    targetPc.isDivideGuard = true;
                    targetPc.divideTarget = actor.GetComponent<BattlePlayer>();
                    targetPc.increasePhysicalDefensebyBuff += skillPercent;
                }
                return 0;
            };
            return 0;
        }
        public int Dragoon_FullGuard(GameObject actor, GameObject[] target)//지정 단체 피해감소 쿨타임필요
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_DivideGuard;
            GunMountCondition(pc, skillNumber);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            for (int i = 0; i < target.Length; i++)
            {
                PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                targetPc.increasePhysicalDefensebyBuff += skillPercent;
             
            }

            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()//건마운트용 클로저
            {
                Debug.Log(target.Length);
                for (int i = 0; i < target.Length; i++)
                {
                    PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;                    
                    targetPc.increasePhysicalDefensebyBuff += skillPercent;
                }
                return 0;
            };
            return 0;
        }
        public int Dragoon_SoulGuard(GameObject actor, GameObject[] target)//지정 단체 피해감소 확률 사망 방어
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_SoulGuard;
            GunMountCondition(pc, skillNumber);
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            float skillAdditionalEffectPercent = SkillManager.instance.GetSkillAdditionalEffectPercent(skillNumber, pc.GetSkillLevel(skillNumber));//부가효과 확률
            for (int i = 0; i < target.Length; i++)
            {
                PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                targetPc.isSoulGuard = true;
                targetPc.increasePhysicalDefensebySkill += skillPercent;
                targetPc.SoulGuardActivePercent = skillAdditionalEffectPercent;
            }

            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()//건마운트용 클로저
            {
                for (int i = 0; i < target.Length; i++)
                {
                    PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                    targetPc.isDivideGuard = true;
                    targetPc.increasePhysicalDefensebySkill += skillPercent;
                    targetPc.SoulGuardActivePercent = skillAdditionalEffectPercent;
                }
                return 0;
            };
            return 0;
        }
        //일정 턴간 아군 전체의 물리방어력을 상승시킨다.
        public int Dragoon_DefenseFormation(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Dragoon_DefenseFormation;
            GunMountCondition(pc, skillNumber);
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Dragoon_DefenseFormation(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_DefenseFormation;   //스킬 번호
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트

            pc.increasePhysicalDefensebyBuff += skillPercent; //물리방어력 증가
            return 0;
        }
        //일정 턴간 자신의 물리,속성방어력을 올린다.
        public int Dragoon_DragonRoar(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Dragoon_DragonRoar;
            GunMountCondition(pc, skillNumber);
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Dragoon_DragonRoar(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_DefenseFormation;   //스킬 번호
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트

            pc.increasePhysicalDefensebyBuff += skillPercent; //물리방어력
            pc.increaseMagicDefensebyBuff += skillPercent;    //마법방어력
            return 0;
        }
        public int Dragoon_DragonsProtection(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill DragonsProtection = _Dragoon_DragonsProtection;
            pc.passiveSkill -= DragonsProtection;
            pc.passiveSkill += DragonsProtection;
            return 0;
        }
        private void _Dragoon_DragonsProtection(GameObject actor) //passiveSkill에 등록될 내용
        {
            
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Dragoon_DragonsProtection;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            List<PlayerCharacter> players = PartyManager._instance.GetCharacterList();
            if (pc.partyPosition <4)                                //캐릭터가 전열일 경우
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if(players[i].partyPosition>2 && players[i].partyPosition < 6)
                    {
                        players[i].isDragonProtection = true;
                        players[i].DragonProtectionActivePercent = skillPercent;
                    }
                }
            }
            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].partyPosition < 3)
                    {
                        players[i].isDragonProtection = true;
                        players[i].DragonProtectionActivePercent = skillPercent;
                    }
                }
            }
        }
        #endregion
        #region Warrock
        private float WarrockSkillCheck(float damage, PlayerCharacter actor)
        {
            damage = CheckCompressSpell(damage, actor);
            damage = CheckMultipleSpell(damage, actor);
            CheckLifeDrain(damage, actor);
            return damage;
        }

        private float CheckCompressSpell(float damage, PlayerCharacter actor)            //압축술식 사용여부 확인
        {
            WarRockCharacter warrock = actor.GetComponent<WarRockCharacter>();
            if (warrock.isCompreesionSpell == true)
            {
                damage = ApplyCompressSpell(damage, warrock);
                actor.ChargeSkillReset();
                warrock.CompressionSpellRate = 0;
                warrock.isCompreesionSpell = false;
            }
            return damage;
        }
        private float ApplyCompressSpell(float damage, WarRockCharacter warRock)          //압축술식 적용
        {
            return damage * warRock.CompressionSpellRate;
        }
        private float CheckMultipleSpell(float damage, PlayerCharacter actor)             //다단술식 사용여부 확인     
        {
            WarRockCharacter warrock = actor.GetComponent<WarRockCharacter>();
            if (warrock.isCompreesionSpell == true)
            {
                damage = ApplyMultipleSpell(damage, warrock);
                actor.ChargeSkillReset();
                warrock.MultipleSpellRate = 0;
                warrock.isMultipleSpell = false;
            }
            return damage;
        }
        private float ApplyMultipleSpell(float damage, WarRockCharacter warRock)         //다단술식 적용
        {
            return damage * warRock.MultipleSpellRate;
        }
        private float CheckLifeDrain(float damage, PlayerCharacter actor)               //라이프드레인 사용여부 확인
        {
            WarRockCharacter warrock = actor.GetComponent<WarRockCharacter>();
            if (warrock.isLifeDrain == true)
            {
                float healAmount = ApplyLifeDrain(damage, warrock);
                return healAmount;
            }
            return 0;
        }
        private float ApplyLifeDrain(float damage, WarRockCharacter warRock)             //라이프드레인 적용
        {
            return damage * warRock.LifeDrainRate;
        }

        public int Warrock_MagicDefenseBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill MagicDefenseBoost = _Warrock_MagicDefenseBoost;
            pc.passiveSkill -= MagicDefenseBoost;
            pc.passiveSkill += MagicDefenseBoost;
            return 0;
        }
        private void _Warrock_MagicDefenseBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_MagicDefenseBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.increaseMagicDefensebySkill += skillPercent;
        }
        public int Warrock_TPBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill TPBoost = _Warrock_TPBoost;
            pc.passiveSkill -= TPBoost;
            pc.passiveSkill += TPBoost;
            return 0;
        }
        private void _Warrock_TPBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_TPBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            CharacterData.Stats stats = pc.GetCharacterStats();
            stats.MAXHP = 0;
            stats.MAXTP = (int)(stats.MAXTP * (skillPercent - 1));
            pc.SetTotalStats(stats);

        }
        public int Warrock_MagicMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill MagicMastery = _Warrock_MagicMastery;
            pc.passiveSkill -= MagicMastery;
            pc.passiveSkill += MagicMastery;
            return 0;
        }
        private void _Warrock_MagicMastery(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_MagicMastery;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            if (10500 < pc.weapon && pc.weapon < 10600)
            {
                pc.increaseMagicAttackbySkill += (skillPercent - 1);
            }
        }
        public int Warrock_HighSpeedCasting(GameObject actor)
        {
            return 0;
        }
        //일정 턴간 아군 1열의 속성공격력을 증가시킨다.
        public int Warrock_AmpRewh(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Warrock_AmpRewh;//스킬번호
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));//유지 턴수
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);//스킬 레코드
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);//버프 스킬리스트 추가
            }
            return 0;
        }
        public int Warrock_AmpRewh(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_AmpRewh;   //스킬 번호
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber)); //스킬 퍼센트
            pc.increaseMagicAttackbyBuff += (skillPercent - 1);    //마법공격력

            return 0;
        }
        public int Warrock_MagicShield(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Warrock_MagicShield;//스킬번호
            skillinfo.duration = 1;
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);//스킬 레코드
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);//버프 스킬리스트 추가
            }
            return 0;
        }
        public int Warrock_MagicShield(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_MagicShield;   //스킬 번호
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber)); //스킬 퍼센트

            pc.increaseMagicDefensebyBuff += skillPercent;    //마법공격력

            return 0;
        }
        public int Warrock_AntiMagic(GameObject actor)
        {
            return 0;
        }
        public int Warrock_LifeDrain(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill LifeDrain = _Warrock_LifeDarin;
            pc.passiveSkill += LifeDrain;
            return 0;
        }
        private void _Warrock_LifeDarin(GameObject actor)                   //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            WarRockCharacter warrock = pc.GetComponent<WarRockCharacter>();
            int skillNumber = (int)SKILLLIST.Warrock_LifeDrain;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            warrock.isLifeDrain = true;
            warrock.LifeDrainRate = skillPercent;
        }
        public int Warrock_CompressSpell(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            WarRockCharacter warrock = pc.GetComponent<WarRockCharacter>();
            SkillData.PassiveSkill compressSpell = _Warrock_CompressSpell;
            int skillNumber = (int)SKILLLIST.Warrock_CompressSpell;
            warrock.isCompreesionSpell = true;
            warrock.CompressionSpellRate = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.chargeDuration = 2;                                          //이번턴 포함 2턴간 지속
            pc.chargeSkill = compressSpell;
            return 0;
        }
        private void _Warrock_CompressSpell(GameObject actor)               //chargeSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            WarRockCharacter warrock = pc.GetComponent<WarRockCharacter>();
            pc.chargeDuration--;
            if (pc.chargeDuration >= 0)
                return;
            pc.ChargeSkillReset();
            warrock.CompressionSpellRate = 0;
            warrock.isCompreesionSpell = false;
        }
        public int Warrock_MultipleSpell(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            WarRockCharacter warrock = pc.GetComponent<WarRockCharacter>();
            SkillData.PassiveSkill multipleSpell = _Warrock_MultipleSpell;
            int skillNumber = (int)SKILLLIST.Warrock_MultipleSpell;
            warrock.isMultipleSpell = true;
            warrock.MultipleSpellRate = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.chargeDuration = 2;                                          //이번턴 포함 2턴간 지속
            pc.chargeSkill = multipleSpell;
            return 0;
        }
        private void _Warrock_MultipleSpell(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            WarRockCharacter warrock = pc.GetComponent<WarRockCharacter>();
            pc.chargeDuration--;
            if (pc.chargeDuration >= 0)
                return;
            pc.ChargeSkillReset();
            warrock.MultipleSpellRate = 0;
            warrock.isMultipleSpell = false;
        }
        public int Warrock_FireBall(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_FireBall;
            int[] attackType = new int[6];
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetMatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                float damage;
                monsters[i] = target[i].GetComponent<BattleMonster>();
                damage = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.MAGIC);
                damage = WarrockSkillCheck(damage, pc);                
                monsters[i].monDamageAmount = (int)damage;
            }
            return 0;
        }
        public int Warrock_IcecleLance(GameObject actor,GameObject[] target)//랜덤 단일 원격 빙결
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_IcecleLance;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetMatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                float damage;
                monsters[i] = target[i].GetComponent<BattleMonster>();
                damage = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.MAGIC);
                damage = WarrockSkillCheck(damage, pc);
                monsters[i].monDamageAmount = (int)damage;
            }
            return 0;
        }
        public int Warrock_Lighting(GameObject actor, GameObject[] target)//지정 1열 원격 전격
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_Lighting;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetMatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                float damage;
                monsters[i] = target[i].GetComponent<BattleMonster>();
                damage = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.MAGIC);
                damage = WarrockSkillCheck(damage, pc);
                monsters[i].monDamageAmount = (int)damage;
            }
            return 0;
        }
        public int Warrock_WindStorm(GameObject actor, GameObject[] target)//지정 전체 원격 참격 확률혼란
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_WindStorm;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                float damage;
                monsters[i] = target[i].GetComponent<BattleMonster>();
                damage = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
                damage = WarrockSkillCheck(damage, pc);
                monsters[i].monDamageAmount = (int)damage;
            }
            return 0;
        }
        public int Warrock_EarthSpike(GameObject actor, GameObject[] target)//지정 전체 원격 돌격 마공감소
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_EarthSpike;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                float damage;
                monsters[i] = target[i].GetComponent<BattleMonster>();
                damage = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
                damage = WarrockSkillCheck(damage, pc);
                monsters[i].monDamageAmount = (int)damage;
                //타겟 공력력 감소 디버프(함수) 추가 예정
                BattleMonster.DebuffSkillsInfo skillinfo = new BattleMonster.DebuffSkillsInfo();
                skillinfo.duration = 3;          
                skillinfo.debuffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
                monsters[i].debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Warrock_EarthSpike(GameObject actor)//몬스터 마공 감소 부분
        {
            // pc = actor.GetComponent<BattlePlayer>().playerInfo;
            //int skillNumber = (int)SKILLLIST.SwordMan_WarCry;   //스킬 번호
            //float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber)); //스킬 퍼센트
            //
            //pc.increasePhysicalAttackbyBuff += (skillPercent - 1);  //물리공격력 증가
            //pc.increaseMagicAttackbyBuff += (skillPercent - 1);     //마법공격력 증가
            //pc.increasePhysicalDefensebyBuff -= skillPercent; //물리방어력 감소
            //pc.increaseMagicDefensebyBuff -= skillPercent;    //마법방어력 감소
            return 0;
        }
        public int Warrock_StoneShower(GameObject actor, GameObject[] target)//지정 전체 원격 파괴 확률마비
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_StoneShower;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                float damage;
                monsters[i] = target[i].GetComponent<BattleMonster>();
                damage = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.MAGIC);
                damage = WarrockSkillCheck(damage, pc);
                monsters[i].monDamageAmount = (int)damage;
            }
            return 0;
        }
        public int Warrock_Alter(GameObject actor, GameObject[] target)
        {
            PartyManager._instance.isAlter = true;
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Warrock_Alter;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            BattleMonster[] monsters = new BattleMonster[target.Length];
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            skillinfo.duration = 3;
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            actor.GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            return 0;
        }

        public int Warrock_Alter(GameObject actor)
        {
            PartyManager._instance.isAlter = true;
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Bard_ViolentBattleSong;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            actor.GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            return 0;
        }
        // alter 데미지 계산식 발동 방식은 아직 미정
        //private int AlterApply()
        //{
        //      PartyManager._instance.isAlter = false;
        //          PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
        //      int skillNumber = (int)SKILLLIST.Warrock_Alter;
        //      float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
        //      int[] attackType = { 0, 0, 0, 0, 0, 0 };
        //    monsters[i] = target[i].GetComponent<BattleMonster>();
        //    float randomDamage;//랜덤 데미지 계수
        //    float weaknessDamage = GetWeaknessRate(attackType, monsters[i].monsterData.Weakness);//약점 공격시 계수
        //    if (pc.magicAtk < monsters[i].monsterData.Mdef * 3)
        //        randomDamage = 0.95f;
        //    else if (pc.magicAtk == monsters[i].monsterData.Mdef * 3)
        //        randomDamage = 1.0f;
        //    else
        //        randomDamage = 1.05f;
        //    int baseMagicAtk = pc.magicAtk - monsters[i].monsterData.Mdef;//기본 공격력 계산
        //    float damage = baseMagicAtk + baseMagicAtk * (pc.increaseMagicAttackbySkill + pc.increaseMagicAttackbyBuff);//패시브,버프 스킬 증감량 계산
        //    damage = damage * pc.independentIncreaseRate * skillPercent * randomDamage;//독립공격력(차징) 및 배율,랜덤 데미지 추가
        //    damage = damage * weaknessDamage;//약점 데미지 추가
        //    damage = damage + (damage * (0.5f * PartyManager._instance.alterCount));//카운터 * 0.5배만큼 데미지 추가
        //    if (CriticalHit() < 10)
        //        damage = damage * 1.5f;
        //
        //    monsters[i].monDamageAmount = (int)damage;
        //}
        #endregion
        #region Medic
        private int OverHealCheck(float healAmount, PlayerCharacter actor, GameObject target)
        {
            MedicCharacter medic = actor.gameObject.GetComponent<MedicCharacter>();

            BattlePlayer targetBP = target.GetComponent<BattlePlayer>();
            PlayerCharacter targetPC = targetBP.playerInfo;
            float overHealAmount = 0.0f;
            float overHealRate = medic.OverHealRate;
            int targetMaxHP = targetPC.GetCharacterStats().MAXHP;
            if (targetMaxHP - targetPC.currentHp < healAmount)      //오버힐 발생
            {
                targetBP.healAmount = targetMaxHP - targetPC.currentHp;
                Debug.Log(medic.OverHealRate);
                overHealAmount = healAmount - (targetMaxHP - targetPC.currentHp);      //최대체력 초과치가 오버힐에 적용될 양
                if (overHealAmount >= targetMaxHP * (overHealRate - 1))//적용될 양이 스킬 배율을 초과
                    overHealAmount = targetMaxHP * (overHealRate - 1);
                targetBP.flowHp = (int)overHealAmount;

            }
            else
                targetBP.healAmount = (int)healAmount;

            return 0;
        }
        public int Medic_StaffMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill StaffMastery = _Medic_StaffMastery;
            pc.passiveSkill -= StaffMastery;
            pc.passiveSkill += StaffMastery;
            return 0;
        }
        private void _Medic_StaffMastery(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_StaffMastery;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            if (10500 < pc.weapon && pc.weapon < 10600)
            {
                pc.increasePhysicalAttackbySkill += (skillPercent - 1);
                CharacterData.Stats stats = pc.GetCharacterStats();
                stats.MAXHP = 0;
                stats.MAXTP = (int)(stats.MAXTP * (skillPercent - 1));
                pc.SetTotalStats(stats);

            }
        }
        public int Medic_MagicDefenceBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill MagicDefenceBoost = _Medic_MagicDefenceBoost;
            pc.passiveSkill -= MagicDefenceBoost;
            pc.passiveSkill += MagicDefenceBoost;
            return 0;
        }
        private void _Medic_MagicDefenceBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_MagicDefenceBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.increaseMagicDefensebySkill += (skillPercent - 1);
        }
        public int Medic_Refresh()
        {
            return 0;
        }
        public int Medic_OverHeal(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            SkillData.PassiveSkill OverHeal = _Medic_Overheal;
            pc.passiveSkill += OverHeal;
            return 0;
        }
        private void _Medic_Overheal(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            MedicCharacter medic = pc.gameObject.GetComponent<MedicCharacter>();
            int skillNumber = (int)SKILLLIST.Medic_OverHeal;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            medic.OverHealRate = skillPercent;
            medic.isOverHeal = true;
        }
        public int Medic_AntiBody(GameObject actor)
        {
            return 0;
        }
        public int Medic_Resurrection()
        {
            return 0;
        }
        public int Medic_LastHeal()
        {
            return 0;
        }
        public int Medic_Healing(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_Healing;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            float healAmount = pc.GetCharacterStats().WIS + pc.GetCharacterStats().WIS * (pc.increaseMagicAttackbySkill + pc.increaseMagicAttackbyBuff);
            healAmount = healAmount * pc.independentIncreaseRate * skillPercent;
            for (int i = 0; i < target.Length; i++)
            {
                OverHealCheck(healAmount, pc, target[i]);
            }
            return 0;
        }
        public int Medic_LineHeal(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_LineHeal;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            float healAmount = pc.GetCharacterStats().WIS + pc.GetCharacterStats().WIS * (pc.increaseMagicAttackbySkill + pc.increaseMagicAttackbyBuff);
            healAmount = healAmount * pc.independentIncreaseRate * skillPercent;
            for (int i = 0; i < target.Length; i++)
            {
                OverHealCheck(healAmount, pc, target[i]);
            }
            return 0;
        }
        public int Medic_DelayHeal(GameObject actor,GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_DelayHeal;
            int[] attackType = { 0, 1, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            pc.gameObject.GetComponent<DragoonCharacter>().guard = delegate ()
            {
                for (int i = 0; i < target.Length; i++)
                {
                    monsters[i] = target[i].GetComponent<BattleMonster>();
                    monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
                }
                return 0;
            };
            return 0;
        }
        public int Medic_ChaseHeal()
        {
            return 0;
        }
        public int Medic_AreaHeal(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_AreaHeal;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            float healAmount = pc.GetCharacterStats().WIS + pc.GetCharacterStats().WIS * (pc.increaseMagicAttackbySkill + pc.increaseMagicAttackbyBuff);
            healAmount = healAmount * pc.independentIncreaseRate * skillPercent;
            for (int i = 0; i < target.Length; i++)
            {
                OverHealCheck(healAmount, pc, target[i]);
            }
            return 0;
        }
        public int Medic_FullRecovery(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_AreaHeal;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            float healAmount = pc.GetCharacterStats().WIS + pc.GetCharacterStats().WIS * (pc.increaseMagicAttackbySkill + pc.increaseMagicAttackbyBuff);
            healAmount = healAmount * pc.independentIncreaseRate * skillPercent;
            for (int i = 0; i < target.Length; i++)
            {
                PlayerCharacter targetPc = target[i].GetComponent<BattlePlayer>().playerInfo;
                targetPc.currentHp = targetPc.GetCharacterStats().MAXHP;
                //상태이상 해제 추가 예정
            }
            return 0;
        }
        public int Medic_StarDrop(GameObject actor, GameObject[] target)//지정 단일 근접 파괴  3턴물방 감소 
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_StarDrop;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc,attackType,skillPercent,monsters[i],ATTACKTYPE.PHYSICAL);
                //타겟 공력력 감소 디버프(함수) 추가 예정
                BattleMonster.DebuffSkillsInfo skillinfo = new BattleMonster.DebuffSkillsInfo();
                skillinfo.duration = 3;
                skillinfo.debuffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
                monsters[i].debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Medic_StarDrop(GameObject actor)//몬스터 방어력 감소 부분
        {
            // pc = actor.GetComponent<BattlePlayer>().playerInfo;
            //int skillNumber = (int)SKILLLIST.SwordMan_WarCry;   //스킬 번호
            //float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber)); //스킬 퍼센트
            //
            //pc.increasePhysicalAttackbyBuff += (skillPercent - 1);  //물리공격력 증가
            //pc.increaseMagicAttackbyBuff += (skillPercent - 1);     //마법공격력 증가
            //pc.increasePhysicalDefensebyBuff -= skillPercent; //물리방어력 감소
            //pc.increaseMagicDefensebyBuff -= skillPercent;    //마법방어력 감소
            return 0;
        }
        public int Medic_MedicalRod(GameObject actor, GameObject[] target)//지정 단일 근접 파괴  3턴마방 감소 
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_MedicalRod;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {

                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
                //타겟 공력력 감소 디버프(함수) 추가 예정
                BattleMonster.DebuffSkillsInfo skillinfo = new BattleMonster.DebuffSkillsInfo();
                skillinfo.duration = 3;
                skillinfo.debuffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
                monsters[i].debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Medic_MedicalRod(GameObject actor)//몬스터 방어력 감소 부분
        {
            // pc = actor.GetComponent<BattlePlayer>().playerInfo;
            //int skillNumber = (int)SKILLLIST.SwordMan_WarCry;   //스킬 번호
            //float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber)); //스킬 퍼센트
            //
            //pc.increasePhysicalAttackbyBuff += (skillPercent - 1);  //물리공격력 증가
            //pc.increaseMagicAttackbyBuff += (skillPercent - 1);     //마법공격력 증가
            //pc.increasePhysicalDefensebyBuff -= skillPercent; //물리방어력 감소
            //pc.increaseMagicDefensebyBuff -= skillPercent;    //마법방어력 감소
            return 0;
        }
        public int Medic_HeavyStrike(GameObject actor, GameObject[] target)//지정 단일 근접 파괴  
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Medic_HeavyStrike;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.PHYSICAL);
            }
            return 0;
        }
        #endregion
        #region Bard
        public int Bard_PhysicalDefenseBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill PhysicalDefenseBoost = _Bard_PhysicalDefenseBoost;
            pc.passiveSkill -= PhysicalDefenseBoost;
            pc.passiveSkill += PhysicalDefenseBoost;
            return 0;
        }
        private void _Bard_PhysicalDefenseBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_PhysicalDefenseBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            pc.increasePhysicalDefensebySkill += (skillPercent - 1);
        }
        public int Bard_HPBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill HPBoost = _Bard_HPBoost;
            pc.passiveSkill -= HPBoost;
            pc.passiveSkill += HPBoost;
            return 0;
        }
        private void _Bard_HPBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_HPBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            CharacterData.Stats stats = pc.GetCharacterStats();
            stats.MAXHP = (int)(stats.MAXHP * (skillPercent - 1));
            stats.MAXTP = 0;
            pc.SetTotalStats(stats);

        }
        public int Bard_TPBoost(GameObject actor)
        {
            PlayerCharacter pc = actor.GetComponent<PlayerCharacter>();
            SkillData.PassiveSkill TPBoost = _Bard_TPBoost;
            pc.passiveSkill -= TPBoost;
            pc.passiveSkill += TPBoost;
            return 0;
        }
        private void _Bard_TPBoost(GameObject actor) //passiveSkill에 등록될 내용
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_TPBoost;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            CharacterData.Stats stats = pc.GetCharacterStats();
            stats.MAXHP = 0;
            stats.MAXTP = (int)(stats.MAXTP * (skillPercent - 1));
            pc.SetTotalStats(stats);

        }
        public int Bard_SongMastery(GameObject actor)
        {
            return 0;
        }
        //일정 턴간 아군 전체의 물리공격력을 상승시킨다.
        public int Bard_ViolentBattleSong(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Bard_ViolentBattleSong;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Bard_ViolentBattleSong(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_ViolentBattleSong;   //스킬 번호
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트

            pc.increasePhysicalAttackbyBuff += (skillPercent - 1);    //물리공격력
            return 0;
        }
        //일정 턴 간, 아군 행동속도를 2배로 상승시킨다.
        public int Bard_DuetOfScanda(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Bard_DuetOfScanda;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Bard_DuetOfScanda(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_HolyProtectionSong;   //스킬 번호
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트
            return 0;
        }
        //일정 턴 간, 아군 전체의 물리방어력을 상승시킨다.
        public int Bard_HolyProtectionSong(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Bard_HolyProtectionSong;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Bard_HolyProtectionSong(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_HolyProtectionSong;   //스킬 번호
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트

            pc.increasePhysicalDefensebyBuff += skillPercent;    //물리방어력
            return 0;
        }
        //일정 턴 간, 아군 전체의 최대체력을 상승시킨다.
        public int Bard_SavagesMarch(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Bard_SavagesMarch;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Bard_SavagesMarch(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_HolyProtectionSong;   //스킬 번호
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트

            actor.GetComponent<BattlePlayer>().flowHp = (int)((float)pc.GetCharacterStats().MAXHP * skillPercent);//최대 체력 상승량

            return actor.GetComponent<BattlePlayer>().flowHp;
        }
        public int Bard_DuetOfLife()
        {
            return 0;
        }
        //일정 턴간 아군 전체의 마법공격력을 상승시킨다.
        public int Bard_MelodyOfWiseEye(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Bard_MelodyOfWiseEye;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Bard_MelodyOfWiseEye(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_MelodyOfWiseEye;   //스킬 번호
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트

            pc.increaseMagicAttackbyBuff += (skillPercent - 1);    //마법공격력
            return 0;
        }
        public int Bard_FlameFantasia(GameObject actor, GameObject[] target)//지정 단체 원격 화염  
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_FlameFantasia;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetMatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.MAGIC);
            }
            return 0;
        }
        public int Bard_FreezingFantasia(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_FlameFantasia;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetMatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.MAGIC);
            }
            return 0;
        }
        public int Bard_ThunderFantasia(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_FlameFantasia;
            int[] attackType = { 0, 0, 0, 0, 0, 0 };
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            attackType = SkillManager.instance.GetMatkType(skillNumber, attackType);
            BattleMonster[] monsters = new BattleMonster[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                monsters[i] = target[i].GetComponent<BattleMonster>();
                monsters[i].monDamageAmount = GetCommonDamage(pc, attackType, skillPercent, monsters[i], ATTACKTYPE.MAGIC);
            }
            return 0;
        }
        //일정 턴간 아군 전체의 마법방어력을 상승시킨다.
        public int Bard_MelodyOfAgriculture(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Bard_MelodyOfAgriculture;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Bard_MelodyOfAgriculture(GameObject actor)
        {
            //PlayerCharacter 정보
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_MelodyOfAgriculture;   //스킬 번호
            int skillLevel = actor.GetComponent<BattlePlayer>().buffSkills.Find(x => (x.buffs.nID == skillNumber)).skillLevel;
            float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, skillLevel); //스킬 퍼센트

            pc.increaseMagicDefensebyBuff += skillPercent;    //마법방어력
            return 0;
        }
        //이번 턴, 아군의 상태이상을 1회 방어해준다.
        public int Bard_RequiemOfNesa(GameObject actor, GameObject[] target)
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            BattlePlayer bp = actor.GetComponent<BattlePlayer>();
            BattlePlayer.BuffSkillsInfo skillinfo = new BattlePlayer.BuffSkillsInfo();
            int skillNumber = (int)SKILLLIST.Bard_RequiemOfNesa;
            skillinfo.duration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            skillinfo.skillLevel = pc.GetSkillLevel(skillNumber);
            skillinfo.buffs = TableMgr.Instance.character_SkillsTable.GetRecord(skillNumber);
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Bard_RequiemOfNesa(GameObject actor)//상태이상 공격 1회 방어
        {
            return 0;
        }
        public int Bard_DuetOfVitality()//버프를 받고 있는 아군 tp를 회복
        {
            return 0;
        }
        public int Bard_SoundResonance(GameObject actor, GameObject[] target)//아군 1체에 버프를 다른 아군 1체에 복사
        {
            PlayerCharacter pc = actor.GetComponent<BattlePlayer>().playerInfo;
            int skillNumber = (int)SKILLLIST.Bard_FlameFantasia;
            int skillDuration = SkillManager.instance.GetSkillDuration(skillNumber, pc.GetSkillLevel(skillNumber));
            List<BattlePlayer.BuffSkillsInfo> baseBuff = target[0].GetComponent<BattlePlayer>().buffSkills;
            List<BattlePlayer.BuffSkillsInfo> targetBuff = target[1].GetComponent<BattlePlayer>().buffSkills;
            targetBuff = baseBuff;
            for (int i = 0; i < targetBuff.Count; i++)
            {
                BattlePlayer.BuffSkillsInfo buffSkillInfo = targetBuff[i];
                buffSkillInfo.duration += skillDuration;
                targetBuff[i] = buffSkillInfo;
            }
            return 0;
        }
        #endregion
        #region MonsterSkills 500~510
        public int Monster_Unknown()
        {
            return 0;
        }
        public int Monster_Tackle101(GameObject actor, GameObject[] target) //겁쟁이 마야-몸통박치기(적 1체에 파괴속성 물리데미지를 준다.)
        {
            
            BattleMonster mon = actor.GetComponent<BattleMonster>();                            //몬스터 스크립트 받아옴                
            int mSkillNumber = (int)SKILLLIST.Monster_Tackle101;                    //스킬 넘버            
            Monster_SkillsRecord mSkillrecord = TableMgr.Instance.monster_SkillsTable.GetRecord(mSkillNumber);//몬스터 스킬 레코드  
            //float mSkillPercent;        
            
            //attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);        
            //float skillPercent = mSkillrecord.SkillPercent;
            //GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            
            //BattlePlayer[] player = new BattlePlayer[target.Length];                //공격받을 플레이어 배열


            //int[] attackType = SwordManCheck(pc);

            //int[] attackType = SwordManCheck(pc);
            //float skillPercent = SkillManager.instance.GetSkillPercent(skillNumber, pc.GetSkillLevel(skillNumber));
            //attackType = SkillManager.instance.GetPatkType(skillNumber, attackType);


            //BattleMonster[] monsters = new BattleMonster[Target.Length];

            return 0;
        }
        public int Monster_Bufu102()  //허언의 어블리- 부흐(적 1체에 빙결속성의 마법데미지를 준다.)
        {
            return 0;
        }
        public int Monster_Mabufu103()
        {
            return 0;
        }
        public int Monster_Buchikamashi104()
        {
            return 0;
        }
        //3턴간 자신의 물리공격력을 상승시킨다.
        public int Monster_Tarukaja104(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Tarukaja104;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Tarukaja104(GameObject actor)
        {
            //actor 스탯
            return 0;
        }
        public int Monster_Cleave()
        {
            return 0;
        }
        public int Monster_StunningSlice()
        {
            return 0;
        }
        public int Monster_PoisonSlice()
        {
            return 0;
        }
        //적 전체에 일정 확률로 수면효과를 준다.
        public int Monster_LullabySong(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_LullabySong;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_LullabySong(GameObject actor)
        {
            return 0;
        }
        public int Monster_TwinSlash()
        {
            return 0;
        }
        //3턴간 자신의 물리공격력을 상승시킨다.
        public int Monster_BestialRoar108(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_BestialRoar108;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_BestialRoar108(GameObject actor)
        {
            return 0;
        }
        public int Monster_ThornChains109()
        {
            return 0;
        }
        //3턴간 적 1체의 방어력을 저하시킨다.
        public int Monster_Rakunda109(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Rakunda109;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        //플레이어의 디버프시 호출
        public int Monster_Rakunda109(GameObject actor)
        {
            return 0;
        }
        public int Monster_Bufu110()
        {
            return 0;
        }
        public int Monster_ThornChains110()
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 511~520
        public int Monster_FangSmash111()
        {
            return 0;
        }
        public int Monster_KidneySmash111()
        {
            return 0;
        }
        //적 전체에 일정확률로 마비 효과를 부여한다.
        public int Monster_BindingCry112(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_BindingCry112;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        //플레이어의 디버프 시 호출
        public int Monster_BindingCry112(GameObject actor)
        {

            return 0;
        }
        public int Monster_ThornCuffs112()
        {
            return 0;
        }
        public int Monster_Zio()
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 521~530
        public int Monster_FireDance114()
        {
            return 0;
        }
        //3턴간 자신의 물리공격력을 상승시킨다.
        public int Monster_Tarukaja114(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Tarukaja114;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Tarukaja114(GameObject actor)
        {
            return 0;
        }
        public int Monster_IceDance115()
        {
            return 0;
        }
        public int Monster_Media()
        {
            return 0;
        }
        public int Monster_MowDown116()
        {
            return 0;
        }
        public int Monster_ThornShackles()
        {
            return 0;
        }
        public int Monster_ElecDance117()
        {
            return 0;
        }
        //적 전체에 일정 확률로 마비효과를 준다.
        public int Monster_SpiderWeb117(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_SpiderWeb117;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_SpiderWeb117(GameObject actor)
        {
            return 0;
        }
        public int Monster_Mabufu118()
        {
            return 0;
        }
        public int Monster_ThornChains118()
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 531~540
        public int Monster_DoubleShot()
        {
            return 0;
        }
        public int Monster_SingleShot()
        {
            return 0;
        }
        //적 1체에 일정 확률로 혼란효과를 준다.
        public int Monster_Stona(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Stona(GameObject actor)
        {
            return 0;
        }
        //다음 턴 자신의 물리공격력을 2배로 올린다.
        public int Monster_PowerCharge120(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_PowerCharge120;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_PowerCharge120(GameObject actor)
        {

            return 0;
        }
        //적 전체에 일정 확률로 중독효과를 준다.
        public int Monster_PoisonBreath121(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_PoisonBreath121(GameObject actor)
        {

            return 0;
        }
        //적 1체에 일정 확률로 즉사효과를 준다.
        public int Monster_ButterflyDance(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_ButterflyDance(GameObject actor)
        {
            return 0;
        }
        //적 전체에 일정 확률로 혼란효과를 준다.
        public int Monster_Tentarafoo122(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Tentarafoo122(GameObject actor)
        {
            return 0;
        }
        public int Monster_ThornCuffs122()
        {
            return 0;
        }
        public int Monster_ElecDance123()
        {
            return 0;
        }
        //다음 턴 자신의 마법공격력을 2배로 올린다.
        public int Monster_MindCharge(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_PowerCharge120;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_MindCharge(GameObject actor)
        {

            return 0;
        }
        #endregion
        #region MonsterSkills 541~550
        public int Monster_Diarahan124()
        {
            return 0;
        }
        public int Monster_LifeWall124()
        {
            return 0;
        }
        public int Monster_StabShower()
        {
            return 0;
        }
        //3턴간 자신의 물리공격력을 상승시킨다.
        public int Monster_Tarukaja125(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_PowerCharge120;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Tarukaja125(GameObject actor)
        {
            return 0;
        }
        public int Monster_Garula()
        {
            return 0;
        }
        public int Monster_Magarula()
        {
            return 0;
        }
        //3턴간 적 전체에 물리내성을 저하시킨다.
        public int Monster_WindCorrosion(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_WindCorrosion(GameObject actor)
        {
            return 0;
        }
        public int Monster_MightySwing127()
        {
            return 0;
        }
        //3턴간 적 1체의 방어력을 저하시킨다.
        public int Monster_Rakunda127(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Rakunda127(GameObject actor)
        {
            return 0;
        }
        public int Monster_BroadShot()
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 551~560
        //다음 턴 자신의 물리공격력을 2배로 올린다.
        public int Monster_PowerCharge128(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_PowerCharge120;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_PowerCharge128(GameObject actor)
        {
            return 0;
        }
        public int Monster_FangSmash129()
        {
            return 0;
        }
        public int Monster_KidneySmash129()
        {
            return 0;
        }
        //3턴간 적 전체의 물리공격력을 저하시킨다.
        public int Monster_Masukunda129(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Masukunda129(GameObject actor)
        {
            return 0;
        }
        public int Monster_Zionga()
        {
            return 0;
        }
        public int Monster_Mazionga130()
        {
            return 0;
        }
        //다음 턴 자신의 마법공격력을 2배로 올린다.
        public int Monster_ElecCorrosion(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_PowerCharge120;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_ElecCorrosion(GameObject actor)
        {
            return 0;
        }
        public int Monster_AssaultShot131()
        {
            return 0;
        }
        //3턴간 자신의 물리공격력을 상승시킨다.
        public int Monster_BestialRoar131(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_PowerCharge120;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_BestialRoar131(GameObject actor)
        {
            return 0;
        }
        public int Monster_LifeWall132()
        {
            return 0;
        }
        //3턴간 아군 전체의 물리공격력을 상승시킨다.
        public int Monster_Matarukaja(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_PowerCharge120;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Matarukaja(GameObject actor)
        {
            return 0;
        }
        public int Monster_Agilao()
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 561~570
        public int Monster_Maragion133()
        {
            return 0;
        }
        //3턴간 적 전체의 마법공격력을 저하시킨다.
        public int Monster_FireCorrosion(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_FireCorrosion(GameObject actor)
        {
            return 0;
        }
        public int Monster_HardSlash134()
        {
            return 0;
        }
        public int Monster_HeatWave()
        {
            return 0;
        }
        //3턴간 적 전체의 물리방어력을 저하시킨다.
        public int Monster_Marakunda(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Marakunda(GameObject actor)
        {
            return 0;
        }
        //3턴간 적 전체의 마법공격력을 저하시킨다.
        public int Monster_SilentSong135(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_SilentSong135(GameObject actor)
        {
            return 0;
        }
        //3턴간 적 전체의 물리공격력을 저하시킨다.
        public int Monster_MuscleDown(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_MuscleDown(GameObject actor)
        {
            return 0;
        }
        //적 전체에 일정 확률로 마비효과를 준다.
        public int Monster_Spiderweb135(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Spiderweb135(GameObject actor)
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 571~580
        public int Monster_Tousatsujin()
        {
            return 0;
        }
        public int Monster_ScorchingBlast()
        {
            return 0;
        }
        //3턴간 적 전체의 물리공격력을 저하시킨다.
        public int Monster_Masukunda136(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_Masukunda136(GameObject actor)
        {
            return 0;
        }
        public int Monster_Bufula()
        {
            return 0;
        }
        public int Monster_Mabufula137()
        {
            return 0;
        }
        //3턴간 적 전체의 마법공격력을 저하시킨다.
        public int Monster_IceCorrosion(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //디버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Stona;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 디버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_IceCorrosion(GameObject actor)
        {
            return 0;
        }
        public int Monster_Maragi201()
        {
            return 0;
        }
        public int Monster_ThornChains201()
        {
            return 0;
        }

        // 3턴간 적 전체의 물리공격력과 물리방어력을 저하시킨다.
        public int Monster_EvilSmile(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_EvilSmile;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_EvilSmile(GameObject actor)
        {
            return 0;
        }

        // 아군 1체의 체력을 모두 회복시킨다.
        public int Monster_Diarahan202(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Diarahan202;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_Diarahan202(GameObject actor)
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 581~590
        public int Monster_Megido()
        {
            return 0;
        }

        // 3턴간 자신의 물리공격력을 상승시킨다.
        public int Monster_BestialRoar203(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_BestialRoar203;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_BestialRoar203(GameObject actor)
        {
            return 0;
        }

        // 3턴간 적 1체의 방어력을 저하시킨다.
        public int Monster_Rakunda203(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Rakunda203;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_Rakunda203(GameObject actor)
        {
            return 0;
        }

        public int Monster_MightySwing301()
        {
            return 0;
        }
        public int Monster_AssaultShot301()
        {
            return 0;
        }

        // 적 전체에 일정 확률로 중독효과를 준다.
        public int Monster_PoisonBreath301(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_PoisonBreath301;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_PoisonBreath301(GameObject actor)
        {
            return 0;
        }

        public int Monster_LightningSmash()
        {
            return 0;
        }
        public int Monster_Mazio()
        {
            return 0;
        }
        // 적 전체에 일정확률로 마비 효과를 부여한다.
        public int Monster_BindingCry302(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_BindingCry302;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }
        public int Monster_BindingCry302(GameObject actor)
        {
            return 0;
        }

        public int Monster_MowDown303()
        {
            return 0;
        }
        public int Monster_Mabufu303()
        {
            return 0;
        }
        // 적 전체에 일정 확률로 혼란효과를 준다.
        public int Monster_Tentarafoo303(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Tentarafoo303;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_Tentarafoo303(GameObject actor)
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 591~600
        public int Monster_GiganticFist()
        {
            return 0;
        }

        //3턴간 자신의 물리공격력을 상승시킨다.
        public int Monster_BestialRoar304(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_BestialRoar304;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_BestialRoar304(GameObject actor)
        {
            return 0;
        }

        //적 전체에 일정확률로 마비 효과를 부여한다.
        public int Monster_SilentSong304(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattlePlayer.DebuffSkillsInfo skillinfo = new BattlePlayer.DebuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_SilentSong304;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.debuffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattlePlayer>().debuffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_SilentSong304(GameObject actor)
        {
            return 0;
        }

        public int Monster_AssaultShot305()
        {
            return 0;
        }
        public int Monster_Maragi305()
        {
            return 0;
        }

        //3턴간 자신의 물리공격력을 상승시킨다.
        public int Monster_Tarukaja305(GameObject actor, GameObject[] target)
        {
            //몬스터 스크립트 받아옴
            BattleMonster mon = actor.GetComponent<BattleMonster>();
            //버프스킬 리스트
            BattleMonster.BuffSkillsInfo skillinfo = new BattleMonster.BuffSkillsInfo();
            //스킬 넘버
            int skillNumber = (int)SKILLLIST.Monster_Tarukaja305;
            //몬스터 스킬 레코드
            Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(skillNumber);
            //버프 스킬 정보
            skillinfo.buffs = monster_Skills;
            //턴수
            skillinfo.duration = monster_Skills.Duration;
            //타겟마다 버프스킬 리스트에 add
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<BattleMonster>().buffSkills.Add(skillinfo);
            }
            return 0;
        }

        public int Monster_Tarukaja305(GameObject actor)
        {
            //actor 스탯
            return 0;
        }
        public int Monster_Maragion306()
        {
            return 0;
        }
        #endregion
        #region MonsterSkills 601~607
        public int Monster_Mazionga306()
        {
            return 0;
        }
        public int Monster_Mabufula306()
        {
            return 0;
        }
        public int Monster_MowDown401()
        {
            return 0;
        }
        public int Monster_FireDance401()
        {
            return 0;
        }
        public int Monster_IceDance401()
        {
            return 0;
        }
        public int Monster_Vow()
        {
            return 0;
        }
        public int Monster_HolyWrath()
        {
            return 0;
        }
        public int Monster_HardSlash402()
        {
            return 0;
        }
        #endregion

        public int SkillVitality(int skillnumber, GameObject actor, GameObject[] target)
        {
            switch ((SKILLLIST)skillnumber)
            {
                case SKILLLIST.SwordMan_RaisingEdge:
                    return SwordMan_RaisingEdge(actor, target);
                case SKILLLIST.SwordMan_Tornado:
                    return SwordMan_Tornado(actor, target);
                case SKILLLIST.SwordMan_SpiralSlice:
                    return SwordMan_SpiralSlice(actor, target);
                case SKILLLIST.SwordMan_SwordTempest:
                    return SwordMan_SwordTempest(actor, target);
                case SKILLLIST.SwordMan_AxeMastery:
                    return SwordMan_AxeMastery(actor);
                case SKILLLIST.SwordMan_BoomerangAxe:
                    return SwordMan_BoomerangAxe(actor, target);
                case SKILLLIST.SwordMan_BraveSmash:
                    return SwordMan_BraveSmash(actor, target);
                case SKILLLIST.SwordMan_PowerGain:
                    return SwordMan_PowerGain(actor, target);
                case SKILLLIST.SwordMan_HeavyShock:
                    return SwordMan_HeavyShock(actor, target);
                case SKILLLIST.SwordMan_WarCry:
                    return SwordMan_WarCry(actor, target);
                case SKILLLIST.SwordMan_SwordBreak:
                    return SwordMan_SwordBreak(actor,target);
                case SKILLLIST.SwordMan_FlameCharge:
                    return SwordMan_FlameCharge(actor,target);
                case SKILLLIST.SwordMan_IceCharge:
                    return SwordMan_IceCharge(actor,target);
                case SKILLLIST.SwordMan_ShockCharge:
                    return SwordMan_ShockCharge(actor,target);
                case SKILLLIST.SwordMan_TryCharge:
                    return SwordMan_TryCharge(actor,target);
                case SKILLLIST.Dragoon_ShieldMastery:
                    return Dragoon_ShieldMastery(actor);
                case SKILLLIST.Dragoon_HeavyWeaponMastery:
                    return Dragoon_HeavyWeaponMastery(actor);
                case SKILLLIST.Dragoon_HPBoost:
                    return Dragoon_HPBoost(actor);
                case SKILLLIST.Dragoon_ShieldThrow:
                    return Dragoon_ShieldThrow(actor,target);
                case SKILLLIST.Dragoon_BarrageWall:
                    return Dragoon_BarrageWall(actor,target);
                case SKILLLIST.Dragoon_BurstCannon:
                    return Dragoon_BurstCannon(actor,target);
                case SKILLLIST.Dragoon_LineGuard:
                    return Dragoon_LineGuard(actor, target);
                case SKILLLIST.Dragoon_MaterialGuard:
                    return Dragoon_MaterialGuard(actor,target);
                case SKILLLIST.Dragoon_HealGuard:
                    return Dragoon_HealGuard(actor,target);
                case SKILLLIST.Dragoon_GunMount:
                    return Dragoon_GunMount(actor, target);
                case SKILLLIST.Dragoon_CounterGuard:
                    return Dragoon_CounterGuard(actor,target);
                case SKILLLIST.Dragoon_DivideGuard:
                    return Dragoon_DivideGuard(actor,target);
                case SKILLLIST.Dragoon_FullGuard:
                    return Dragoon_FullGuard(actor,target);
                case SKILLLIST.Dragoon_SoulGuard:
                    return Dragoon_SoulGuard(actor,target);
                case SKILLLIST.Dragoon_DefenseFormation:
                    return Dragoon_DefenseFormation(actor, target);
                case SKILLLIST.Dragoon_DragonRoar:
                    return Dragoon_DragonRoar(actor, target);
                case SKILLLIST.Dragoon_DragonsProtection:
                    return Dragoon_DragonsProtection(actor);

                case SKILLLIST.Warrock_AmpRewh:
                    return Warrock_AmpRewh(actor, target);

                case SKILLLIST.Warrock_FireBall:
                    return Warrock_FireBall(actor,target);
                case SKILLLIST.Warrock_IcecleLance:
                    return Warrock_IcecleLance(actor, target);
                case SKILLLIST.Warrock_Lighting:
                    return Warrock_Lighting(actor, target);
                case SKILLLIST.Warrock_WindStorm:
                    return Warrock_WindStorm(actor, target);
                case SKILLLIST.Warrock_EarthSpike:
                    return Warrock_EarthSpike(actor, target);
                case SKILLLIST.Warrock_StoneShower:
                    return Warrock_StoneShower(actor, target);
                case SKILLLIST.Warrock_Alter:
                    return Warrock_Alter(actor, target);

                case SKILLLIST.Medic_Refresh:
                    return Medic_Refresh();

                case SKILLLIST.Medic_Resurrection:
                    return Medic_Resurrection();
                case SKILLLIST.Medic_LastHeal:
                    return Medic_LastHeal();
                case SKILLLIST.Medic_Healing:
                    return Medic_Healing(actor, target);
                case SKILLLIST.Medic_LineHeal:
                    return Medic_LineHeal(actor,target);
                case SKILLLIST.Medic_DelayHeal:
                    return Medic_DelayHeal(actor,target);
                case SKILLLIST.Medic_ChaseHeal:
                    return Medic_ChaseHeal();
                case SKILLLIST.Medic_AreaHeal:
                    return Medic_AreaHeal(actor, target);
                case SKILLLIST.Medic_FullRecovery:
                    return Medic_FullRecovery(actor, target);
                case SKILLLIST.Medic_StarDrop:
                    return Medic_StarDrop(actor, target);
                case SKILLLIST.Medic_MedicalRod:
                    return Medic_MedicalRod(actor, target);
                case SKILLLIST.Medic_HeavyStrike:
                    return Medic_HeavyStrike(actor, target);

                case SKILLLIST.Bard_ViolentBattleSong:
                    return Bard_ViolentBattleSong(actor, target);
                case SKILLLIST.Bard_DuetOfScanda:
                    return Bard_DuetOfScanda(actor, target);
                case SKILLLIST.Bard_HolyProtectionSong:
                    return Bard_HolyProtectionSong(actor, target);
                case SKILLLIST.Bard_SavagesMarch:
                    return Bard_SavagesMarch(actor, target);
                case SKILLLIST.Bard_DuetOfLife:
                    return Bard_DuetOfLife();
                case SKILLLIST.Bard_MelodyOfWiseEye:
                    return Bard_MelodyOfWiseEye(actor, target);
                case SKILLLIST.Bard_FlameFantasia:
                    return Bard_FlameFantasia(actor,target);
                case SKILLLIST.Bard_FreezingFantasia:
                    return Bard_FreezingFantasia(actor, target);
                case SKILLLIST.Bard_ThunderFantasia:
                    return Bard_ThunderFantasia(actor, target);
                case SKILLLIST.Bard_MelodyOfAgriculture:
                    return Bard_MelodyOfAgriculture(actor, target);
                case SKILLLIST.Bard_RequiemOfNesa:
                    return Bard_RequiemOfNesa(actor, target);
                case SKILLLIST.Bard_DuetOfVitality:
                    return Bard_DuetOfVitality();
                case SKILLLIST.Bard_SoundResonance:
                    return Bard_SoundResonance(actor,target);
                case SKILLLIST.Monster_Unknown:
                    return Monster_Unknown();
                case SKILLLIST.Monster_Tackle101:
                    return Monster_Tackle101(actor, target);
                case SKILLLIST.Monster_Bufu102:
                    return Monster_Bufu102();
                case SKILLLIST.Monster_Mabufu103:
                    return Monster_Mabufu103();
                case SKILLLIST.Monster_Buchikamashi104:
                    return Monster_Buchikamashi104();
                case SKILLLIST.Monster_Tarukaja104:
                    return Monster_Tarukaja104(actor, target);
                case SKILLLIST.Monster_Cleave:
                    return Monster_Cleave();
                case SKILLLIST.Monster_StunningSlice:
                    return Monster_StunningSlice();
                case SKILLLIST.Monster_PoisonSlice:
                    return Monster_PoisonSlice();
                case SKILLLIST.Monster_LullabySong:
                    return Monster_LullabySong(actor, target);
                case SKILLLIST.Monster_TwinSlash:
                    return Monster_TwinSlash();
                case SKILLLIST.Monster_BestialRoar108:
                    return Monster_BestialRoar108(actor, target);
                case SKILLLIST.Monster_ThornChains109:
                    return Monster_ThornChains109();
                case SKILLLIST.Monster_Rakunda109:
                    return Monster_Rakunda109(actor, target);
                case SKILLLIST.Monster_Bufu110:
                    return Monster_Bufu110();
                case SKILLLIST.Monster_ThornChains110:
                    return Monster_ThornChains110();
                case SKILLLIST.Monster_FangSmash111:
                    return Monster_FangSmash111();
                case SKILLLIST.Monster_KidneySmash111:
                    return Monster_KidneySmash111();
                case SKILLLIST.Monster_BindingCry112:
                    return Monster_BindingCry112(actor, target);
                case SKILLLIST.Monster_ThornCuffs112:
                    return Monster_ThornCuffs112();
                case SKILLLIST.Monster_Zio:
                    return Monster_Zio();
                case SKILLLIST.Monster_FireDance114:
                    return Monster_FireDance114();
                case SKILLLIST.Monster_Tarukaja114:
                    return Monster_Tarukaja114(actor, target);
                case SKILLLIST.Monster_IceDance115:
                    return Monster_IceDance115();
                case SKILLLIST.Monster_Media:
                    return Monster_Media();
                case SKILLLIST.Monster_MowDown116:
                    return Monster_MowDown116();
                case SKILLLIST.Monster_ThornShackles:
                    return Monster_ThornShackles();
                case SKILLLIST.Monster_ElecDance117:
                    return Monster_ElecDance117();
                case SKILLLIST.Monster_SpiderWeb117:
                    return Monster_SpiderWeb117(actor, target);
                case SKILLLIST.Monster_Mabufu118:
                    return Monster_Mabufu118();
                case SKILLLIST.Monster_ThornChains118:
                    return Monster_ThornChains118();
                case SKILLLIST.Monster_DoubleShot:
                    return Monster_DoubleShot();
                case SKILLLIST.Monster_SingleShot:
                    return Monster_SingleShot();
                case SKILLLIST.Monster_Stona:
                    return Monster_Stona(actor, target);
                case SKILLLIST.Monster_PowerCharge120:
                    return Monster_PowerCharge120(actor, target);
                case SKILLLIST.Monster_PoisonBreath121:
                    return Monster_PoisonBreath121(actor, target);
                case SKILLLIST.Monster_ButterflyDance:
                    return Monster_ButterflyDance(actor, target);
                case SKILLLIST.Monster_Tentarafoo122:
                    return Monster_Tentarafoo122(actor, target);
                case SKILLLIST.Monster_ThornCuffs122:
                    return Monster_ThornCuffs122();
                case SKILLLIST.Monster_ElecDance123:
                    return Monster_ElecDance123();
                case SKILLLIST.Monster_MindCharge:
                    return Monster_MindCharge(actor, target);
                case SKILLLIST.Monster_Diarahan124:
                    return Monster_Diarahan124();
                case SKILLLIST.Monster_LifeWall124:
                    return Monster_LifeWall124();
                case SKILLLIST.Monster_StabShower:
                    return Monster_StabShower();
                case SKILLLIST.Monster_Tarukaja125:
                    return Monster_Tarukaja125(actor, target);
                case SKILLLIST.Monster_Garula:
                    return Monster_Garula();
                case SKILLLIST.Monster_Magarula:
                    return Monster_Magarula();
                case SKILLLIST.Monster_WindCorrosion:
                    return Monster_WindCorrosion(actor, target);
                case SKILLLIST.Monster_MightySwing127:
                    return Monster_MightySwing127();
                case SKILLLIST.Monster_Rakunda127:
                    return Monster_Rakunda127(actor, target);
                case SKILLLIST.Monster_BroadShot:
                    return Monster_BroadShot();
                case SKILLLIST.Monster_PowerCharge128:
                    return Monster_PowerCharge128(actor, target);
                case SKILLLIST.Monster_FangSmash129:
                    return Monster_FangSmash129();
                case SKILLLIST.Monster_KidneySmash129:
                    return Monster_KidneySmash129();
                case SKILLLIST.Monster_Masukunda129:
                    return Monster_Masukunda129(actor, target);
                case SKILLLIST.Monster_Zionga:
                    return Monster_Zionga();
                case SKILLLIST.Monster_Mazionga130:
                    return Monster_Mazionga130();
                case SKILLLIST.Monster_ElecCorrosion:
                    return Monster_ElecCorrosion(actor, target);
                case SKILLLIST.Monster_AssaultShot131:
                    return Monster_AssaultShot131();
                case SKILLLIST.Monster_BestialRoar131:
                    return Monster_BestialRoar131(actor, target);
                case SKILLLIST.Monster_LifeWall132:
                    return Monster_LifeWall132();
                case SKILLLIST.Monster_Matarukaja:
                    return Monster_Matarukaja(actor, target);
                case SKILLLIST.Monster_Agilao:
                    return Monster_Agilao();
                case SKILLLIST.Monster_Maragion133:
                    return Monster_Maragion133();
                case SKILLLIST.Monster_FireCorrosion:
                    return Monster_FireCorrosion(actor, target);
                case SKILLLIST.Monster_HardSlash134:
                    return Monster_HardSlash134();
                case SKILLLIST.Monster_HeatWave:
                    return Monster_HeatWave();
                case SKILLLIST.Monster_Marakunda:
                    return Monster_Marakunda(actor, target);
                case SKILLLIST.Monster_SilentSong135:
                    return Monster_SilentSong135(actor, target);
                case SKILLLIST.Monster_MuscleDown:
                    return Monster_MuscleDown(actor, target);
                case SKILLLIST.Monster_Spiderweb135:
                    return Monster_Spiderweb135(actor, target);
                case SKILLLIST.Monster_Tousatsujin:
                    return Monster_Tousatsujin();
                case SKILLLIST.Monster_ScorchingBlast:
                    return Monster_ScorchingBlast();
                case SKILLLIST.Monster_Masukunda136:
                    return Monster_Masukunda136(actor, target);
                case SKILLLIST.Monster_Bufula:
                    return Monster_Bufula();
                case SKILLLIST.Monster_Mabufula137:
                    return Monster_Mabufula137();
                case SKILLLIST.Monster_IceCorrosion:
                    return Monster_IceCorrosion(actor, target);
                case SKILLLIST.Monster_Maragi201:
                    return Monster_Maragi201();
                case SKILLLIST.Monster_ThornChains201:
                    return Monster_ThornChains201();
                case SKILLLIST.Monster_EvilSmile:
                    return Monster_EvilSmile(actor, target);
                case SKILLLIST.Monster_Diarahan202:
                    return Monster_Diarahan202(actor, target);
                case SKILLLIST.Monster_Megido:
                    return Monster_Megido();
                case SKILLLIST.Monster_BestialRoar203:
                    return Monster_BestialRoar203(actor, target);
                case SKILLLIST.Monster_Rakunda203:
                    return Monster_Rakunda203(actor, target);
                case SKILLLIST.Monster_MightySwing301:
                    return Monster_MightySwing301();
                case SKILLLIST.Monster_AssaultShot301:
                    return Monster_AssaultShot301();
                case SKILLLIST.Monster_PoisonBreath301:
                    return Monster_PoisonBreath301(actor, target);
                case SKILLLIST.Monster_LightningSmash:
                    return Monster_LightningSmash();
                case SKILLLIST.Monster_Mazio:
                    return Monster_Mazio();
                case SKILLLIST.Monster_BindingCry302:
                    return Monster_BindingCry302(actor, target);
                case SKILLLIST.Monster_MowDown303:
                    return Monster_MowDown303();
                case SKILLLIST.Monster_Mabufu303:
                    return Monster_Mabufu303();
                case SKILLLIST.Monster_Tentarafoo303:
                    return Monster_Tentarafoo303(actor, target);
                case SKILLLIST.Monster_GiganticFist:
                    return Monster_GiganticFist();
                case SKILLLIST.Monster_BestialRoar304:
                    return Monster_BestialRoar304(actor, target);
                case SKILLLIST.Monster_SilentSong304:
                    return Monster_SilentSong304(actor, target);
                case SKILLLIST.Monster_AssaultShot305:
                    return Monster_AssaultShot305();
                case SKILLLIST.Monster_Maragi305:
                    return Monster_Maragi305();
                case SKILLLIST.Monster_Tarukaja305:
                    return Monster_Tarukaja305(actor, target);
                case SKILLLIST.Monster_Maragion306:
                    return Monster_Maragion306();
                case SKILLLIST.Monster_Mazionga306:
                    return Monster_Mazionga306();
                case SKILLLIST.Monster_Mabufula306:
                    return Monster_Mabufula306();
                case SKILLLIST.Monster_MowDown401:
                    return Monster_MowDown401();
                case SKILLLIST.Monster_FireDance401:
                    return Monster_FireDance401();
                case SKILLLIST.Monster_IceDance401:
                    return Monster_IceDance401();
                case SKILLLIST.Monster_Vow:
                    return Monster_Vow();
                case SKILLLIST.Monster_HolyWrath:
                    return Monster_HolyWrath();
                case SKILLLIST.Monster_HardSlash402:
                    return Monster_HardSlash402();
                default:
                    return 0;
            }
        }
        public int SkillVitality(int skillnumber, GameObject actor)
        {
            switch ((SKILLLIST)skillnumber)
            {
                case SKILLLIST.SwordMan_PhysicalAttackBoost:
                    return SwordMan_PhysicalAttackBoost(actor);
                case SKILLLIST.SwordMan_DoubleAttack:
                    return SwordMan_DoubleAttack(actor);
                case SKILLLIST.SwordMan_PhysicalDefenseBoost:
                    return SwordMan_PhysicalDefenseBoost(actor);
                case SKILLLIST.SwordMan_HPBoost:
                    return SwordMan_HPBoost(actor);
                case SKILLLIST.SwordMan_TPBoost:
                    return SwordMan_TPBoost(actor);
                case SKILLLIST.SwordMan_SwordMastery:
                    return SwordMan_SwordMastery(actor);
                case SKILLLIST.SwordMan_AxeMastery:
                    return SwordMan_AxeMastery(actor);
                case SKILLLIST.SwordMan_WarCry:
                    return SwordMan_WarCry(actor);
                
                case SKILLLIST.Dragoon_ShieldMastery:
                    return Dragoon_ShieldMastery(actor);
                case SKILLLIST.Dragoon_HeavyWeaponMastery:
                    return Dragoon_HeavyWeaponMastery(actor);
                case SKILLLIST.Dragoon_HPBoost:
                    return Dragoon_HPBoost(actor);
                case SKILLLIST.Dragoon_DefenseFormation:
                    return Dragoon_DefenseFormation(actor);
                case SKILLLIST.Dragoon_DragonRoar:
                    return Dragoon_DragonRoar(actor);
                case SKILLLIST.Dragoon_DragonsProtection:
                    return Dragoon_DragonsProtection(actor);
                case SKILLLIST.Warrock_MagicDefenseBoost:
                    return Warrock_MagicDefenseBoost(actor);
                case SKILLLIST.Warrock_TPBoost:
                    return Warrock_TPBoost(actor);
                case SKILLLIST.Warrock_MagicMastery:
                    return Warrock_MagicMastery(actor);
                case SKILLLIST.Warrock_HighSpeedCasting:
                    return Warrock_HighSpeedCasting(actor);
                case SKILLLIST.Warrock_AmpRewh:
                    return Warrock_AmpRewh(actor);
                case SKILLLIST.Warrock_MagicShield:
                    return Warrock_MagicShield(actor);
                case SKILLLIST.Warrock_AntiMagic:
                    return Warrock_AntiMagic(actor);
                case SKILLLIST.Warrock_LifeDrain:
                    return Warrock_LifeDrain(actor);
                case SKILLLIST.Warrock_CompressSpell:
                    return Warrock_CompressSpell(actor);
                case SKILLLIST.Warrock_MultipleSpell:
                    return Warrock_MultipleSpell(actor);
                case SKILLLIST.Medic_StaffMastery:
                    return Medic_StaffMastery(actor);
                case SKILLLIST.Medic_MagicDefenceBoost:
                    return Medic_MagicDefenceBoost(actor);
                case SKILLLIST.Medic_OverHeal:
                    return Medic_OverHeal(actor);
                case SKILLLIST.Medic_AntiBody:
                    return Medic_AntiBody(actor);
                case SKILLLIST.Bard_PhysicalDefenseBoost:
                    return Bard_PhysicalDefenseBoost(actor);
                case SKILLLIST.Bard_HPBoost:
                    return Bard_HPBoost(actor);
                case SKILLLIST.Bard_TPBoost:
                    return Bard_TPBoost(actor);
                case SKILLLIST.Bard_SongMastery:
                    return Bard_SongMastery(actor);
                case SKILLLIST.Bard_ViolentBattleSong:
                    return Bard_ViolentBattleSong(actor);
                case SKILLLIST.Bard_HolyProtectionSong:
                    return Bard_HolyProtectionSong(actor);
                case SKILLLIST.Bard_MelodyOfWiseEye:
                    return Bard_MelodyOfWiseEye(actor);
                case SKILLLIST.Bard_MelodyOfAgriculture:
                    return Bard_MelodyOfAgriculture(actor);
                case SKILLLIST.Bard_DuetOfScanda:
                    return Bard_DuetOfScanda(actor);
                case SKILLLIST.Bard_SavagesMarch:
                    return Bard_SavagesMarch(actor);
                case SKILLLIST.Bard_RequiemOfNesa:
                    return Bard_RequiemOfNesa(actor);
                case SKILLLIST.Monster_Tarukaja104:
                    return Monster_Tarukaja104(actor);
                case SKILLLIST.Monster_LullabySong:
                    return Monster_LullabySong(actor);
                case SKILLLIST.Monster_BestialRoar108:
                    return Monster_BestialRoar108(actor);
                case SKILLLIST.Monster_Rakunda109:
                    return Monster_Rakunda109(actor);
                case SKILLLIST.Monster_BindingCry112:
                    return Monster_BindingCry112(actor);
                case SKILLLIST.Monster_Tarukaja114:
                    return Monster_Tarukaja114(actor);
                case SKILLLIST.Monster_SpiderWeb117:
                    return Monster_SpiderWeb117(actor);
                case SKILLLIST.Monster_Stona:
                    return Monster_Stona(actor);
                case SKILLLIST.Monster_PowerCharge120:
                    return Monster_PowerCharge120(actor);
                case SKILLLIST.Monster_PoisonBreath121:
                    return Monster_PoisonBreath121(actor);
                case SKILLLIST.Monster_ButterflyDance:
                    return Monster_ButterflyDance(actor);
                case SKILLLIST.Monster_Tentarafoo122:
                    return Monster_Tentarafoo122(actor);
                case SKILLLIST.Monster_MindCharge:
                    return Monster_MindCharge(actor);
                case SKILLLIST.Monster_Tarukaja125:
                    return Monster_Tarukaja125(actor);
                case SKILLLIST.Monster_WindCorrosion:
                    return Monster_WindCorrosion(actor);
                case SKILLLIST.Monster_Rakunda127:
                    return Monster_Rakunda127(actor);
                case SKILLLIST.Monster_PowerCharge128:
                    return Monster_PowerCharge128(actor);
                case SKILLLIST.Monster_Masukunda129:
                    return Monster_Masukunda129(actor);
                case SKILLLIST.Monster_ElecCorrosion:
                    return Monster_ElecCorrosion(actor);
                case SKILLLIST.Monster_BestialRoar131:
                    return Monster_BestialRoar131(actor);
                case SKILLLIST.Monster_Matarukaja:
                    return Monster_Matarukaja(actor);
                case SKILLLIST.Monster_FireCorrosion:
                    return Monster_FireCorrosion(actor);
                case SKILLLIST.Monster_Marakunda:
                    return Monster_Marakunda(actor);
                case SKILLLIST.Monster_SilentSong135:
                    return Monster_SilentSong135(actor);
                case SKILLLIST.Monster_MuscleDown:
                    return Monster_MuscleDown(actor);
                case SKILLLIST.Monster_Spiderweb135:
                    return Monster_Spiderweb135(actor);
                case SKILLLIST.Monster_Masukunda136:
                    return Monster_Masukunda136(actor);
                case SKILLLIST.Monster_IceCorrosion:
                    return Monster_IceCorrosion(actor);
                case SKILLLIST.Monster_Diarahan202:
                    return Monster_Diarahan202(actor);
                case SKILLLIST.Monster_EvilSmile:
                    return Monster_EvilSmile(actor);
                case SKILLLIST.Monster_Rakunda203:
                    return Monster_Rakunda203(actor);
                case SKILLLIST.Monster_BestialRoar203:
                    return Monster_BestialRoar203(actor);
                case SKILLLIST.Monster_PoisonBreath301:
                    return Monster_PoisonBreath301(actor);
                case SKILLLIST.Monster_BindingCry302:
                    return Monster_BindingCry302(actor);
                case SKILLLIST.Monster_Tentarafoo303:
                    return Monster_Tentarafoo303(actor);
                case SKILLLIST.Monster_SilentSong304:
                    return Monster_SilentSong304(actor);
                case SKILLLIST.Monster_BestialRoar304:
                    return Monster_BestialRoar304(actor);
                case SKILLLIST.Monster_Tarukaja305:
                    return Monster_Tarukaja305(actor);
                default:
                    return 0;
            }
        }
    }
}
