using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureTilingOffset : MonoBehaviour {
    Renderer rend;
    Material imageMaterial;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
       float offset = Time.time * 0.1f;
        rend.material.mainTextureOffset = new Vector2(-offset, offset);
        //imageMaterial.mainTextureOffset = new Vector2(-offset, offset);
    }
}
