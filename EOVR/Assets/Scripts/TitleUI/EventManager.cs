using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {
    // https://www.youtube.com/watch?v=_nRzoTzeyxU 참고
    static EventManager _instance;
    public static EventManager instance
    {
        get { return _instance; }
    }

    public Text nameText;
    public Text dialogueText;
    public GameObject nextText;
    private Queue<string> sentences;

    public GameObject dialogueBox;

    [HideInInspector] public bool isEvent = false;
    [HideInInspector] public bool isTutorialDo = false;

    FadeState currentState = FadeState.Finished;
    // Use this for initialization
    void Start () {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this);

        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && nextText.activeInHierarchy == true)
        {
            DisplayNextSentence();
        }
    }

    // 대화 시작시 처음 호출되는 함수
    public void StartDialogue(Dialogue dialogueText)
    {
        nextText.SetActive(false);
        dialogueBox.SetActive(true);

        nameText.text = dialogueText.name;

        sentences.Clear();

        foreach (string sentence in dialogueText.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // 처음문장부터 차례대로 문장을 호출하는 함수
    public void DisplayNextSentence()
    {
        nextText.SetActive(false);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        //StopAllCoroutines();
        StartCoroutine(TypingSentence(sentence));
    }

    // 글자를 하나씩 타이핑하여 나타나는 효과
    IEnumerator TypingSentence(string sentenceText)
    {
        dialogueText.text = "";
        foreach(char letter in sentenceText.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        nextText.SetActive(true);
        yield break;
    }

    void EndDialogue()
    {
        //Debug.Log("EndDialogue");
        dialogueText.text = "";
        dialogueBox.SetActive(false);
    }

    public void OpeningEvent()
    {
        StartCoroutine(OpeningTextEvent(1));
    }
    IEnumerator OpeningTextEvent(float duration)
    {
        float elapsedTime = 0.0f;
        Text[] faderText = EOVR.SceneManager.instance.loadingImage.GetComponentsInChildren<Text>();
        for (int i = 0;i < faderText.Length; i++) {
            Color color = faderText[i].color;
            elapsedTime = 0.0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;

                    color.a = Mathf.Lerp(0, 1, elapsedTime / duration);

                faderText[i].color = color;
                yield return null;
            }
            color.a = 1.0f;
            faderText[i].color = color;

            yield return new WaitForSeconds(1);
        }

            Color color1 = faderText[0].color;
            Color color2 = faderText[1].color;
            Color color3 = faderText[2].color;
            elapsedTime = 0.0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;

                color1.a = Mathf.Lerp(1, 0, elapsedTime / duration);
                color2.a = Mathf.Lerp(1, 0, elapsedTime / duration);
                color3.a = Mathf.Lerp(1, 0, elapsedTime / duration);

                faderText[0].color = color1;
                faderText[1].color = color2;
                faderText[2].color = color3;
                yield return null;
            }
            color1.a = 0.0f;
            color2.a = 0.0f;
            color3.a = 0.0f;
            faderText[0].color = color1;
            faderText[1].color = color2;
            faderText[2].color = color3;

        isEvent = false;
        yield break;
    }
}
