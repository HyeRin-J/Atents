using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladar_Pointer : MonoBehaviour {

    public Transform point;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
        //레이더 회전
        transform.RotateAround(point.position, Vector3.up, 6f);
	}
}
