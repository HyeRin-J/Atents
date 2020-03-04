using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPosition : MonoBehaviour {

    public bool isMoveActive = false;

    public GameObject[] positionArray;
    public GameObject[] characterArray;

    public GameObject battleManager;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //isMoveActive = battleManager.GetComponent<BattleManager>().lineUIActive;

        LineUIState();
    }

    public void LineUIState()
    {
        if (isMoveActive == false)
        {
            for (int i = 0; i < positionArray.Length; i++)
            {
                if (positionArray[i].transform.childCount == 0)
                {
                    positionArray[i].SetActive(false);
                }
            }
        }

        else if (isMoveActive == true)
        {
            for (int i = 0; i < positionArray.Length; i++)
            {
                positionArray[i].SetActive(true);
            }
        }
    }
}
