using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum LoadingState
{
    Loading,
    Finish
}

public class Encounter : MonoBehaviour
{
    public float maxGauge = 100.0f;
    public float currentGauge = 0.0f;
    public Image gaugeImage;
    AsyncOperation asyncLoad = null;
    public GameObject fadeScreen;
    public RectTransform directionArrowImage;
    public LoadingState loadingState = LoadingState.Finish;

    void Start()
    {
        transform.position = SceneChanger.instance.playerCameraPosition;
        transform.eulerAngles = SceneChanger.instance.playerCameraRotation;
        Camera.main.transform.localEulerAngles = new Vector3(0, 0, 0);
        directionArrowImage.anchoredPosition = SceneChanger.instance.startPosition;
        directionArrowImage.GetComponent<PlayerArrowTrigger>().playerPos = SceneChanger.instance.directionArrowPos;
        directionArrowImage.transform.localEulerAngles = SceneChanger.instance.directionArrowRotation;
    }

    public void ChangeColor()
    {
        currentGauge += 100 / SceneChanger.instance.mapSize;

        float ratio = currentGauge / maxGauge;

        gaugeImage.color = new Color(ratio, 0f, 0f);

        if (ratio >= 1.0f)
        {
            gaugeImage.color = new Color(0f, 0f, 0f);
			SceneChanger.instance.spawnCase = SpawnCase.One;

			LoadBattleScene ();
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
			SceneChanger.instance.spawnCase = SpawnCase.One;

            LoadBattleScene();
        }
    }

    public void LoadBattleScene()
    {
		
        StartCoroutine(WaitSeconds(1.5f));
    }

    IEnumerator WaitSeconds(float seconds)
    {
        loadingState = LoadingState.Loading;


        GetComponent<PlayerMove>().isMoving = false;
        GetComponent<PlayerMove>().isRotating = false;

        DissolveController dissolveController = fadeScreen.GetComponent<DissolveController>();
        if(dissolveController.currentState != DissolveState.UnDissolve)
            dissolveController.StartDissolve(DissolveState.UnDissolve, 1.5f);

        SceneChanger.instance.FindGameObjects();

        yield return new WaitForSeconds(1.5f);

        if (asyncLoad == null)
            asyncLoad = SceneManager.LoadSceneAsync("Battle " + SceneChanger.instance.floor, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        currentGauge = 0;
        asyncLoad = null;
        loadingState = LoadingState.Finish;

        SceneChanger.instance.SceneChange();
    }
}
