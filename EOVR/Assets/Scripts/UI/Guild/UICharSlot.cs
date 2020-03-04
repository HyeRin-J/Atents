using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharSlot : MonoBehaviour
{
    public delegate void OnClickEvent(UICharSlot _slot);
    public PlayerCharacter playerChar;
    public int index;
    public Text charName;
    public Button btnClick;

    OnClickEvent m_event;

    void OnClick_Click()
    {
        if (null != m_event)
            m_event(this);
    }

    private void Awake()
    {
        btnClick.onClick.AddListener(OnClick_Click);
    }

    public void Open(int _index, PlayerCharacter _char, OnClickEvent _event )
    {
        index = _index;
        playerChar = _char;
        charName.text = _char.characterName;
        m_event = _event;
    }
}
