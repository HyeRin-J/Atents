using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EOVR
{

    public enum LoadingState
    {
        Loading,
        LoadFinished,
    }

    public class SceneManager : MonoBehaviour
    {
        public static SceneManager instance = null;
        //public static SceneManager _instance
        //{
        //    get { return instance; }
        //}
        public GameObject loadingImage;
        public float faderTime = 2.0f;

        public LoadingState loadingState = LoadingState.LoadFinished;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void ChangeScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            loadingState = LoadingState.Loading;

            loadingImage.SetActive(true);

            Fader fader = loadingImage.GetComponent<Fader>();
            fader.StartFade(FadeState.FadeOut, faderTime);

            while (fader.fadeState != FadeState.Finished)
                yield return null;

            #region 튜토리얼 이벤트 실행 여부
            if (EventManager.instance.isTutorialDo == false)
                EventManager.instance.OpeningEvent();
            #endregion
            #region  이벤트 진행중 실행대기 여부
            // 만약 이벤트 진행중이라면 이벤트가 끝날때까지 대기
            while (EventManager.instance.isEvent == true)
            {
                yield return null;
            }
            #endregion

            AsyncOperation loadOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

            while (loadOperation.isDone == false)
            {
                yield return null;
            }

            if (loadOperation.isDone)
            {
                fader.StartFade(FadeState.FadeIn, faderTime);
            }

            while (fader.fadeState != FadeState.Finished)
                yield return null;

            // Finish
            loadingImage.SetActive(false);

            loadingState = LoadingState.LoadFinished;

            Destroy(gameObject);
        }
    }
}
