using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character_SkillPercentRecord  {
    public int nID;
    public int Lv1Cost;
    public float Percent1;
    public int Lv1Duration;
    public int Lv2Cost;
    public float Percent2;
    public int Lv2Duration;
    public int Lv3Cost;
    public float Percent3;
    public int Lv3Duration;
    public int Lv4Cost;
    public float Percent4;
    public int Lv4Duration;
    public int Lv5Cost;
    public float Percent5;
    public int Lv5Duration;

    public Character_SkillPercentRecord(Dictionary<string, string> _data)
    {
        nID = FileUtil.Get<int>(_data, "nID");
        Lv1Cost = FileUtil.Get<int>(_data, "Lv1Cost");
        Percent1 = FileUtil.Get<float>(_data, "Percent1");
        Lv1Duration = FileUtil.Get<int>(_data, "Lv1Duration");
        Lv2Cost = FileUtil.Get<int>(_data, "Lv2Cost");
        Percent2 = FileUtil.Get<float>(_data, "Percent2");
        Lv2Duration = FileUtil.Get<int>(_data, "Lv2Duration");
        Lv3Cost = FileUtil.Get<int>(_data, "Lv3Cost");
        Percent3 = FileUtil.Get<float>(_data, "Percent3");
        Lv3Duration = FileUtil.Get<int>(_data, "Lv3Duration");
        Lv4Cost = FileUtil.Get<int>(_data, "Lv4Cost");
        Percent4 = FileUtil.Get<float>(_data, "Percent4");
        Lv4Duration = FileUtil.Get<int>(_data, "Lv4Duration");
        Lv5Cost = FileUtil.Get<int>(_data, "Lv5Cost");
        Percent5 = FileUtil.Get<float>(_data, "Percent5");
        Lv5Duration = FileUtil.Get<int>(_data, "Lv5Duration");
    }
}

public class Character_SkillPercentTable
{
    private List<Character_SkillPercentRecord> m_recordList = new List<Character_SkillPercentRecord>();

    public Character_SkillPercentTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<Character_SkillPercentRecord>>(FileUtil.GetResPath(_filename));
    }

    public Character_SkillPercentTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            Character_SkillPercentRecord _record = new Character_SkillPercentRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<Character_SkillPercentRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public Character_SkillPercentRecord GetRecord(int _index)
    {
        Character_SkillPercentRecord _find = m_recordList.Find(delegate (Character_SkillPercentRecord _record)
        {
            return _record.nID == _index;
        });

        if (null == _find)
        {
            Debug.LogError(" SwordMan_SkillPercentTable::GetRecord()[ null == SwordMan_SkillPercentRecord]");
            return null;
        }

        return _find;
    }
}
