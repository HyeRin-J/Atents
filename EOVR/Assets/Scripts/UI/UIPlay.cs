using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlay : MonoSingletonBase<UIPlay>
{
    public UIDetailInfo detailInfo;
    public GameObject teamCharBtnList;
    //public GameObject teamCharBtnList;
    public Text teamText1;
    public Text teamText2;
    public Text teamText3;
    public Text teamText4;
    public Text teamText5;
    public Text teamText6;
    public UICharacterList charList;
    public Text statsText;
    int characterNum;

    private void Start()
    {
        detailInfo.Close();
        charList.Close();
        detailInfo.Close();
    }

    public void Click_Confirm()
    {
        PartyManager._instance.CreateChracter(characterNum);
        Debug.Log(characterNum);
    }

    public Sprite[] charSprite = new Sprite[0];
    public Image charImage;

    public void ChangeCharImage(int num)
    {
        characterNum = num;
        switch (num)
        {
            case 0:
                charImage.sprite = charSprite[0];
                break;
            case 1:
                charImage.sprite = charSprite[1];
                break;
            case 2:
                charImage.sprite = charSprite[2];

                break;
            case 3:
                charImage.sprite = charSprite[3];
                break;
            case 4:
                charImage.sprite = charSprite[4];
                break;
        }

    }

    public void ClickChar(int _char)
    {
        Character_StatsRecord pc = TableMgr.Instance.character_StatsTable.GetRecord(_char);

        statsText.text = "HP: " + pc.HP + "\nTP: " + pc.TP + "\nSTR: " + pc.STR + "\nINT: " + pc.INT + "\nVIT: " + pc.VIT
                + "\nWIS: " + pc.WIS + "\nAGI: " + pc.AGI + "\nLUC: " + pc.LUC;
    }

    public void Close()
    {
        detailInfo.Close();
        charList.Close();
    }

    public void ClickPartyCall()
    {

    }
}
