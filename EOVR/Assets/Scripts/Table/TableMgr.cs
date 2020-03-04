    using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TableXlsData
{
    public delegate void LoadType(string _sheetName, List<Dictionary<string, string>> _data);

    public string xlsPath;
    public LoadType load;
    public UnityEngine.Events.UnityAction save;

    public TableXlsData( string _path, LoadType _load, UnityEngine.Events.UnityAction _save )
    {
        xlsPath = _path;
        load = _load;
        save = _save;
    }
}

public class TableMgr : XcSingleton<TableMgr>
{
	#region - variable
	public bool isLoad = false;		

    public WeaponTable weaponTable;
    public ArmorTable armorTable;
    public AccessoryTable accessoryTable;
    public ConItemTable conItemTable;
    public DropItemTable dropItemTable;

    public Monster_StatTable monster_StatTable;
    public Monster_SkillsTable monster_SkillsTable;
    
    public Character_StatsTable character_StatsTable;
    public Character_SkillsTable character_SkillsTable;
    public Character_SkilltreeTable character_SkilltreeTable;
    public Character_SkillPercentTable character_SkillPercentTable;
    public Character_SkillAdditionalEffectTable character_SkillAdditionalEffectTable;
    public ExpTable expTable;

    #endregion

    public TableMgr()
    {
        
    }

    public void CheckLoad()
    {
        if (true == isLoad)
            return;

        Load();
    }


    public void Load()
	{
        weaponTable = new WeaponTable("Table/WeaponTable");
        armorTable = new ArmorTable("Table/ArmorTable");
        accessoryTable = new AccessoryTable("Table/AccessoryTable");
        conItemTable = new ConItemTable("Table/ConsumableItemsTable");
        dropItemTable = new DropItemTable("Table/DropItemTable");
        
        monster_StatTable = new Monster_StatTable("Table/Monster_Stats");
        monster_SkillsTable = new Monster_SkillsTable("Table/Monster_Skills");
       
        character_StatsTable = new Character_StatsTable("Table/Character_Stats");
        character_SkillsTable = new Character_SkillsTable("Table/Character_Skills");
        character_SkilltreeTable = new Character_SkilltreeTable("Table/Character_Skilltree");
        character_SkillPercentTable = new Character_SkillPercentTable("Table/Character_SkillPercent");
        character_SkillAdditionalEffectTable = new Character_SkillAdditionalEffectTable("Table/Character_SkillAdditionalEffect");
        expTable = new ExpTable("Table/ExpTable");
        
        isLoad = true;
    }

    public void Save_xls()
    {

        if (null != weaponTable)
            weaponTable.WriteTable("Table/WeaponTable");
        if (null != armorTable)
            armorTable.WriteTable("Table/ArmorTable");
        if (null != accessoryTable)
            accessoryTable.WriteTable("Table/AccessoryTable");
        if (null != conItemTable)
            conItemTable.WriteTable("Table/ConsumableItemsTable");
        if (null != dropItemTable)
            dropItemTable.WriteTable("Table/DropItemTable");

        if (null != monster_StatTable)
            monster_StatTable.WriteTable("Table/Monster_Stats");
        if (null != monster_SkillsTable)
            monster_SkillsTable.WriteTable("Table/Monster_Skills");

        if (null != character_StatsTable)
            character_StatsTable.WriteTable("Table/Character_Stats");
        if (null != character_SkillsTable)
            character_SkillsTable.WriteTable("Table/Character_Skills");
        if (null != character_SkilltreeTable)
            character_SkilltreeTable.WriteTable("Table/Character_Skilltree");
        if (null != character_SkillPercentTable)
            character_SkillPercentTable.WriteTable("Table/Character_SkillPercent");
        if (null != character_SkillAdditionalEffectTable)
            character_SkillAdditionalEffectTable.WriteTable("Table/Character_SkillAdditionalEffect");
        if (null != expTable)
            expTable.WriteTable("Table/ExpTable");

    }

    public void Load_xls(string _sheetName, List<Dictionary<string, string>> _data )
    {
        if (0 == string.Compare(_sheetName, "WeaponTable", true))
        {
            weaponTable = new WeaponTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "ArmorTable", true))
        {
            armorTable = new ArmorTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "AccessoryTable", true))
        {
            accessoryTable = new AccessoryTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "ConsumableItemsTable", true))
        {
            conItemTable = new ConItemTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "DropItemTable", true))
        {
            dropItemTable = new DropItemTable(_data);
        }

        else if (0 == string.Compare(_sheetName, "Monster_Stats", true))
        {
            monster_StatTable = new Monster_StatTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "Monster_Skills", true))
        {
            monster_SkillsTable = new Monster_SkillsTable(_data);
        }



        else if (0 == string.Compare(_sheetName, "Character_Stats", true))
        {
            character_StatsTable = new Character_StatsTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "Character_Skills", true))
        {
            character_SkillsTable = new Character_SkillsTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "Character_Skilltree", true))
        {
            character_SkilltreeTable = new Character_SkilltreeTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "Character_SkillPercent", true))
        {
            character_SkillPercentTable = new Character_SkillPercentTable(_data);
        }
        else if (0 == string.Compare(_sheetName, "ExpTable", true))
        {
            expTable = new ExpTable(_data);
        }
        if (0 == string.Compare(_sheetName, "Character_SkillPercent", true))
        {
            character_SkillAdditionalEffectTable = new Character_SkillAdditionalEffectTable(_data);
        }

    }

    public List<TableXlsData> GetTableXlsData()
    {
        List<TableXlsData> tableXlsDataList = new List<TableXlsData>();
        tableXlsDataList.Add(new TableXlsData("/../data.xlsx", Load_xls, Save_xls));          
        return tableXlsDataList;
    }
}
