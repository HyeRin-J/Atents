using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;
using MonData;
using Skill;

public class SkillManager : MonoBehaviour {

    static SkillManager _instance;

    public static SkillManager instance
    {
        get { return _instance; }
    }

    // Use this for initialization
    //kij Start 보다는 Awake()가 좋지 않을까요?

    public void SetInstance()
    {
        _instance = PartyManager._instance.GetComponent<SkillManager>();
    }

    public float GetSkillPercent(int skillID, int skillLevel)
    {
        Character_SkillPercentRecord percentRecord = TableMgr.Instance.character_SkillPercentTable.GetRecord(skillID);
        switch (skillLevel)
        {
            case 1:
                return percentRecord.Percent1;
            case 2:
                return percentRecord.Percent2;
            case 3:
                return percentRecord.Percent3;
            case 4:
                return percentRecord.Percent4;
            case 5:
                return percentRecord.Percent5;
            default:
                return 1;
        }
    }
    public float GetSkillAdditionalEffectPercent(int skillID, int skillLevel)
    {
        Character_SkillAdditionalEffectRecord Record = TableMgr.Instance.character_SkillAdditionalEffectTable.GetRecord(skillID);
        switch (skillLevel)
        {
            case 1:
                return Record.Lv1Percent2;
            case 2:
                return Record.Lv2Percent2;
            case 3:
                return Record.Lv3Percent2;
            case 4:
                return Record.Lv4Percent2;
            case 5:
                return Record.Lv5Percent2;
            default:
                return 1;
        }
    }

    public SkillData.TYPE GetSkillType(int skillID)
    {
        SkillData.TYPE percentRecord = TableMgr.Instance.character_SkillsTable.GetRecord(skillID).Type;
        return percentRecord;
    }

    public int GetSkillDuration(int skillID, int skillLevel)
    {
        Character_SkillPercentRecord percentRecord = TableMgr.Instance.character_SkillPercentTable.GetRecord(skillID);
        switch (skillLevel)
        {
            case 1:
                return percentRecord.Lv1Duration;
            case 2:
                return percentRecord.Lv2Duration;
            case 3:
                return percentRecord.Lv3Duration;
            case 4:
                return percentRecord.Lv4Duration;
            case 5:
                return percentRecord.Lv5Duration;
            default:
                return 1;
        }
    }
    public int GetSkillAdditionalEffectDuration(int skillID, int skillLevel)
    {
        Character_SkillAdditionalEffectRecord Record = TableMgr.Instance.character_SkillAdditionalEffectTable.GetRecord(skillID);
        switch (skillLevel)
        {
            case 1:
                return Record.Lv1Duration2;
            case 2:
                return Record.Lv2Duration2;
            case 3:
                return Record.Lv3Duration2;
            case 4:
                return Record.Lv4Duration2;
            case 5:
                return Record.Lv5Duration2;
            default:
                return 1;
        }
    }


    public void SetSkillList(int skillID, ref Dictionary<int, Character_SkillsRecord> skillList)
    {
        Character_SkillsRecord skillRecord = TableMgr.Instance.character_SkillsTable.GetRecord(skillID);
        skillList.Add(skillID, skillRecord);
    }
    public int[] GetPatkType(int skillnumber,int[] attackType)
    {
        switch (TableMgr.Instance.character_SkillsTable.GetRecord(skillnumber).PatkType)
        {           
            case SkillData.PATKTYPE.Cut:
                attackType[0] = 1;
                break;
            case SkillData.PATKTYPE.Bash:
                attackType[1] = 1;
                break;
            case SkillData.PATKTYPE.Melee:
                attackType[2] = 1;
                break;           
        }
        return attackType;
    }
    public int[] GetMatkType(int skillnumber,int[] attackType)
    {
        switch (TableMgr.Instance.character_SkillsTable.GetRecord(skillnumber).MatkType)
        {
            case SkillData.MATKTYPE.Fire:
                attackType[3] = 1;
                break;
            case SkillData.MATKTYPE.Ice:
                attackType[4] = 1;
                break;
            case SkillData.MATKTYPE.Lightening:
                attackType[5] = 1;
                break;           
            case SkillData.MATKTYPE.All:
                attackType[3] = 1;
                attackType[4] = 1;
                attackType[5] = 1;
                break;          
        }
        return attackType;
    }

    //몬스터 스킬부분
    public float GetMonsterSkillPercent(int mSkillID)
    {   //몬스터 스킬퍼센트 세팅
        Monster_SkillsRecord monPercentRecord = TableMgr.Instance.monster_SkillsTable.GetRecord(mSkillID);
        return monPercentRecord.SkillPercent;
    }
    
    public int GetMonsterSkillDuration(int mSkillID)
    {   //몬스터 효과 지속시간 = 1개라 바로반환
        Monster_SkillsRecord monPercentRecord = TableMgr.Instance.monster_SkillsTable.GetRecord(mSkillID);
        return monPercentRecord.Duration;
    }

    public void SetMonsterSkillList(int skillID, ref Dictionary<int, Monster_SkillsRecord> mSkillList)
    {   //몬스터 스킬리스트 세팅
        Monster_SkillsRecord skillRecord = TableMgr.Instance.monster_SkillsTable.GetRecord(skillID);
        mSkillList.Add(skillID, skillRecord);
    }
    public int[] GetMonsterPatkType(int skillnumber, int[] attackType)
    {
        switch (TableMgr.Instance.monster_SkillsTable.GetRecord(skillnumber).PatkType)
        {
            case MSkillData.PATKTYPE.Cut:
                attackType[0] = 1;
                break;
            case MSkillData.PATKTYPE.Bash:
                attackType[1] = 1;
                break;
            case MSkillData.PATKTYPE.Melee:
                attackType[2] = 1;
                break;
        }
        return attackType;
    }

    public int[] GetMonsterMatkType(int skillnumber, int[] attackType)
    {
        switch (TableMgr.Instance.monster_SkillsTable.GetRecord(skillnumber).MatkType)
        {
            case MSkillData.MATKTYPE.Fire:
                attackType[3] = 1;
                break;
            case MSkillData.MATKTYPE.Ice:
                attackType[4] = 1;
                break;
            case MSkillData.MATKTYPE.Lightening:
                attackType[5] = 1;
                break;
            case MSkillData.MATKTYPE.All:
                attackType[3] = 1;
                attackType[4] = 1;
                attackType[5] = 1;
                break;
        }
        return attackType;
    }

    public void CheckSkillTree(int skillNumber, int skillLevel)
    {

    }

    private void OpenSkill(int skillNumber)
    {

    }

    public int GetSkill(int skillNumber,GameObject actor,GameObject[] target)
    {
        SkillImplementation si = GetComponent<SkillImplementation>(); //kij MonoBehaviour를 상속받지 않아도 GetComponent를 사용해서 가지고 올수 있나요?
        Debug.Log(si.gameObject);
        return si.SkillVitality(skillNumber, actor, target);
    }
    public int GetSkill(int skillNumber, GameObject actor)
    {
        SkillImplementation si = gameObject.GetComponent<SkillImplementation>(); //kij MonoBehaviour를 상속받지 않아도 GetComponent를 사용해서 가지고 올수 있나요?
        return si.SkillVitality(skillNumber, actor);
    }
    

}
