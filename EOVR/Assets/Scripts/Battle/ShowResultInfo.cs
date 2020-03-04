using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResultNum
{
    CharacterResultFirst = 0,
    CharacterResultSecond = 1,
    CharacterResultThird,
    CharacterResultForth,
    CharacterResultFifth,
}

public class ShowResultInfo : MonoBehaviour {

    public ResultNum resultNum = ResultNum.CharacterResultFirst;
    public GameObject battleUIManager;
    BattleUIManager battleUI;
    public Slider expSlider;
    public GameObject characterImages;
    public Image characterPort;
    IdentifyScript characterImage;
    BattlePlayer battlePlayer;
    public Text[] resultText;

	// Use this for initialization
	void Start () {
        
	}

    private void OnEnable()
    {
        resultText = gameObject.GetComponentsInChildren<Text>();
        expSlider = gameObject.GetComponentInChildren<Slider>();
        characterImage = characterImages.GetComponentsInChildren<IdentifyScript>()[(int)resultNum];
        
        battleUI = battleUIManager.GetComponent<BattleUIManager>();

        if ((int)resultNum + 1 <= battleUI.players.Length)
        {
            battlePlayer = battleUI.players[(int)resultNum].GetComponent<BattlePlayer>();
            characterPort = characterImage.gameObject.GetComponentInChildren<Mask>().gameObject.GetComponent<Image>();
        }
            
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ShowResult()
    {
        if (battlePlayer != null)
        {
            battlePlayer.playerInfo.CurrentExp += (battleUI.totalExp / battleUI.players.Length);
            while (battlePlayer.playerInfo.CurrentExp > battlePlayer.playerInfo.nextLevelNeedExp)
            {
                battlePlayer.playerInfo.LevelUp();
            }

            resultText[0].text = "Lv";
            resultText[1].text = string.Format("{0}", battlePlayer.playerInfo.level); 
            resultText[2].text = battlePlayer.lineUIText[1].text;
            resultText[3].text = "Next : ";
            resultText[4].text = string.Format("{0}", (battlePlayer.playerInfo.nextLevelNeedExp - battlePlayer.playerInfo.CurrentExp));
            expSlider.value = ((float)battlePlayer.playerInfo.CurrentExp / (float)battlePlayer.playerInfo.nextLevelNeedExp);

            characterPort.sprite = battlePlayer.characterPortrait;
        }

        else
        {
            gameObject.SetActive(false);
            characterImage.gameObject.SetActive(false);
        }
    }
}
