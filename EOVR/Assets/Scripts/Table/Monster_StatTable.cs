using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Monster_StatRecord 
{
    public enum WEAKNESS
    { Cut, Bash, Melee, Fire, Ice, Lightening }
    public enum STATUSEFFECT
    { Poison, Paralysis, Confusion, Sleep }

    public int nID;
    public string Name;
    public int Lv;
    public int Hp;
    public int Patk;
    public int Pdef;
    public int Matk;
    public int Mdef;
    public int Exp;
    public int[] Weakness;
    public int[] StatusEffect;

    public Monster_StatRecord(Dictionary<string, string> _data)
    {
        nID = FileUtil.Get<int>(_data, "nID");
        Name = FileUtil.Get<string>(_data, "Name");
        Lv = FileUtil.Get<int>(_data, "Lv");
        Hp = FileUtil.Get<int>(_data, "Hp");
        Patk = FileUtil.Get<int>(_data, "Patk");
        Pdef = FileUtil.Get<int>(_data, "Pdef");
        Matk = FileUtil.Get<int>(_data, "Matk");
        Mdef = FileUtil.Get<int>(_data, "Mdef");
        Exp = FileUtil.Get<int>(_data, "Exp");
        Weakness = FileUtil.Get<int[]>(_data, "Weakness");
        StatusEffect = FileUtil.Get<int[]>(_data, "StatusEffect");
        //DropItem = FileUtil.Get<int>(_data, "DropItem");


    }
}

public class Monster_StatTable
{
    private List<Monster_StatRecord> m_recordList = new List<Monster_StatRecord>();

    public Monster_StatTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<Monster_StatRecord>>(FileUtil.GetResPath(_filename));
    }

    public Monster_StatTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            Monster_StatRecord _record = new Monster_StatRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<Monster_StatRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public Monster_StatRecord GetRecord(int _index)
    {
        Monster_StatRecord _find = m_recordList.Find(delegate (Monster_StatRecord _record)
        {
            return _record.nID == _index;
        });

        if (null == _find)
        {
            Debug.LogError("MonsterTable::GetRecord()[ null == MonsterRecord]");
            return null;
        }

        return _find;
    }
}
