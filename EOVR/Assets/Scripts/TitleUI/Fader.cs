using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FadeState
{
    FadeIn,
    FadeOut,
    Finished
}

public class Fader : MonoBehaviour {

    FadeState currentState = FadeState.Finished;
    public FadeState fadeState
    {
        get { return currentState; }
    }

    IEnumerator Fade(FadeState state, float duration)
    {
        GetComponent<Image>().raycastTarget = true;
        currentState = state;
        float elapsedTime = 0.0f;
        Color color = GetComponent<Image>().color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            
            if (currentState == FadeState.FadeIn)
                color.a = Mathf.Lerp(1, 0, elapsedTime / duration);
            else
                color.a = Mathf.Lerp(0, 1, elapsedTime / duration);

            GetComponent<Image>().color = color;
            yield return null;
        }
        color.a = currentState == FadeState.FadeIn ? 0.0f : 1.0f;
        GetComponent<Image>().color = color;

        currentState = FadeState.Finished;

        GetComponent<Image>().raycastTarget = false;
        yield break;
    }

    public void StartFade(FadeState fadeState, float duration)
    {
        StartCoroutine(Fade(fadeState, duration));
    }
}
