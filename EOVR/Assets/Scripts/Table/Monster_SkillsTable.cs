using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonData;

[System.Serializable]
public class Monster_SkillsRecord
{
    public int nID;                      // 스킬 ID
    public string MonSkillName;          // 스킬명
    public int UseMonsterID;             // 스킬을 쓰는 몬스터ID
    public MSkillData.DMGTYPE  DmgType;  // 데미지 타입
    public MSkillData.PATKTYPE PatkType; // 물리계열타입
    public MSkillData.MATKTYPE MatkType; // 속성(마법)계열타입
    public MSkillData.ALLIES Allies;     // 아군 적군 구분
    public MSkillData.AREATYPE AreaType; // 스킬 적용 범위
    public MSkillData.RANGE Range;       // 스킬 적용 사거리
    public int Duration;                 // 디버프시 적에게 줄 효과의 지속시간
    public float SkillPercent;           // 스킬 배율
    public float EffectPercent;          // 디버프 효과 배율
    public int Speed;                    // 스킬 발동 속도
    public string Explain;               // 스킬 설명
    
    public Monster_SkillsRecord(Dictionary<string, string> _data)
    {
        nID = FileUtil.Get<int>(_data, "nID");
        MonSkillName = FileUtil.Get<string>(_data, "Name");
        UseMonsterID = FileUtil.Get<int>(_data, "UseMonsterID");
        DmgType = FileUtil.Get<MSkillData.DMGTYPE>(_data, "DmgType");
        PatkType = FileUtil.Get<MSkillData.PATKTYPE>(_data, "PatkType");
        MatkType = FileUtil.Get<MSkillData.MATKTYPE>(_data, "MatkType");
        Allies = FileUtil.Get<MSkillData.ALLIES>(_data, "Allies");
        AreaType = FileUtil.Get<MSkillData.AREATYPE>(_data, "AreaType");
        Duration = FileUtil.Get<int>(_data, "Duration");
        Range = FileUtil.Get<MSkillData.RANGE>(_data, "Range");
        SkillPercent = FileUtil.Get<float>(_data, "SkillPercent");
        EffectPercent = FileUtil.Get<float>(_data, "EffectPercent");
        Speed = FileUtil.Get<int>(_data, "Speed");
        Explain = FileUtil.Get<string>(_data, "Explain");
    }
}

public class Monster_SkillsTable
{
    private List<Monster_SkillsRecord> m_recordList = new List<Monster_SkillsRecord>();

    public Monster_SkillsTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<Monster_SkillsRecord>>(FileUtil.GetResPath(_filename));
    }

    public Monster_SkillsTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            Monster_SkillsRecord _record = new Monster_SkillsRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<Monster_SkillsRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public Monster_SkillsRecord GetRecord(int _index)
    {
        Monster_SkillsRecord _find = m_recordList.Find(delegate (Monster_SkillsRecord _record)
        {
            return _record.nID == _index;
        });

        if (null == _find)
        {
            Debug.LogError("MonsterTable::GetRecord()[ null == Monster_SkillsRecord]");
            return null;
        }

        return _find;
    }
}

