using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;
using Skill;
public class PlayerCharacter : CharacterObject
{
    #region SkillActiveCheck
    [HideInInspector]
    public bool isDivideGuard = false;
    [HideInInspector]
    public BattlePlayer divideTarget;
    [HideInInspector]
    public bool isSoulGuard = false;
    [HideInInspector]
    public float SoulGuardActivePercent;
    [HideInInspector]
    public bool isDragonProtection = false;
    [HideInInspector]
    public float DragonProtectionActivePercent;
    [HideInInspector]
    public bool isCountGuard = false;
    [HideInInspector]
    public PlayerCharacter countAttacker;
    [HideInInspector]
    public float CountDamagePercent;
    [HideInInspector]
    public bool isChaseHeal = false;
    [HideInInspector]
    
    #endregion

    public CharacterData.CHARACTERCLASS characterClass;
    public int classType;
    public int level;               //현제 레벨
    public int nextLevelNeedExp;    //다음레벨까지 필요한 총 경험치
    public int CurrentExp;              //현제 경험치량
    public int currentHp;
    public int currentTp;               //현제 Tp
    public int chargeDuration;          //차지 스킬 사용시 사용될 변수

    #region 스킬증감변수
    public float increasePhysicalAttackbySkill = 0.0f;
    public float increasePhysicalAttackbyBuff = 0.0f;
    public float increaseMagicAttackbySkill = 0.0f;
    public float increaseMagicAttackbyBuff = 0.0f;
    public float independentIncreaseRate = 1.0f;
    public float increasePhysicalDefensebySkill = 0.0f;
    public float increasePhysicalDefensebyBuff = 0.0f;
    public float increaseMagicDefensebySkill = 0.0f;
    public float increaseMagicDefensebyBuff = 0.0f;
    #endregion

    public SkillData.PassiveSkill passiveSkill;
    public SkillData.PassiveSkill chargeSkill;


    private int maxSkillPoint;       //현제 보유한 스킬 포인트의 총합
    private int skillPoint = 40;          //보유한 스킬 포인트(임시로 스킬포인트 여유분 추가)


    private float decreseRate = 1.0f;
    private float independentFrame = 1.0f;

    CharacterData.PLUSPROPERTY weaponProperty;
    CharacterData.PLUSPROPERTY armorProperty;
    CharacterData.PLUSPROPERTY subArmorProperty;
    CharacterData.PLUSPROPERTY accessoryProperty;


    CharacterData.Stats baseStats;
    CharacterData.Stats plusStats;
    CharacterData.Stats totalStats;

    #region equipmentNumber
    public int weapon = 0;
    public int armor = 0;
    public int subArmor = 0;
    public int accessory = 0;
    #endregion
    //파티 포지션
    public int partyPosition;
    //현제 파티 등록 여부
    public bool isParty = false;
    public bool isBattle = false;
    public bool isDown = false;

    private Dictionary<int, int> learnSkillData = new Dictionary<int, int>();
    private Dictionary<int, Character_SkillsRecord> learnSkillList = new Dictionary<int, Character_SkillsRecord>();

    public void LevelUp()
    {
        level++;
        StatsRearrange(level);
    }
    private void StatsRearrange(int level)
    {
        maxSkillPoint = 2 + level;
        skillPoint++;
        CurrentExp = 0;
        nextLevelNeedExp = PartyManager._instance.GetNeedExp(level);
        if (level != 1)
        {
            physicalAtk -= totalStats.STR;
            magicAtk -= totalStats.INT;
            physicalDef -= totalStats.VIT;
            magicDef -= totalStats.WIS;
        }
        PartyManager._instance.GetLevelUpStat(gameObject, characterClass, level);
        RefreshTotalProperty();
        physicalAtk += totalStats.STR;
        magicAtk += totalStats.INT;
        physicalDef += totalStats.VIT;
        magicDef += totalStats.WIS;
    }

    #region EquipMent
    private int ChangeWeapon(int weaponNumber)
    {
        if (PartyManager._instance.CheckAbleEquipment(characterClass, weaponNumber) == false)
            return weapon;

        int preEquipmentNumber;
        if (weapon != 0)
        {
            SetPlusProperty(weaponProperty, false);
            physicalAtk -= weaponProperty.pStats;
            magicAtk -= weaponProperty.mStats;
            PartyManager._instance.DumpedItem(weapon);
        }
        preEquipmentNumber = weapon;
        weapon = weaponNumber;
        weaponProperty = PartyManager._instance.GetEquipProperty(weapon, ITEMCATEGORY.WEAPON);
        SetPlusProperty(weaponProperty, true);
        physicalAtk += weaponProperty.pStats;
        magicAtk += weaponProperty.mStats;
        RefreshTotalProperty();
        return preEquipmentNumber;
    }

    private int ChangeArmor(int armorNumber)
    {
        if (PartyManager._instance.CheckAbleEquipment(characterClass, armorNumber) == false)
            return armor;
        int preEquipmentNumber = 0;
        if (armor != 0)
        {
            SetPlusProperty(armorProperty, false);
            physicalDef -= armorProperty.pStats;
            magicDef -= armorProperty.mStats;
        }
        preEquipmentNumber = armor;
        armor = armorNumber;
        armorProperty = PartyManager._instance.GetEquipProperty(armor, ITEMCATEGORY.ARMOR);
        SetPlusProperty(armorProperty, true);
        physicalDef += armorProperty.pStats;
        magicDef += armorProperty.mStats;
        RefreshTotalProperty();
        return preEquipmentNumber;
    }

    private int ChangeSubArmor(int subArmorNumber)
    {
        int preEquipmentNumber = 0;
        if (subArmor != 0)
        {
            SetPlusProperty(subArmorProperty, false);
            physicalDef -= subArmorProperty.pStats;
            magicAtk -= subArmorProperty.mStats;
        }

        preEquipmentNumber = this.subArmor;
        this.subArmor = subArmorNumber;
        subArmorProperty = PartyManager._instance.GetEquipProperty(subArmor, ITEMCATEGORY.ARMOR);
        SetPlusProperty(subArmorProperty, true);
        physicalDef += subArmorProperty.pStats;
        magicAtk += subArmorProperty.mStats;
        RefreshTotalProperty();
        return preEquipmentNumber;
    }

    private int ChangeAccessory(int AccessoryNumber)
    {
        int preEquipmentNumber = 0;
        if (accessory != 0)
        {
            SetPlusProperty(accessoryProperty, false);
            preEquipmentNumber = accessory;
            accessory = AccessoryNumber;
        }
        accessoryProperty = PartyManager._instance.GetEquipProperty(accessory, ITEMCATEGORY.ACCESSORY);
        SetPlusProperty(accessoryProperty, true);
        RefreshTotalProperty();
        return preEquipmentNumber;
    }
    public void RefreshTotalProperty()
    {
        totalStats.MAXHP = baseStats.MAXHP + plusStats.MAXHP;
        totalStats.MAXTP = baseStats.MAXTP + plusStats.MAXTP;
        totalStats.STR = baseStats.STR + plusStats.STR;
        totalStats.INT = baseStats.INT + plusStats.INT;
        totalStats.VIT = baseStats.VIT + plusStats.VIT;
        totalStats.WIS = baseStats.WIS + plusStats.WIS;
        totalStats.AGI = baseStats.AGI + plusStats.AGI;
        totalStats.LUK = baseStats.LUK + plusStats.LUK;
    }
    private void ChangeAttackByStats(bool flag)
    {
        int intFlag = flag ? 1 : -1;
        physicalAtk += (totalStats.STR * intFlag);
        magicAtk += (totalStats.INT * intFlag);
    }
    private void ChangeDefenseByStats(bool flag)
    {
        int intFlag = flag ? 1 : -1;
        physicalDef += (totalStats.VIT * intFlag);
        magicDef += (totalStats.WIS * intFlag);
    }




    #endregion
    #region Battle(보류)
    public int Attack()
    {
        return (int)(physicalAtk + (physicalAtk * (increasePhysicalAttackbySkill + increasePhysicalAttackbyBuff)));
    }

    public void Defense()
    {
        increaseMagicDefensebyBuff += 0.5f;
        increasePhysicalDefensebyBuff += 0.5f;
}

    public int Damaged(int damage, SkillData.DMGTYPE damageType)
    {
        int truedamage;
        if (damageType == SkillData.DMGTYPE.Magical)
            truedamage = (int)(damage * (1-(increaseMagicDefensebyBuff+increaseMagicDefensebySkill))) ;
        else
            truedamage = (int)(damage * (1 - (increasePhysicalDefensebyBuff + increasePhysicalDefensebySkill)));
        if (truedamage < 0) truedamage = 0;
        if (isDivideGuard == true)   //디바이드 가드,풀 가드 적용시
        {           
            divideTarget.damage += truedamage;
            truedamage = 0;
        }
        if(isDragonProtection == true)//용의 보호적용시
        {
            if (Random.Range(0, 1) < DragonProtectionActivePercent)
                truedamage = 0;
        }
        if(isCountGuard == true)//카운터 가드 적용시
        {
            BattleMonster target = GameObject.Find("BattleManager").GetComponent<BattleManager>().latelyAttackMonster.GetComponent<BattleMonster>();
            SkillImplementation si = new SkillImplementation();
            int[] attackType = { 0, 0, 1, 0, 0, 0 };
            int countdamage = si.GetCommonDamage(countAttacker, attackType, CountDamagePercent, target, ATTACKTYPE.PHYSICAL);
            target.monDamageAmount = countdamage;
        }
        return truedamage;
    }
    private void DecreaseHp(int trueDamage)
    {
        currentHp -= trueDamage;
        if (currentHp < 0)
        {
            currentHp = 0;
            KnockDown();
        }
    }
    public bool KnockDown()
    {
        if (isSoulGuard == true)
        {
            if (Random.Range(0.0f, 1.0f) < SoulGuardActivePercent)
                return false;
        }
        return true;
    }
    #endregion
    #region Set
    public void SetLevelUpStat(int MaxHP, int MaxTP, int Str, int Int, int Vit, int Wis, int Agi, int Luk)
    {
        currentHp += (MaxHP - baseStats.MAXHP);
        currentTp += (MaxTP - baseStats.MAXTP);
        baseStats.MAXHP = MaxHP;
        baseStats.MAXTP = MaxTP;
        baseStats.STR = Str;
        baseStats.INT = Int;
        baseStats.VIT = Vit;
        baseStats.WIS = Wis;
        baseStats.AGI = Agi;
        baseStats.LUK = Luk;
    }
    public void SetLearnSkill(int skillNumber)
    {
        if (skillPoint > 0)
        {
            skillPoint--;
            if (learnSkillData.ContainsKey(skillNumber))
            {
                learnSkillData[skillNumber]++;
            }
            else
            {
                learnSkillData.Add(skillNumber, 1);
                SkillManager.instance.SetSkillList(skillNumber, ref learnSkillList);
            }
            if(SkillManager.instance.GetSkillType(skillNumber) == SkillData.TYPE.Passive)
            {
                UseSkill(skillNumber, gameObject);
            }
        }
    }
    public void ChangeEquipment(int equipmentNumber, CharacterData.EQUIPMENTTYPE type)
    {
        int preEquipmentNumber = 0;
        PartyManager._instance.DumpedItem(equipmentNumber);
        switch (type)
        {
            case CharacterData.EQUIPMENTTYPE.WEAPON:
                preEquipmentNumber = ChangeWeapon(equipmentNumber);
                break;
            case CharacterData.EQUIPMENTTYPE.ARMOR:
                preEquipmentNumber = ChangeArmor(equipmentNumber);
                break;
            case CharacterData.EQUIPMENTTYPE.ACCESSORY:
                preEquipmentNumber = ChangeAccessory(equipmentNumber);
                break;
            case CharacterData.EQUIPMENTTYPE.SUBARMOR:
                preEquipmentNumber = ChangeSubArmor(equipmentNumber);
                break;
            default:
                preEquipmentNumber = 0;
                Debug.Log("ChangeEquipment Error");
                break;
        }
        PartyManager._instance.SetInventoryItem(preEquipmentNumber);
    }
    public void SetPartyJoin()
    {
        isParty = !isParty;
    }
    public void SetTotalStats(CharacterData.Stats stats)
    {
        totalStats.MAXHP += stats.MAXHP;
        totalStats.MAXTP += stats.MAXTP;
    }
    private void SetPlusProperty(CharacterData.PLUSPROPERTY property, bool isPlusMinus)
    {
        int plusMinus;
        if (property.plusProperty1 == PlusProperty.None) return;
        plusMinus = isPlusMinus ? 1 : -1;
        switch (property.plusProperty1)
        {
            case PlusProperty.HP:
                plusStats.MAXHP += property.plusValue1 * plusMinus;
                break;
            case PlusProperty.WIS:
                plusStats.WIS += property.plusValue1 * plusMinus;
                magicDef += property.plusValue1 * plusMinus;
                break;
            case PlusProperty.TP:
                plusStats.MAXTP += property.plusValue1 * plusMinus;
                break;
            case PlusProperty.AGI:
                plusStats.AGI += property.plusValue1 * plusMinus;
                break;
            case PlusProperty.LUC:
                plusStats.LUK += property.plusValue1 * plusMinus;
                break;
            case PlusProperty.STR:
                plusStats.STR += property.plusValue1 * plusMinus;
                physicalAtk += property.plusValue1 * plusMinus;
                break;
            case PlusProperty.VIT:
                plusStats.VIT += property.plusValue1 * plusMinus;
                physicalDef += property.plusValue1 * plusMinus;
                break;
            case PlusProperty.INT:
                plusStats.INT += property.plusValue1 * plusMinus;
                magicAtk += property.plusValue1 * plusMinus;
                break;
            default:
                break;
        }
        switch (property.plusProperty2)
        {

            case PlusProperty.HP:
                plusStats.MAXHP += property.plusValue2 * plusMinus;
                break;
            case PlusProperty.WIS:
                plusStats.WIS += property.plusValue2 * plusMinus;
                magicDef += property.plusValue2 * plusMinus;
                break;
            case PlusProperty.TP:
                plusStats.MAXTP += property.plusValue2 * plusMinus;
                break;
            case PlusProperty.AGI:
                plusStats.AGI += property.plusValue2 * plusMinus;
                break;
            case PlusProperty.LUC:
                plusStats.LUK += property.plusValue2 * plusMinus;
                break;
            case PlusProperty.STR:
                plusStats.STR += property.plusValue2 * plusMinus;
                physicalAtk += property.plusValue2 * plusMinus;
                break;
            case PlusProperty.VIT:
                plusStats.VIT += property.plusValue2 * plusMinus;
                physicalDef += property.plusValue2 * plusMinus;
                break;
            case PlusProperty.INT:
                plusStats.INT += property.plusValue2 * plusMinus;
                magicAtk += property.plusValue2 * plusMinus;
                break;
            default:
                break;
        }
    }
    public void SetExp(int exp)
    {
        CurrentExp += exp;
        isBattle = false;
        RefreshTotalProperty();
        while (nextLevelNeedExp < CurrentExp)
        {
            CurrentExp = CurrentExp - nextLevelNeedExp;
            LevelUp();
        }
    }
    #endregion
    #region Get
    public Dictionary<int, int> GetSkillData()
    {
        return learnSkillData;
    }
    public int GetSkillLevel(int skillNumber)
    {
        return learnSkillData[skillNumber];
    }
    public Dictionary<int, Character_SkillsRecord> GetSkillList()
    {
        return learnSkillList;
    }

    public CharacterData.Stats GetBaseStats()
    {
        return baseStats;
    }

    public CharacterData.Stats GetCharacterStats()
    {
        return totalStats;
    }
    #endregion
    #region Use
    public void UseItem(GameObject[] target, int itemID)
    {
        if (isBattle)
        {

        }
        else
        {
            for (int i = 0; i < target.Length; i++)
            {
                PlayerCharacter targetPC = target[i].GetComponent<PlayerCharacter>();
                ConItemRecord record = PartyManager._instance.GetItemRecord(itemID);
                if (record.cType == ITEMCATEGORY.Revive)
                    targetPC.isDown = true;
                if (targetPC.isDown == false)
                {
                    if (record.cPlusProperty1 == PlusProperty.HP)
                        targetPC.currentHp += record.cPlusAmount1;
                    else
                        targetPC.currentTp += record.cPlusAmount1;
                    if (record.cPlusProperty2 == PlusProperty.TP)
                        targetPC.currentTp += record.cPlusAmount2;
                }
            }
            
        }
        HpTpLimitCheck();
    }
    private void HpTpLimitCheck()
    {
        if (currentHp > baseStats.MAXHP + plusStats.MAXHP)
            currentHp = baseStats.MAXHP + plusStats.MAXHP;
        if (currentHp > baseStats.MAXTP + plusStats.MAXTP)
            currentTp = baseStats.MAXTP + plusStats.MAXTP;
    }
    public int UseSkill(int skillID, GameObject actor, GameObject[] target)
    {
        return SkillManager.instance.GetSkill(skillID, actor, target);
    }
	public int UseSkill(int skillID, GameObject actor)
    {
        return SkillManager.instance.GetSkill(skillID, actor);
    }    
    #endregion
    public void HpRecovery(int heal)
    {
        currentHp += heal;
        HpTpLimitCheck();
    }

    void AddLevel( int _level )
    {
        SetLevel(level + _level);
    }
    void SetLevel( int _level )
    {
        level = _level;
        if (level < 0)
            level = 0;
    }
    public void Recuperate()
    {
        AddLevel(- 3);
        //level -= 3;
        LevelUp();
        skillPoint = maxSkillPoint;
        learnSkillList.Clear();
    }

    private void Start()
    {
        passiveSkill = (GameObject gameObject) =>
        {
            increasePhysicalAttackbySkill = 0.0f;
            increasePhysicalDefensebySkill = 0.0f;
            increaseMagicAttackbySkill = 0.0f;
            increaseMagicDefensebySkill = 0.0f;
            isBattle = true;
        };
    }
    public void ChargeSkillReset()              //chargeskill 델리게이트 초기화
    {
        chargeSkill = (GameObject gameobject) =>
        {

        };
    }
    public void BuffEffectReset()//버프 효과 리셋
    {
        increaseMagicAttackbyBuff = 0;
        increaseMagicDefensebyBuff = 0;
        increasePhysicalAttackbyBuff = 0;
        increasePhysicalDefensebyBuff = 0;
    }
}
