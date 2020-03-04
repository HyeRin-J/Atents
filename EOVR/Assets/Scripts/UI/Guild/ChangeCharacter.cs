using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacter : MonoBehaviour
{
    public Button team_1;
    public Button team_2;
    public Button team_3;
    public Button team_4;
    public Button team_5;
    public Button team_6;

    int m_team = 1;
    int m_index = 0;
    int count = 0;

    void OnClick_1()
    {
        m_index = 1;
        Close();
    }

    void OnClick_2()
    {
        m_index = 2;
        Close();        
    }

    void OnClick_3()
    {
        m_index = 3;
        Close();
    }

    void OnClick_4()
    {
        m_index = 4;
        Close();
    }

    void OnClick_5()
    {
        m_index = 5;
        Close();
    }

    void OnClick_6()
    {
        m_index = 6;
        Close();
    }

    void Close()
    {
        UIPlay.Instance.teamCharBtnList.SetActive(false);
        UIPlay.Instance.charList.Open(PartyManager._instance.GetCharacterList(), OnEventParty);
    }


    private void Awake()
    {
        team_1.onClick.AddListener(OnClick_1);
        team_2.onClick.AddListener(OnClick_2);
        team_3.onClick.AddListener(OnClick_3);
        team_4.onClick.AddListener(OnClick_4);
        team_5.onClick.AddListener(OnClick_5);
        team_6.onClick.AddListener(OnClick_6);
    }


    void OnEventParty(UICharSlot _slot)
    {
        PartyManager._instance.AddPartyTempChar(m_index, _slot.playerChar);
    }
}
