using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;

public class TestPlayerSetting : MonoBehaviour {

    public void Start()
    {
        TableMgr.Instance.CheckLoad();
        
        
        //gameObject.GetComponent<PlayerCharacter>().characterName = "What";
        //gameObject.GetComponent<PlayerCharacter>().SetPartyJoin();
        //gameObject.GetComponent<PlayerCharacter>().partyPosition = 1;
        //PartyManager._instance.GetLevelUpStat(gameObject, CharacterData.CHARACTERCLASS.SWORDMAN, 10);
        PartyManager._instance.SetInventoryItem(10101, 6);
        PartyManager._instance.SetInventoryItem(20101, 2);
        PartyManager._instance.SetInventoryItem(30007, 2);
        PartyManager._instance.SetInventoryItem(40007, 5);
        PartyManager._instance.SetInventoryItem(40003, 10);
        PartyManager._instance.SetInventoryItem(50118, 3);
        
    }
}
