using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StatIndex
{
    first = 0,
    second = 1,
    third = 2,
    forth = 3,
    fifth = 4,
    sixth = 5
}

public class StatusIndex : MonoBehaviour
{

    public StatIndex statIndex = StatIndex.first;

    public GameObject battleManager;
    public BattlePlayer battlePlayer;
    public PlayerCharacter playerCharacter;

    public Text[] statusText;

    private void OnEnable()
    {
        statusText = gameObject.GetComponentsInChildren<Text>();

        //StatusCheck();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBuffStatus()
    {
        int i = 0;

        while (i < statusText.Length - 1)
        {
            statusText[++i].text = "------";
            statusText[++i].text = "-";
        }

        statusText[0].text = playerCharacter.characterName;
        List<BattlePlayer.BuffSkillsInfo> buffSkillsInfo = battlePlayer.buffSkills;

        if (playerCharacter != null && buffSkillsInfo.Count > 0)
        {
            i = 0;
            foreach (var buff in buffSkillsInfo)
            {
                statusText[++i].text = buff.buffs.Name;
                statusText[++i].text = string.Format("{0}", buff.duration);
            }
        }
    }

    public void SetDebuffStatus()
    {
        int i = 0;

        while (i < statusText.Length - 1)
        {
            statusText[++i].text = "------";
            statusText[++i].text = "-";
        }

        statusText[0].text = playerCharacter.characterName;
        List<BattlePlayer.DebuffSkillsInfo> debuffSkillsInfo = battlePlayer.debuffSkills;
        if (playerCharacter != null && debuffSkillsInfo.Count > 0)
        {
            i = 0;
            foreach (var debuff in debuffSkillsInfo)
            {
                statusText[++i].text = debuff.debuffs.MonSkillName;
                statusText[++i].text = string.Format("{0}", debuff.duration);
            }
        }
    }

    public void StatusCheck()
    {
        if (battleManager.GetComponent<BattleUIManager>().playerPos[(int)statIndex].transform.childCount == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);

            battlePlayer = battleManager.GetComponent<BattleUIManager>().playerPos[(int)statIndex].transform.GetChild(0).GetComponent<BattlePlayer>();
            playerCharacter = battlePlayer.playerInfo;

            battleManager.GetComponent<BattleUIManager>().statusList.Add(gameObject);
        }
    }
}
