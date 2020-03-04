using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Mouse1))
    //    {
    //        EventManager.instance.DisplayNextSentence();
    //    }
    //}

    public void TriggerDialogue()
    {
        EventManager.instance.StartDialogue(dialogue);
    }
}
