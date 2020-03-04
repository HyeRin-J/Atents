using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMng : MonoBehaviour
{
    public static StoreMng ins = null;

    public Inven invenOBJ;//인벤토리 접속용
    public Shop shopOBJ;

    public ShopItem SelectItem = null;//인벤이든 상점이든 특정 아이템을 선택하였을때

    public WeaponTable weaponTable;
    public ArmorTable armorTable;
    public AccessoryTable accessoryTable;
    public ConItemTable conItemTable;
    public DropItemTable dropItemTable;

    public GameObject weaponPanel;
    public GameObject armorPanel;
    public GameObject accessoryPanel;
    public GameObject conItemPanel;
    public GameObject sellItemPanel;
    public Text moneyText;

    public void SelectWhat(ShopItem item)
    {
        SelectItem = item;
        ButtonMng._instance.SlotClick(ref item.itemClass.itemName, ref item.itemClass.itemPrice, ref item.itemClass.itemID);
    }

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }

        TableMgr.Instance.CheckLoad();

        weaponTable = TableMgr.Instance.weaponTable;
        armorTable = TableMgr.Instance.armorTable;
        accessoryTable = TableMgr.Instance.accessoryTable;
        conItemTable = TableMgr.Instance.conItemTable;
        dropItemTable = TableMgr.Instance.dropItemTable;
    }

    private void Start()
    {
        ShopItem item;
        #region 웨폰 테이블

        foreach (var str in weaponTable.m_recordList)
        {
            item = new ShopItem();

            item.itemClass.itemType = str.wType;
            item.itemClass.itemID = str.wID;
            item.itemClass.itemName = str.wStrName;
            item.itemClass.plusProperty1 = str.wPlusProperty;
            item.itemClass.plusAmount1 = str.wPlusAmount;
            item.itemClass.wAtk = str.wAtk;
            item.itemClass.wMatk = str.wMatk;
            item.itemClass.itemPrice = str.wPrice;
            item.itemClass.itemExplain = str.wExplain;
            shopOBJ.panel = weaponPanel;
            shopOBJ.AddRecord(item);
        }
        #endregion

        #region armor 테이블
        foreach (var str in armorTable.m_recordList)
        {
            item = new ShopItem();

            item.itemClass.itemType = str.aType;

            item.itemClass.itemID = str.aID;
            item.itemClass.itemName = str.aStrName;
            item.itemClass.plusProperty1 = str.aPlusProperty;
            item.itemClass.plusAmount1 = str.aPlusAmount;
            item.itemClass.itemPrice = str.aPrice;
            item.itemClass.itemExplain = str.aExplain;
            shopOBJ.panel = armorPanel;
            shopOBJ.AddRecord(item);
        }
        #endregion

        #region Accessory 테이블
        foreach (var str in accessoryTable.m_recordList)
        {
            item = new ShopItem();

            item.itemClass.itemID = str.acID;
            item.itemClass.itemName = str.acStrName;
            item.itemClass.plusProperty1 = str.acPlusProperty1;
            item.itemClass.plusAmount1 = str.acPlusAmount1;
            item.itemClass.plusProperty2 = str.acPlusProperty2;
            item.itemClass.plusAmount2 = str.acPlusAmount2;
            item.itemClass.itemPrice = str.acPrice;
            item.itemClass.itemExplain = str.acExplain;
            shopOBJ.panel = accessoryPanel;
            shopOBJ.AddRecord(item);
        }
        #endregion

        #region ConItem 테이블
        foreach (var str in conItemTable.m_recordList)
        {
            item = new ShopItem();

            item.itemClass.itemID = str.cID;
            item.itemClass.itemType = str.cType;
            item.itemClass.itemName = str.cStrName;
            item.itemClass.plusProperty1 = str.cPlusProperty1;
            item.itemClass.plusAmount1 = str.cPlusAmount1;
            item.itemClass.plusProperty2 = str.cPlusProperty2;
            item.itemClass.plusAmount2 = str.cPlusAmount2;
            item.itemClass.itemPrice = str.cPrice;
            item.itemClass.itemExplain = str.cExplain;
            shopOBJ.panel = conItemPanel;
            shopOBJ.AddRecord(item);
        }
        #endregion

        SetInven();
        setMoney();
    }

    public void SetInven()
    {
        List<int> _itemList = PartyManager._instance.GetInventoryItemList();

        ShopItem invenItem;

        for (int i = 0; i < _itemList.Count; i++)
        {
            invenItem = new ShopItem();

            if (_itemList[i] >= 10000 && _itemList[i] < 20000)
            {
                for (int j = 0; j < weaponTable.m_recordList.Count; j++)
                {   
                    if (_itemList[i] == weaponTable.m_recordList[j].wID)
                    {
                        invenItem.itemClass.itemID = weaponTable.m_recordList[j].wID;
                        invenItem.itemClass.itemType = weaponTable.m_recordList[j].wType;
                        invenItem.itemClass.itemName = weaponTable.m_recordList[j].wStrName;
                        invenItem.itemClass.wAtk = weaponTable.m_recordList[j].wAtk;
                        invenItem.itemClass.wMatk = weaponTable.m_recordList[j].wMatk;
                        invenItem.itemClass.plusProperty1 = weaponTable.m_recordList[j].wPlusProperty;
                        invenItem.itemClass.plusAmount1 = weaponTable.m_recordList[j].wPlusAmount;
                        invenItem.itemClass.itemPrice = weaponTable.m_recordList[j].wPrice;
                        invenItem.itemClass.itemExplain = weaponTable.m_recordList[j].wExplain;

                        invenOBJ.panel = sellItemPanel;
                        invenOBJ.amount = 1;
                        invenOBJ.AddItemSlot(invenItem);

                        break;
                    }
                }
            }

            if (_itemList[i] >= 20000 && _itemList[i] < 30000)
            {
                for (int j = 0; j < armorTable.m_recordList.Count; j++)
                {
                    if (_itemList[i] == armorTable.m_recordList[j].aID)
                    {
                        invenItem.itemClass.itemID = armorTable.m_recordList[j].aID;
                        invenItem.itemClass.itemType = armorTable.m_recordList[j].aType;
                        invenItem.itemClass.itemName = armorTable.m_recordList[j].aStrName;
                        invenItem.itemClass.plusProperty1 = armorTable.m_recordList[j].aPlusProperty;
                        invenItem.itemClass.plusAmount1 = armorTable.m_recordList[j].aPlusAmount;
                        invenItem.itemClass.aDef = armorTable.m_recordList[j].aDef;
                        invenItem.itemClass.aMdef = armorTable.m_recordList[j].aMdef;
                        invenItem.itemClass.itemPrice = armorTable.m_recordList[j].aPrice;
                        invenItem.itemClass.itemExplain = armorTable.m_recordList[j].aExplain;

                        invenOBJ.panel = sellItemPanel;
                        invenOBJ.amount = 1;
                        invenOBJ.AddItemSlot(invenItem);
                        
                        break;
                    }
                }
            }

            if (_itemList[i] >= 30000 && _itemList[i] < 40000)          // 10000~30000 = equip
            {
                for (int j = 0; j < accessoryTable.m_recordList.Count; j++)
                {
                    if (_itemList[i] == accessoryTable.m_recordList[j].acID)
                    {
                        invenItem.itemClass.itemID = accessoryTable.m_recordList[j].acID;
                        invenItem.itemClass.itemName = accessoryTable.m_recordList[j].acStrName;
                        invenItem.itemClass.itemType = accessoryTable.m_recordList[j].acType;
                        invenItem.itemClass.plusProperty1 = accessoryTable.m_recordList[j].acPlusProperty1;
                        invenItem.itemClass.plusAmount1 = accessoryTable.m_recordList[j].acPlusAmount1;
                        invenItem.itemClass.plusProperty2 = accessoryTable.m_recordList[j].acPlusProperty2;
                        invenItem.itemClass.plusAmount2 = accessoryTable.m_recordList[j].acPlusAmount2;
                        invenItem.itemClass.itemPrice = accessoryTable.m_recordList[j].acPrice;
                        invenItem.itemClass.itemExplain = accessoryTable.m_recordList[j].acExplain;

                        invenOBJ.panel = sellItemPanel;
                        invenOBJ.amount = 1;
                        invenOBJ.AddItemSlot(invenItem);
                        
                        break;
                    }
                }
            }

            if (_itemList[i] >= 40000 && _itemList[i] < 50000)          // 40000 = con
            {
                for (int j = 0; j < conItemTable.m_recordList.Count; j++)
                {
                    if (_itemList[i] == conItemTable.m_recordList[j].cID)
                    {
                        invenItem.itemClass.itemID = conItemTable.m_recordList[j].cID;
                        invenItem.itemClass.itemType = conItemTable.m_recordList[j].cType;
                        invenItem.itemClass.itemName = conItemTable.m_recordList[j].cStrName;
                        invenItem.itemClass.plusProperty1 = conItemTable.m_recordList[j].cPlusProperty1;
                        invenItem.itemClass.plusAmount1 = conItemTable.m_recordList[j].cPlusAmount1;
                        invenItem.itemClass.plusProperty2 = conItemTable.m_recordList[j].cPlusProperty2;
                        invenItem.itemClass.plusAmount2 = conItemTable.m_recordList[j].cPlusAmount2;
                        invenItem.itemClass.itemPrice = conItemTable.m_recordList[j].cPrice;
                        invenItem.itemClass.itemExplain = conItemTable.m_recordList[j].cExplain;

                        invenOBJ.panel = sellItemPanel;
                        invenOBJ.amount = 1;
                        invenOBJ.AddItemSlot(invenItem);
                        
                        break;
                    }
                }
            }

            if (_itemList[i] >= 50000 && _itemList[i] < 60000)          // 50000 = Drop
            {
                for (int j = 0; j < dropItemTable.m_recordList.Count; j++)
                {
                    if (_itemList[i] == dropItemTable.m_recordList[j].nID)
                    {
                        invenItem.itemClass.itemID = dropItemTable.m_recordList[j].nID;
                        invenItem.itemClass.itemName = dropItemTable.m_recordList[j].dropItem;
                        invenItem.itemClass.itemType = dropItemTable.m_recordList[j].dropItemType;
                        invenItem.itemClass.itemPrice = dropItemTable.m_recordList[j].dropItemPrice;

                        invenOBJ.panel = sellItemPanel;
                        invenOBJ.amount = 1;
                        invenOBJ.AddItemSlot(invenItem);

                        break;
                    }
                }
            }
        }
    }
    public void setMoney()
    {
        moneyText.text = string.Format("Total: {0}", PartyManager._instance.poketMoney);
    }
}
