using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItemRecord
{
    
    public int nID;
    public string dropItem;
    public int dropItemPrice;
    public ITEMCATEGORY dropItemType;
   

    public DropItemRecord(Dictionary<string, string> _data)
    {
        nID = FileUtil.Get<int>(_data, "nID");
        dropItem = FileUtil.Get<string>(_data, "DropItem");
        dropItemType = FileUtil.Get<ITEMCATEGORY>(_data, "DropItemType");
        dropItemPrice = FileUtil.Get<int>(_data, "DropItemPrice");
    }
}

public class DropItemTable
{
    public List<DropItemRecord> m_recordList = new List<DropItemRecord>();

    public DropItemTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<DropItemRecord>>(FileUtil.GetResPath(_filename));
    }

    public DropItemTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            DropItemRecord _record = new DropItemRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<DropItemRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public DropItemRecord GetRecord(int _index)
    {
        DropItemRecord _find = m_recordList.Find(delegate (DropItemRecord _record)
        {
            return _record.nID == _index;
        });

        if (null == _find)
        {
            Debug.LogError("DropItemTable::GetRecord()[ null == DropItemRecord]");
            return null;
        }

        return _find;
    }
}

