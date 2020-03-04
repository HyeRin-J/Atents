using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (EventManager.instance.isTutorialDo == false)
        {
            // 튜토리얼 실행
            GetComponent<DialogueTrigger>().Invoke("TriggerDialogue", 1);
            EventManager.instance.isTutorialDo = true;
        }
	}
	
}
