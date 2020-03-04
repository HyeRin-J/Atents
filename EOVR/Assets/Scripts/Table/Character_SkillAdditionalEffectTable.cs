using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character_SkillAdditionalEffectRecord
{
    public int nID;
    public float Lv1Percent2;
    public int Lv1Duration2;
    public float Lv2Percent2;
    public int Lv2Duration2;
    public float Lv3Percent2;
    public int Lv3Duration2;
    public float Lv4Percent2;
    public int Lv4Duration2;
    public float Lv5Percent2;
    public int Lv5Duration2;

    public Character_SkillAdditionalEffectRecord(Dictionary<string, string> _data)
    {
        nID = FileUtil.Get<int>(_data, "nID");
        Lv1Percent2 = FileUtil.Get<float>(_data,"Lv1Percent2");
        Lv1Duration2 = FileUtil.Get<int>(_data, "Lv1Duration2");
        Lv2Percent2= FileUtil.Get<float>(_data, "Lv2Percent2");
        Lv2Duration2 = FileUtil.Get<int>(_data, "Lv2Duration2");
        Lv3Percent2= FileUtil.Get<float>(_data, "Lv3Percent2");
        Lv3Duration2 = FileUtil.Get<int>(_data, "Lv3Duration2");
        Lv4Percent2= FileUtil.Get<float>(_data, "Lv4Percent2");
        Lv4Duration2 = FileUtil.Get<int>(_data, "Lv4Duration2");
        Lv5Percent2= FileUtil.Get<float>(_data, "Lv5Percent2");
        Lv5Duration2 = FileUtil.Get<int>(_data, "Lv5Duration2");
    }
}

public class Character_SkillAdditionalEffectTable
{
    private List<Character_SkillAdditionalEffectRecord> m_recordList = new List<Character_SkillAdditionalEffectRecord>();

    public Character_SkillAdditionalEffectTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<Character_SkillAdditionalEffectRecord>>(FileUtil.GetResPath(_filename));
    }

    public Character_SkillAdditionalEffectTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            Character_SkillAdditionalEffectRecord _record = new Character_SkillAdditionalEffectRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<Character_SkillAdditionalEffectRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public Character_SkillAdditionalEffectRecord GetRecord(int _index)
    {
        Character_SkillAdditionalEffectRecord _find = m_recordList.Find(delegate (Character_SkillAdditionalEffectRecord _record)
        {
            return _record.nID == _index;
        });

        if (null == _find)
        {
            Debug.LogError("Character_SkillAdditionalEffectTable::GetRecord()[ null == Character_SkillAdditionalEffectRecord]");
            return null;
        }

        return _find;
    }
}
