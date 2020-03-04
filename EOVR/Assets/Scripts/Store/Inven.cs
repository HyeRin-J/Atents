using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Inven : MonoBehaviour
{
    public List<ShopItem> inventory;

    public GameObject ItemSlot;

    public GameObject panel;
    int originNumberCount;
    public int amount;

    static Inven instance;
    public static Inven _instance
    {
        get { return instance; }
    }

    // Use this for initialization
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this);
    }
    #region 인벤 활성화
    //public void OpenInventory()
    //{
    //    if (inventory != null)
    //    {
    //        for (int i = 0; i < inventory.Count; i++)
    //        {

    //        }
    //    }
    //} 
    #endregion

    public void AddItemSlot(ShopItem _item)
    {        
        for (int i = 0; i < amount; i++)
        {
            //상점,필드드랍,보상 등으로 실행
            //아이템 수치 세팅 시작
            ShopItem item;
            item = Instantiate(ItemSlot).GetComponent<ShopItem>();
            item.itemClass = _item.itemClass;
            item.transform.SetParent(panel.transform);
            item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            if (originNumberCount > 10000)
            {
                originNumberCount = 0;
            }

            item.itemClass.originalCode = originNumberCount++;//랜덤의 값 센터에서 받아와야함
                                                              //_item.recodeCodeNum = 123;//읽어온 레코드의 값
            inventory.Add(item);
        }
    }

    public void RemoveItemSlot()
    {//판매 버튼 용
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemClass.originalCode == StoreMng.ins.SelectItem.itemClass.originalCode)
            {
                ShopItem tmp = inventory[i];
                inventory.Remove(inventory[i]);
                Destroy(tmp.gameObject);
                StoreMng.ins.SelectItem = null;
                break;
            }
        }
    }

    #region 안씀
    //public void All()//인벤토리 전체 리스트 활성화
    //{
    //    foreach (var item in inventory)
    //    {
    //        item.gameObject.SetActive(true);
    //    }
    //}
    #endregion

    public void Tap(int num)
    {
        AllFalse();
        if (num == 6000)
        {
            foreach (var item in inventory)
            {
                if ((int)item.category == num)
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
        if (num == 5000)
        {
            foreach (var item in inventory)
            {
                if ((int)item.category >= 1000 && (int)item.category < 4000)    // weapon, armor, accessory
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
        if (num == 4000)
        {
            foreach (var item in inventory)
            {
                if ((int)item.category >= 4000 && (int)item.category < 5000)        // conItem
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
    }

    public void AllFalse()//모든 슬롯 비활성화
    {
        foreach (var item in inventory)
        {
            item.gameObject.SetActive(false);
        }
    }
}