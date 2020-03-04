using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDissolve : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(FadeOut());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FadeOut()
    {
        DissolveController dissolveController = gameObject.GetComponent<DissolveController>();

        dissolveController.StartDissolve(DissolveState.Dissolve, 1.5f);

        yield break;
    }
}
