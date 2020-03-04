using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MonsterVariables
{
    skillSlots =3,
    weaknessValue=6,
    statusValue=4,   
    DropItemtoMonster = 50000
}

public class MonsterUI : MonoBehaviour {

    //몬스터 별로 데이터를 받아와 일정한 입력을 받으면 몬스터의 정보를 보여주게함.

    //몬스터 기본정보
    public int defaultMonNum = 101;  //초기값
    public int selectedMonNum; //선택한 몬스터ID
    public Text mPatkB, mMatkB, mPdefB, mMdefB; //배너
    public Text mName, mHp, mPatk, mMatk, mPdef, mMdef;

    //공격저항배너 
    public Text mCutB, mMeleeB, mBashB, mFireB, mIceB, mLitB;

    //상태이상저항배너
    public Text mPosB, mPalB, mConB, mSlpB;

    //스킬명
    public Text mSkillB;
    public Text[] mSkill;

    //드랍아이템
    public Text mDropItemB, mDropItem;

    public Text[] elementResistList;
    public Text[] statusResistList;
    public Text[] monsterSkillList;

    public GameObject[] buffSkillList;
    public GameObject[] debuffSkillList;

    //public Text mCutR, mMeleeR, mBashR, mFireR, mIceR, mLitR;
    //public Text mPosR, mPalR, mConR, mSlpR;
    //Text[] statusResistList = new Text[] { mCutR, mMeleeR, mBashR, mFireR, mIceR, mLitR, mPosR, mPalR, mConR, mSlpR };

    Monster_StatRecord monUIData;
    Monster_SkillsRecord monUISkills;
    Dictionary<int, Monster_SkillsRecord> monsterSkillListOnUI = new Dictionary<int, Monster_SkillsRecord>();
    public List<string> monUISkillName = new List<string>();

    DropItemRecord monUIDrop;

    void Awake()
    {
        //초기 몬스터 데이터가 필요!(몬스터를 모를떄 데이터를 맨위로 올려서 넣을 필요가 있음)
        TableMgr.Instance.CheckLoad();
        monUIData = TableMgr.Instance.monster_StatTable.GetRecord(defaultMonNum);
        //monUISkills = TableMgr.Instance.monster_SkillsTable.GetRecord(defaultMonNum);
        monUIDrop = TableMgr.Instance.dropItemTable.GetRecord(defaultMonNum + 50000);        
    }

    void Start()
    {
        mName.text = " 몬스터 선택 필요";
        mHp.text = "HP:???";
        mPatkB.text = "ATK";
        mMatkB.text = "MATK";
        mPdefB.text = "DEF";
        mMdefB.text = "MDEF";
        mCutB.text = "참격";
        mMeleeB.text = "돌격";
        mBashB.text = "파괴";
        mFireB.text = "화염";
        mIceB.text = "빙결";
        mLitB.text = "전격";
        mSkillB.text = "스킬";
        mDropItemB.text = "드랍아이템";
        mPosB.text = "맹독";
        mPalB.text = "마비";
        mConB.text = "혼란";
        mSlpB.text = "수면";
    }

    public void MonUIActive(BattleMonster mon)
    {
        monUIData = TableMgr.Instance.monster_StatTable.GetRecord(mon.monNID);
        //monUISkills = TableMgr.Instance.monster_SkillsTable.GetRecord(chosedNum);
        monUIDrop = TableMgr.Instance.dropItemTable.GetRecord(mon.monNID + (int)MonsterVariables.DropItemtoMonster);

        mName.text = monUIData.Name;
        mHp.text = string.Format("HP: {0}", monUIData.Hp);
        mPatk.text = string.Format("{0}", monUIData.Patk);
        mMatk.text = string.Format("{0}", monUIData.Pdef);
        mPdef.text = string.Format("{0}", monUIData.Matk);
        mMdef.text = string.Format("{0}", monUIData.Mdef);

        ////스킬 불러주는 코드 필요    
        MonsterSkillSettingOnUI(mon.monNID);
        //MonsterSkills(monUISkills.UseMonsterID, (int)MonsterVariables.skillSlots);

        for(int i = 0; i < monUISkillName.Count; i++)
        {
            mSkill[i].text = monUISkillName[i];
        }

        //버프 스킬 리스트
        for (int i = 0; i < mon.buffSkills.Count; i++)
        {
            Text[] temp = buffSkillList[i].GetComponentsInChildren<Text>();
            temp[0].text = string.Format("{0}", mon.buffSkills[i].duration);
            temp[1].text = mon.buffSkills[i].buffs.MonSkillName;
        }

        //디버프 스킬 리스트
        for (int i = 0; i < mon.debuffSkills.Count; i++)
        {
            Text[] temp = debuffSkillList[i].GetComponentsInChildren<Text>();
            temp[0].text = string.Format("{0}", mon.debuffSkills[i].duration);
            temp[1].text = mon.debuffSkills[i].debuffs.Name;
        }

        //공격저항,상태이상저항 불러주는 코드          
        ElementResist(monUIData.Weakness,(int)MonsterVariables.weaknessValue);
        StatusResist(monUIData.StatusEffect, (int)MonsterVariables.statusValue);

        //드랍아이템   
        if (monUIDrop.nID - (int)MonsterVariables.DropItemtoMonster == mon.monNID)
        {
            mDropItem.text = monUIDrop.dropItem;
        }
    }

    public void MonsterSkillSettingOnUI(int selectedMonster)
    {

        //딕셔너리를 통해 스킬넘버를 받아서, 이 몬스터번호와 usemonsterID가 같은 스킬을 monsterlearnskillList리스트에 넣어버림

        monsterSkillListOnUI.Clear();
        var _var = monsterSkillListOnUI.GetEnumerator();
        while (_var.MoveNext())
        {
            if (_var.Current.Value.UseMonsterID == selectedMonster)
            {
                for (int i = 0; i < monUISkillName.Count; i++)
                {
                    monUISkillName.Add(_var.Current.Value.MonSkillName);         
                }                 
            }
        }   
    }
   
    public string ElementResist(int[] Weakness, int index)
    {
        //Weakness = monUIData.Weakness;
        if (Weakness.Length > index)
        {
            switch (Weakness[index])
            {
                case 0:
                    return "X";
                case 1:
                    return "저항";
                case 2:
                    return " ";
                case 4:
                    return "약점";
            }
        }

        for (int i = 0; i < index; i++)
        {
            elementResistList[i].text = ElementResist(Weakness, i);
        }

        return null;
    }

    public string StatusResist(int[] status, int index)
    {
        status = monUIData.StatusEffect;
        if (status.Length > index)
        {
            switch (status[index])
            { 
                case 0:
                    return "X";
                case 1:
                    return "Δ";
                case 2:
                    return "ㅇ";
                case 4:
                    return "◎";
            }
        }

        for (int i = 0; i < index; i++)
        {
           statusResistList[i].text = StatusResist(status, i);
        }

        return string.Empty;
    }
}
