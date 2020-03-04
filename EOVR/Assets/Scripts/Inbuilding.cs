using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inbuilding : MonoBehaviour {

    public GameObject WorldButton;

    private void OnTriggerEnter(Collider other)
    {
        WorldButton.SetActive(true);
        //SceneChanger.instance.lastTr = other.transform;
        SceneChanger.instance.tempPos = new Vector3 (transform.position.x, other.transform.position.y, transform.position.z);
        SceneChanger.instance.tempRotation = transform.rotation;
    }

    private void OnTriggerExit(Collider other)
    {
        WorldButton.SetActive(false);
    }

}
