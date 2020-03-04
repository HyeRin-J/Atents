using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;

[System.Serializable]
public class Character_SkillsRecord
{
    

    public int nID;
    public string Name;
    public PlayerData.SkillData.NEEDS Needs;
    public PlayerData.SkillData.TYPE Type;
    public PlayerData.SkillData.DMGTYPE DmgType;
    public PlayerData.SkillData.PATKTYPE PatkType;
    public PlayerData.SkillData.MATKTYPE MatkType;
    public PlayerData.SkillData.ALLIES Allies;
    public PlayerData.SkillData.AREATYPE AreaType;
    public PlayerData.SkillData.RANGE Range;
    public int Speed;
    public string Explain;

    public Character_SkillsRecord(Dictionary<string, string> _data)
    {
        nID = FileUtil.Get<int>(_data, "nID");
        Name = FileUtil.Get<string>(_data, "Name");
        Needs = FileUtil.Get<PlayerData.SkillData.NEEDS>(_data, "Needs");
        Type = FileUtil.Get<PlayerData.SkillData.TYPE>(_data, "Type");
        DmgType = FileUtil.Get<PlayerData.SkillData.DMGTYPE>(_data, "DmgType");
        PatkType = FileUtil.Get<PlayerData.SkillData.PATKTYPE>(_data, "PatkType");
        MatkType = FileUtil.Get<PlayerData.SkillData.MATKTYPE>(_data, "MatkType");
        Allies = FileUtil.Get<PlayerData.SkillData.ALLIES>(_data, "Allies");
        AreaType = FileUtil.Get<PlayerData.SkillData.AREATYPE>(_data, "AreaType");
        Range = FileUtil.Get<PlayerData.SkillData.RANGE>(_data, "Range");
        Speed = FileUtil.Get<int>(_data, "Speed");
        Explain = FileUtil.Get<string>(_data, "Explain");
    }
}

public class Character_SkillsTable
{
    private List<Character_SkillsRecord> m_recordList = new List<Character_SkillsRecord>();

    public Character_SkillsTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<Character_SkillsRecord>>(FileUtil.GetResPath(_filename));
    }

    public Character_SkillsTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            Character_SkillsRecord _record = new Character_SkillsRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<Character_SkillsRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public Character_SkillsRecord GetRecord(int _index)
    {
        Character_SkillsRecord _find = m_recordList.Find(delegate (Character_SkillsRecord _record)
        {
            return _record.nID == _index;
        });

        if (null == _find)
        {
            Debug.LogError("SwordMan_SkillsTable::GetRecord()[ null == Character_SkillsRecord]");
            return null;
        }

        return _find;
    }   
}

