using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character_SkilltreeRecord  {
    public int OpenSkillIndex;
    public int NeedSkillIndex_1;
    public int NeedCount_1;
    public int NeedSkillIndex_2;
    public int NeedCount_2;
    public int NeedSkillIndex_3;
    public int NeedCount_3;

    public Character_SkilltreeRecord(Dictionary<string, string> _data)
    {
        OpenSkillIndex = FileUtil.Get<int>(_data,"OpenSkillIndex");
        NeedSkillIndex_1 = FileUtil.Get<int>(_data, "NeedSkillIndex 1");
        NeedCount_1 = FileUtil.Get<int>(_data,"NeedCount 1");
        NeedSkillIndex_2 = FileUtil.Get<int>(_data, "NeedSkillIndex 2");
        NeedCount_2 = FileUtil.Get<int>(_data, "NeedCount 2");
        NeedSkillIndex_3 = FileUtil.Get<int>(_data,"NeedSkillIndex 3");
        NeedCount_3 = FileUtil.Get<int>(_data,"NeedCount 3");
    }
}

public class Character_SkilltreeTable
{
    private List<Character_SkilltreeRecord> m_recordList = new List<Character_SkilltreeRecord>();

    public Character_SkilltreeTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<Character_SkilltreeRecord>>(FileUtil.GetResPath(_filename));
    }

    public Character_SkilltreeTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            Character_SkilltreeRecord _record = new Character_SkilltreeRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<Character_SkilltreeRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public Character_SkilltreeRecord GetRecord(int _index)
    {
        Character_SkilltreeRecord _find = m_recordList.Find(delegate (Character_SkilltreeRecord _record)
        {
            return _record.OpenSkillIndex == _index;
        });

        if (null == _find)
        {
            Debug.LogError("Character_SkilltreeTable::GetRecord()[ null == Character_SkilltreeRecord]");
            return null;
        }

        return _find;
    }
}
