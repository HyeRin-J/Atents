using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMng : MonoBehaviour
{
    #region 변수
    public GameObject buyMenu;
    public GameObject sellInven;
    public GameObject buyWeaponUI;
    public GameObject buyArmorUI;
    public GameObject buyAccessoryUI;
    public GameObject buyConItemUI;
    public GameObject buyPanel;
    public GameObject sellPanel;
    public GameObject confirmPanel;
    public GameObject detailMenu;

    public Text number;
    public Text buyNamePriceText;
    public Text sellNamePriceText;

    string itemName = null;
    int price = 0;
    int id = 0;
    public bool isBuy = false;

    public int num = 1;
    public PlayerCharacter SelectItem = null;
    public PlayerCharacter player;
    #endregion

    static ButtonMng instance;
    public static ButtonMng _instance
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

    public void ClickBuy()
    {
        isBuy = true;
        CloseAll();
        buyMenu.SetActive(true);
    }
    public void ClickSell()
    {
        isBuy = false;
        CloseAll();
        sellInven.SetActive(true);
        //StoreMng.ins.invenOBJ.AllFalse();
    }
    private void CloseAll()
    {
        buyMenu.SetActive(false);
        sellInven.SetActive(false);
        buyWeaponUI.SetActive(false);
        buyArmorUI.SetActive(false);
        buyAccessoryUI.SetActive(false);
        buyConItemUI.SetActive(false);
        Cancel();
    }

    public void WeaponBuy()
    {
        CloseAll();
        buyWeaponUI.SetActive(true);
    }
    public void ArmorBuy()
    {
        CloseAll();
        buyArmorUI.SetActive(true);
    }
    public void AccBuy()
    {
        CloseAll();
        buyAccessoryUI.SetActive(true);
    }
    public void ConItemBuy()
    {
        CloseAll();
        buyConItemUI.SetActive(true);
    }

    public void PlusQuantity()
    {
        num++;
        number.text = string.Format("{0}", num);
        buyNamePriceText.text = string.Format("이름: {0}\n가격: {1}", itemName, price * num);
    }

    public void MinusQuantity()
    {
        if (num <= 0) return;

        num--;
        number.text = string.Format("{0}", num);
        buyNamePriceText.text = string.Format("이름: {0}\n가격: {1}", itemName, price * num);
    }

    private void Awake()
    {
        TableMgr.Instance.CheckLoad();
    }

    public void Cancel()
    {
        buyPanel.SetActive(false);
        sellPanel.SetActive(false);
    }

    public void SlotClick(ref string _name, ref int _price, ref int _id)
    {
        num = 1;
        if (isBuy == true)
        {
            itemName = _name;
            price = _price;
            id = _id;
            buyNamePriceText.text = string.Format("이름: {0}\n가격: {1}", itemName, price);
            number.text = string.Format("{0}", num);
            buyPanel.SetActive(true);
        }
        else
        {
            itemName = _name;
            price = _price;
            id = _id;
            sellNamePriceText.text = string.Format("이름: {0}\n가격: {1}", itemName, price * 0.6);

            sellPanel.SetActive(true);
        }

    }

    public void BuyConfirm()
    {
        int _balance = 0;
        _balance = PartyManager._instance.poketMoney;
        int calcu = _balance - (num * price);

        if (calcu < 0)
        {
            confirmPanel.GetComponentInChildren<Text>().text = "Fail.";
            confirmPanel.SetActive(true);
            Cancel();
            return;
        }

        confirmPanel.GetComponentInChildren<Text>().text = "Success.";
        confirmPanel.SetActive(true);

        PartyManager._instance.poketMoney = calcu;

        PartyManager._instance.SetInventoryItem(id, num);

        StoreMng.ins.invenOBJ.amount = num;
        Shop._instance.BuyItem();

        // 금액 내용 기입
        StoreMng.ins.setMoney();
        Cancel();
    }

    public void SellConfirm()
    {
        int _balance = PartyManager._instance.poketMoney;
        int calcu = _balance + ((int)(0.6 * price));

        PartyManager._instance.poketMoney = calcu;
        PartyManager._instance.DumpedItem(id, 1);

        Inven._instance.RemoveItemSlot();
        StoreMng.ins.setMoney();
        Cancel();
    }
    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡGuild
    //public void CancellationBtn()
    //{
    //    int index = GuildMng._instance.mngObj.characterList.IndexOf(player);
    //    PartyManager._instance.Cancellation(index);
    //}
    //public void RecuperateBtn()
    //{
    //    int index = GuildMng._instance.mngObj.characterList.IndexOf(player);
    //    PartyManager._instance.ActiveRecuperate(index);
    //}
    //public void CreateCharacter()
    //{
    //    PartyManager._instance.CreateChracter(1);
    //}
    //public void SlotClick(PlayerCharacter _player)
    //{
    //    detailMenu.SetActive(true);      // 캐릭터 클릭시 휴양과 말소를 띄운다.    
    //    player = _player;
    //}
}
