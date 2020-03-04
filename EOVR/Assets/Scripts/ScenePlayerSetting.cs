using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlayerSetting : MonoBehaviour {

    public GameObject PlayerObj;

    private void Awake()
    {
        SceneChanger.instance.playerObj = PlayerObj;

        SceneChanger.instance.SetPlayerPosition();
    }

}
