using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<DialogueTrigger>().Invoke("TriggerDialogue", 0);
    }
	
}
