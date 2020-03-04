using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ItemClass
{
    public int originalCode;     //고유코드
    public int itemID;
    public string itemName;

    public ITEMCATEGORY itemType;

    public WEAPON_ATK_KIND wAtkType;

    public PlusProperty plusProperty1;
    public int plusAmount1;
    public PlusProperty plusProperty2;
    public int plusAmount2;

    public int wAtk;
    public int wMatk;

    public int aDef;
    public int aMdef;

    public int itemPrice;
    public string itemExplain;
}

public class ShopItem : MonoBehaviour
{

    public ShopCategory category = new ShopCategory();

    Button btn;
    public Text itemName;
    public Text price;

    public ItemClass itemClass = new ItemClass();

    private void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Select);
        itemName.text = itemClass.itemName;
        price.text = string.Format("{0}", itemClass.itemPrice);
        //생성자를 사용하던지 해서 아이템 세팅
        gameObject.name = itemClass.itemName;
        category = (ShopCategory)itemClass.itemType;
    }

    public void Select()
    {
        StoreMng.ins.SelectWhat(gameObject.GetComponent<ShopItem>());
    }
}