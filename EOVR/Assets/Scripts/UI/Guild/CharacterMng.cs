using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMng : MonoBehaviour
{
    public List<PlayerCharacter> characterList;
    public GameObject characterSlot;
    public GameObject panel;

    public void GuildCharacter()
    {
        characterList = PartyManager._instance.GetCharacterList();

        UIPlay.Instance.charList.Open(characterList, OnDetailInfo);
    }

    public void PartyListConfirm()
    {

    }

    public void OnDetailInfo(UICharSlot _slot )
    {
        if (null == _slot)
            return;
        UIPlay.Instance.detailInfo.Open(_slot);
    }
}
