using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character_StatsRecord{
    public int nID;     
    public int LEVEL;   
    public int HP;          //1
    public int TP;          //2
    public int STR;         //str~luc   공격력
    public int INT;
    public int VIT;         //방어력
    public int WIS;
    public int AGI;
    public int LUC;
    

    public Character_StatsRecord(Dictionary<string, string> _data)
    {
        nID = FileUtil.Get<int>(_data, "nID");
        LEVEL = FileUtil.Get<int>(_data, "LEVEL");
        HP = FileUtil.Get<int>(_data, "HP");
        TP = FileUtil.Get<int>(_data, "TP");
        STR = FileUtil.Get<int>(_data, "STR");
        INT = FileUtil.Get<int>(_data, "INT");
        VIT = FileUtil.Get<int>(_data, "VIT");
        WIS = FileUtil.Get<int>(_data, "WIS");
        AGI = FileUtil.Get<int>(_data, "AGI");
        LUC = FileUtil.Get<int>(_data, "LUC");
    }
}

public class Character_StatsTable
{
    public List<Character_StatsRecord> m_recordList = new List<Character_StatsRecord>();

    public Character_StatsTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<Character_StatsRecord>>(FileUtil.GetResPath(_filename));
    }

    public List<Character_StatsRecord> ReturnRecord()
    {
        return m_recordList;
    }

    public Character_StatsTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            Character_StatsRecord _record = new Character_StatsRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<Character_StatsRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public Character_StatsRecord GetRecord(int _index)
    {
        Character_StatsRecord _find = m_recordList.Find(delegate (Character_StatsRecord _record)
        {
            return _record.nID == _index;
        });

        if (null == _find)
        {
            Debug.LogError("Character_StatsTable::GetRecord()[ null == Character_StatsRecord]");
            return null;
        }

        return _find;
    }
}
