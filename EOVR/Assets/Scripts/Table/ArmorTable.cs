using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArmorRecord
{
    public int aID;
    public string aStrName;
    public ITEMCATEGORY aType;
    public PlusProperty aPlusProperty;
    public int aPlusAmount;
    public int aDef;
    public int aMdef;
    
    public int aPrice;
    public string aExplain;

    public ArmorRecord(Dictionary<string, string> _data)
    {
        aID = FileUtil.Get<int>(_data, "aID");
        aStrName = FileUtil.Get<string>(_data, "aStrName");
        aType = FileUtil.Get<ITEMCATEGORY>(_data, "aType");
        aPlusProperty = FileUtil.Get<PlusProperty>(_data, "aPlusProperty");
        aPlusAmount = FileUtil.Get<int>(_data, "aPlusAmount");
        aDef = FileUtil.Get<int>(_data, "aDef");
        aMdef = FileUtil.Get<int>(_data, "aMdef");
        aPrice = FileUtil.Get<int>(_data, "aPrice");
        aExplain = FileUtil.Get<string>(_data, "aExplain");
    }
}

public class ArmorTable
{
    public List<ArmorRecord> m_recordList = new List<ArmorRecord>();

    public ArmorTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<ArmorRecord>>(FileUtil.GetResPath(_filename));
    }

    public ArmorTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            ArmorRecord _record = new ArmorRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public List<ArmorRecord> getList()
    {
        return m_recordList;
    }

    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<ArmorRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public ArmorRecord GetRecord(int _index)
    {
        ArmorRecord _find = m_recordList.Find(delegate (ArmorRecord _record)
        {
            return _record.aID == _index;
        });

        if (null == _find)
        {
            Debug.LogError("ArmorTable::GetRecord()[ null == ArmorRecord]");
            return null;
        }

        return _find;
    }

    public void GetDefPoint(int _id, out int _aDef, out int _aMdef)
    {
        ArmorRecord armorRecord = TableMgr.Instance.armorTable.GetRecord(_id);

        _aDef = armorRecord.aDef;
        _aMdef = armorRecord.aMdef;
    }

    public void GetPlusProperty(int _id, out PlusProperty _aPlusProperty, out int _aPlusAmount)
    {
        ArmorRecord armorRecord = TableMgr.Instance.armorTable.GetRecord(_id);

        _aPlusProperty = armorRecord.aPlusProperty;
        _aPlusAmount = armorRecord.aPlusAmount;
    }

    public ITEMCATEGORY GetArmorType(int _id)
    {
        ArmorRecord armorRecord = TableMgr.Instance.armorTable.GetRecord(_id);
        return armorRecord.aType;
    }

}
