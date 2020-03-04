using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultInfo : MonoBehaviour {

    public BattleMonster[] monsters;
    public float totalEXP;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        monsters = gameObject.GetComponentsInChildren<BattleMonster>();

        SetTotalExp();
    }

    void SetTotalExp()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            totalEXP += monsters[i].monsterCharacter.monStatRecord.Exp;
        }
    }
}
