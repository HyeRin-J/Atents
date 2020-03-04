using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExpRecord
{
    public int NowLevel;
    public int EXP;



    public ExpRecord(Dictionary<string, string> _data)
    {
        NowLevel = FileUtil.Get<int>(_data, "NowLevel");
        EXP = FileUtil.Get<int>(_data, "EXP");
    }
}

public class ExpTable
{
    private List<ExpRecord> m_recordList = new List<ExpRecord>();

    public ExpTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<ExpRecord>>(FileUtil.GetResPath(_filename));
    }

    public ExpTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            ExpRecord _record = new ExpRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<ExpRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public ExpRecord GetRecord(int _index)
    {
        ExpRecord _find = m_recordList.Find(delegate (ExpRecord _record)
        {
            return _record.NowLevel == _index;
        });

        if (null == _find)
        {
            Debug.LogError("ExpTable::GetRecord()[ null == ExpRecord] : " + _index);
            return null;
        }

        return _find;
    }
}
