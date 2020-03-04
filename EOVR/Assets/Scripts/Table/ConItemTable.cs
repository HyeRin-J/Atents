using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConItemRecord
{
    public int cID;
    public string cStrName;
    public ITEMCATEGORY cType;
    public PlusProperty cPlusProperty1;
    public int cPlusAmount1;
    public PlusProperty cPlusProperty2;
    public int cPlusAmount2;
    public int cPrice;
    public string cExplain;

    public ConItemRecord(Dictionary<string, string> _data)
    {
        cID = FileUtil.Get<int>(_data, "cID");
        cStrName = FileUtil.Get<string>(_data, "cStrName");
        cType = FileUtil.Get<ITEMCATEGORY>(_data, "cType");
        cPlusProperty1 = FileUtil.Get<PlusProperty>(_data, "cPlusProperty1");
        cPlusAmount1 = FileUtil.Get<int>(_data, "cPlusAmount1");
        cPlusProperty2 = FileUtil.Get<PlusProperty>(_data, "cPlusProperty2");
        cPlusAmount2 = FileUtil.Get<int>(_data, "cPlusAmount2");
        cPrice = FileUtil.Get<int>(_data, "cPrice");
        cExplain = FileUtil.Get<string>(_data, "cExplain");
    }
}

public class ConItemTable
{
    public List<ConItemRecord> m_recordList = new List<ConItemRecord>();

    public ConItemTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<ConItemRecord>>(FileUtil.GetResPath(_filename));
    }

    public ConItemTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            ConItemRecord _record = new ConItemRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<ConItemRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public List<ConItemRecord> getList()
    {
        return m_recordList;
    }

    public ConItemRecord GetRecord(int _index)
    {
        ConItemRecord _find = m_recordList.Find(delegate (ConItemRecord _record)
        {
            return _record.cID == _index;
        });

        if (null == _find)
        {
            Debug.LogError("ConItemTable::GetRecord()[ null == ConItemRecord]");
            return null;
        }

        return _find;
    }
}
