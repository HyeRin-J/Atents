using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EOVR;
//using UnityEngine.SceneManagement;

public class MainStartInput : MonoBehaviour
    {
        public float rotationSpeed;
        bool isGetkey = false;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(0, rotationSpeed, 0);

            if (isGetkey) return;

            if (Input.GetKeyDown("space"))
            {
                isGetkey = true;
                EventManager.instance.isEvent = true;
                rotationSpeed = 2f;
                //UnityEngine.SceneManagement.SceneManager.LoadScene("Village");
                SceneManager.instance.ChangeScene("Scene_Guild");
                //SceneManager.instance.ChangeScene("Village");
            }
        }
    }

