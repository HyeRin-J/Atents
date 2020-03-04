using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDetailInfo : MonoBehaviour
{
    public Button btnRecuperate;
    public Button btnCancellation;

    UICharSlot slot = null;

    public void CancellationBtn()
    {
        PartyManager._instance.Cancellation(slot.playerChar);
        UIPlay.Instance.charList.ListDestroy(slot);
        Close();
    }

    public void RecuperateBtn()
    {
        PartyManager._instance.ActiveRecuperate(slot.playerChar);
        Close();
    }

    private void Awake()
    {
        btnRecuperate.onClick.AddListener(RecuperateBtn);
        btnCancellation.onClick.AddListener(CancellationBtn);
    }

    public void Open(UICharSlot _slot)
    {
        gameObject.SetActive(true);
        slot = _slot;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
