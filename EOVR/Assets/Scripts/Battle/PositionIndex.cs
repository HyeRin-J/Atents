using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PosIndex
{
    first = 0,
    second = 1,
    third  =2,
    forth = 3,
    fifth = 4,
    sixth = 5
}

public class PositionIndex : MonoBehaviour {

    public PosIndex posindex = PosIndex.first;
    public GameObject characterPrefab;
    public PlayerCharacter playerInfo;
    int i = 0;
    public ParticleSystem[] effects;

	// Use this for initialization
	void Start ()
    {
		foreach(var obj in PartyManager._instance.gameObject.GetComponentsInChildren<PlayerCharacter>())
        {
            if ((int)posindex == obj.partyPosition)
            {
                Instantiate(characterPrefab, transform);
                playerInfo = obj;
                break;
            }
            else
            {
                i++;
            }
        }
        if (i >= PartyManager._instance.playableCharacter.Length) gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
