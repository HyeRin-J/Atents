using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyList : MonoBehaviour
{
    public Button party1;
    public Button party2;
    public Button party3;
    public Button party4;
    public Button party5;

    void OnClick_1()
    {
        PartyManager._instance.SetPartyList(1);
    }

    void OnClick_2()
    {
        PartyManager._instance.SetPartyList(2);
    }

    void OnClick_3()
    {
        PartyManager._instance.SetPartyList(3);
    }

    void OnClick_4()
    {
        PartyManager._instance.SetPartyList(4);
    }

    void OnClick_5()
    {
        PartyManager._instance.SetPartyList(5);
    }

    private void Awake()
    {
        party1.onClick.AddListener(OnClick_1);
        party2.onClick.AddListener(OnClick_2);
        party3.onClick.AddListener(OnClick_3);
        party4.onClick.AddListener(OnClick_4);
        party5.onClick.AddListener(OnClick_5);
    }

}
