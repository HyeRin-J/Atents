using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerData;

public enum CurrentActionState
{
    None = 0,
    Attack = 1,
    Skill,
    Defend,
    Item,
    Switch,
    Escape,
}

public enum PlayerNum
{
    FirstPlayer = 0,
    SecondPlayer = 1,
    ThirdPlayer,
    ForthPlayer,
    FifthPlayer,
}


public class BattlePlayer : MonoBehaviour
{
    public struct BuffSkillsInfo
    {
        public int duration;
        public int skillLevel;
        public Character_SkillsRecord buffs;
    }

    public struct DebuffSkillsInfo
    {
        public int duration;
        public Monster_SkillsRecord debuffs;
    }

    public CurrentActionState currentActionState = CurrentActionState.None;
    public GameObject[] targetedMonsters = new GameObject[5];
    public GameObject[] targetedPlayers = new GameObject[5];
    public Character_SkillsRecord selectedSkill;
    public ConItemRecord selectedItem;

    public PlayerNum playerNum = PlayerNum.FirstPlayer;
    public GameObject playerManager; // 알아서 찾아올수 있게 바꾸자

    public Sprite characterPortrait;

    public PlayerCharacter playerInfo;
    public Text[] lineUIText;
    public Image[] gaugeBar;
    public Dictionary<int, Character_SkillsRecord> skills;
    CharacterData.Stats stats;

    public int damage;      //데미지량
    public int healAmount;  //힐량
    public int flowHp;  //오버힐 용 hp 증가량

    public List<BuffSkillsInfo> buffSkills = new List<BuffSkillsInfo>();
    public List<DebuffSkillsInfo> debuffSkills = new List<DebuffSkillsInfo>();

    public int selectedSpeed;

    public ParticleSystem[] effects;

    // Use this for initialization
    void Start()
    {

        playerManager = GameObject.FindGameObjectWithTag("PlayerManager");

        if (playerManager != null)
        {
            playerInfo = GetComponentInParent<PositionIndex>().playerInfo;
        }

        effects = GetComponentInParent<PositionIndex>().effects;

        lineUIText = gameObject.GetComponentsInChildren<Text>();
        characterPortrait = playerInfo.gameObject.GetComponent<CharacterImage>().characterPortrait;

        int i = 0;

        foreach (Image obj in GetComponentsInChildren<Image>())
        {
            if (obj.CompareTag("GaugeBar"))
            {
                gaugeBar[i] = obj;
                i++;
            }
        }
        stats = playerInfo.GetCharacterStats();
        skills = playerInfo.GetSkillList();
        //버프 스킬 테스트용 임시
        /*
        BuffSkillsInfo tempBuff = new BuffSkillsInfo();

        Character_SkillsRecord tempSkill = TableMgr.Instance.character_SkillsTable.GetRecord(1131);
        tempBuff.duration = 3;
        tempBuff.buffs = tempSkill;

        buffSkills.Add(tempBuff);

        tempSkill = TableMgr.Instance.character_SkillsTable.GetRecord(2121);
        tempBuff.duration = 3;
        tempBuff.buffs = tempSkill;

        buffSkills.Add(tempBuff);

        Monster_SkillsRecord tempdeSkill = TableMgr.Instance.monster_SkillsTable.GetRecord(513);
        DebuffSkillsInfo tempDebuffSkill = new DebuffSkillsInfo();

        tempDebuffSkill.duration = 3;
        tempDebuffSkill.debuffs = tempdeSkill;

        debuffSkills.Add(tempDebuffSkill);
        */
    }

    //정보 갱신
    public void SetText()
    {
        if (playerManager != null)
        {
            lineUIText[0].text = string.Format("{0}", playerInfo.level);
            lineUIText[1].text = string.Format("{0}", playerInfo.characterName);
            lineUIText[2].text = "H P";
            lineUIText[3].text = string.Format("{0}", playerInfo.currentHp);
            lineUIText[4].text = "T P";
            lineUIText[5].text = string.Format("{0}", playerInfo.currentTp);
            gaugeBar[0].fillAmount = (float)playerInfo.currentHp / (float)stats.MAXHP;
            gaugeBar[1].fillAmount = (float)playerInfo.currentTp / (float)stats.MAXTP;
        }
    }

    //targetedMonsters 안에 null이 있을 때 하나씩 당겨줌
    public void TargetedMonsterHasNull()
    {
        List<GameObject> tempMonster = new List<GameObject>();

        if (selectedSkill.AreaType != SkillData.AREATYPE.Single)
        {    
            for (int i = 0; i < targetedMonsters.Length; i++)
            {
                if (targetedMonsters[i] != null)
                {
                    tempMonster.Add(targetedMonsters[i]);
                }
            }

            targetedMonsters = new GameObject[tempMonster.Count];

            for (int i = 0; i < tempMonster.Count; i++)
            {
                targetedMonsters[i] = tempMonster[i];
            }
        }
        else
        {
            if(targetedMonsters[0] == null)
                targetedMonsters = new GameObject[1];
        }
    }
}