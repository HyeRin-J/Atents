using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<ShopItem> itemList = new List<ShopItem>();
    public GameObject itemSlot;
    public GameObject panel;

    static Shop instance;
    public static Shop _instance
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

    public void AddRecord(ShopItem recordItem)
    {
        ShopItem slot = null;
        slot = Instantiate(itemSlot).GetComponent<ShopItem>();
        slot.itemClass = recordItem.itemClass;
        slot.transform.SetParent(panel.transform);
        slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        itemList.Add(slot);//상점 리스트에 모든 아이템들을 넣어둠
    }

    public void BuyItem()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemClass.itemID == StoreMng.ins.SelectItem.itemClass.itemID)
            {
                ShopItem itemTmp = itemList[i];
                StoreMng.ins.invenOBJ.AddItemSlot(itemList[i]);
                StoreMng.ins.SelectItem = null;
                
                break;
            }
        }
    }

    public void All()//인벤토리 전체 리스트 활성화
    {
        AllFalse();
        foreach (ShopItem item in itemList)
        {
            item.gameObject.SetActive(true);
        }
    }

    public void Tap(int num)//1번째 탭 활성화
    {
        AllFalse();
        foreach (var item in itemList)
        {
            if (item.category == (ShopCategory)num)
            {
                item.gameObject.SetActive(true);
            }
        }
    }

    public void AllFalse()//모든 슬롯 비활성화
    {
        foreach (var item in itemList)
        {
            item.gameObject.SetActive(false);
        }
    }
}
