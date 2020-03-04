using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AccessoryRecord
{
    public int acID;
    public string acStrName;
    public PlusProperty acPlusProperty1;
    public int acPlusAmount1;
    public PlusProperty acPlusProperty2;
    public int acPlusAmount2;
    public int acPrice;
    public string acExplain;
    public ITEMCATEGORY acType;

    public AccessoryRecord(Dictionary<string, string> _data)
    {
        acID = FileUtil.Get<int>(_data, "acID");
        acStrName = FileUtil.Get<string>(_data, "acStrName");
        acType = FileUtil.Get<ITEMCATEGORY>(_data, "acType");
        acPlusProperty1 = FileUtil.Get<PlusProperty>(_data, "acPlusProperty1");
        acPlusAmount1 = FileUtil.Get<int>(_data, "acPlusAmount1");
        acPlusProperty2 = FileUtil.Get<PlusProperty>(_data, "acPlusProperty2");
        acPlusAmount2 = FileUtil.Get<int>(_data, "acPlusAmount2");
        acExplain = FileUtil.Get<string>(_data, "acExplain");
        acPrice = FileUtil.Get<int>(_data, "acPrice");
    }
}

public class AccessoryTable
{
    public List<AccessoryRecord> m_recordList = new List<AccessoryRecord>();

    public AccessoryTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<AccessoryRecord>>(FileUtil.GetResPath(_filename));
    }

    public AccessoryTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            AccessoryRecord _record = new AccessoryRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public List<AccessoryRecord> getList()
    {
        return m_recordList;
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<AccessoryRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public AccessoryRecord GetRecord(int _acid)
    {
        AccessoryRecord _find = m_recordList.Find(delegate (AccessoryRecord _record)
        {
            return _record.acID == _acid;
        });

        if (null == _find)
        {
            Debug.LogError("AccessoryTable::GetRecord()[ null == AccessoryRecord]");
            return null;
        }

        return _find;
    }

    public void GetAcPlus1(int _id, PlusProperty _acPlusProperty1, int _acPlusAmount1)
    {
        AccessoryRecord accRecord = TableMgr.Instance.accessoryTable.GetRecord(_id);

        _acPlusAmount1 = accRecord.acPlusAmount1;
        _acPlusProperty1 = accRecord.acPlusProperty1;
    }

    public void GetAcPlus2(int _id, PlusProperty _acPlusProperty2, int _acPlusAmount2)
    {
        AccessoryRecord accRecord = TableMgr.Instance.accessoryTable.GetRecord(_id);

        _acPlusAmount2 = accRecord.acPlusAmount2;
        _acPlusProperty2 = accRecord.acPlusProperty2;
    }
}
