using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponRecord
{
    public int wID;
    public string wStrName;
    public ITEMCATEGORY wType;
    public WEAPON_ATK_KIND wAtkType;
    public PlusProperty wPlusProperty;
    public int wPlusAmount;
    public int wAtk;
    public int wMatk;
    public int wPrice;   
    public string wExplain;

    
    public WeaponRecord(Dictionary<string, string> _data)
    {
        wID = FileUtil.Get<int>(_data, "wID");
        wStrName = FileUtil.Get<string>(_data, "wStrName");       
        wAtk = FileUtil.Get<int>(_data, "wAtk");
        wMatk = FileUtil.Get<int>(_data, "wMatk");
        wPrice = FileUtil.Get<int>(_data, "wPrice");
        wPlusAmount = FileUtil.Get<int>(_data, "wPlusAmount");
        wExplain = FileUtil.Get<string>(_data, "wExplain");

        wType = FileUtil.Get<ITEMCATEGORY>(_data, "wType");
        wPlusProperty = FileUtil.Get<PlusProperty>(_data, "wPlusProperty");
        wAtkType = FileUtil.Get<WEAPON_ATK_KIND>(_data, "wAtkType");
    }
}

public class WeaponTable {

    public List<WeaponRecord> m_recordList = new List<WeaponRecord>();

    public WeaponTable(string _filename)
    {
        m_recordList
            = FileUtil.BinaryDeserialize<List<WeaponRecord>>(FileUtil.GetResPath(_filename));
    }

    public WeaponTable(List<Dictionary<string, string>> _data)
    {
        m_recordList.Clear();
        foreach (Dictionary<string, string> _var in _data)
        {
            WeaponRecord _record = new WeaponRecord(_var);
            m_recordList.Add(_record);
        }
    }

    public int getListCount()
    {
        return m_recordList.Count;
    }
    public List<WeaponRecord> getList()
    {
        return m_recordList;
    }
   
    public void WriteTable(string _filename)
    {
        FileUtil.BinarySerialize<List<WeaponRecord>>(m_recordList, FileUtil.GetResPath(_filename));
    }

    public WeaponRecord GetRecord(int _wID)
    {
        WeaponRecord _find = m_recordList.Find(delegate (WeaponRecord _record)
        {
            return _record.wID == _wID;
        });

        if (null == _find)
        {
            Debug.LogError("WeaponTable::GetRecord()[ null == WeaponRecord] : " + _wID);
            return null;
        }

        return _find;
    }

    public void GetAtkPoint(int _id, out int _wAtk, out int _wMatk)
    {
        WeaponRecord weaponRecord = TableMgr.Instance.weaponTable.GetRecord(_id);

        _wAtk = weaponRecord.wAtk;
        _wMatk = weaponRecord.wMatk;
    }

    public void GetPlusProperty(int _id, out PlusProperty _wPlusProperty, out int _wPlusAmount)
    {
        WeaponRecord weaponRecord = TableMgr.Instance.weaponTable.GetRecord(_id);

        _wPlusProperty = weaponRecord.wPlusProperty;
        _wPlusAmount = weaponRecord.wPlusAmount;
    }

    public WEAPON_ATK_KIND GetAtkType(int _id)
    {
        WeaponRecord weaponRecord = TableMgr.Instance.weaponTable.GetRecord(_id);
        return weaponRecord.wAtkType;
    }

}
