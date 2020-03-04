using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapData : MonoBehaviour
{
    public int mapSize = 20;
    public GameObject fadeScreen;
    AsyncOperation asyncLoad;
    public int floor;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(WaitUntilBattleSceneLoading());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitUntilBattleSceneLoading()
    {
        asyncLoad = SceneManager.LoadSceneAsync("Battle " + floor, LoadSceneMode.Additive);

        DissolveController dissolveController = fadeScreen.GetComponent<DissolveController>();

        dissolveController.StartDissolve(DissolveState.UnDissolve, 0.3f);

        SceneChanger.instance.playerObj.GetComponent<PlayerMove>().enabled = false;

        while(asyncLoad.isDone == false)
        {
            yield return null;
        }

        if (asyncLoad.isDone != false && asyncLoad != null)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Battle " + floor));
            asyncLoad = null;
            dissolveController.StartDissolve(DissolveState.Dissolve, 1f);            
        }

        yield return new WaitForSeconds(1f);
        SceneChanger.instance.playerObj.GetComponent<PlayerMove>().enabled = true;
    }
}
