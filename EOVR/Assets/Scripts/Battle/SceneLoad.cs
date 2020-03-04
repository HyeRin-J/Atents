using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {
    float startTime = 0.0f;
    SceneChanger sceneChanger;
    public GameObject mainCamera;
    public GameObject uiCanvas;

    private void Awake()
    {
        StartCoroutine(MainCameraWait());
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(gameObject.name);
        if(Time.time - startTime >= 1.0f)
        {
            if (sceneChanger == null)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Battle"));
                sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>() != null ? GameObject.Find("SceneChanger").GetComponent<SceneChanger>(): null;
            }

            ////임시로 배틀씬 강제종료
            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    if (sceneChanger != null)   sceneChanger.SceneChange();
            //    SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            //}
        }      
	}

    IEnumerator MainCameraWait()
    {
        mainCamera.SetActive(false);
        uiCanvas.SetActive(false);
        yield return new WaitForSeconds(1.4f);
        mainCamera.SetActive(true);
        uiCanvas.SetActive(true);
    }
}
