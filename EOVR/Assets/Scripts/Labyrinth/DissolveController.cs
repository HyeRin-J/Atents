using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DissolveState
{
    Normal,
    Dissolve,
    UnDissolve
}

public class DissolveController : MonoBehaviour
{

    // 사라지거나 나타나는데에 걸리는 시간
    public float duration = 1.0f;

    // 현재 상태
    public DissolveState currentState = DissolveState.Dissolve;
    public DissolveState dissolveState
    {
        get { return currentState; }
    }

    float currentIntensity = 1.0f;
    float currentBurnSize = 0.0f;
    float elapsedTime = 0.0f;
    public float maxBurnSize = 0.2f;
    public Material dissolveMaterial;

    // Use this for initialization
    void Start()
    {
        dissolveMaterial = GetComponent<Renderer>().material;
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
    }

    void OnEnable()
    {
        dissolveMaterial = GetComponent<Renderer>().material;      
        dissolveMaterial.color = new Color(0, 0, 0, 0);
        currentState = DissolveState.Dissolve;
        currentIntensity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        dissolveMaterial.SetFloat("_DissolveIntensity", currentIntensity);
        dissolveMaterial.SetFloat("_DissolveEdgeRange", currentBurnSize);
    }

    IEnumerator Dissolve(DissolveState state, float duration)
    {
        currentState = state;
        elapsedTime = 0.0f;

        //float delay = dissolveMaterial.GetFloat("_Delay");

        while (elapsedTime <= duration)
        {
            float amount = Mathf.Lerp(0.0f, 1.0f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;

            if (currentState == DissolveState.UnDissolve)
            {
                currentIntensity = 1.0f - amount;
            }

            else
            {
                currentIntensity = amount;
            }

            currentBurnSize = Mathf.Clamp((currentIntensity) * 0.5f, 0, maxBurnSize);
            yield return null;
        }
        currentIntensity = currentState == DissolveState.UnDissolve ? 0.0f : 1.0f;

        currentState = DissolveState.Dissolve;

        Debug.Log(currentState + "Finished");
        yield break;
    }

    public void StartDissolve(DissolveState dissolveState, float duration)
    {
        StartCoroutine(Dissolve(dissolveState, duration));
    }
}