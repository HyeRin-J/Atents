using MonData;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum monsterProperties
{
    MonsterAllSkills = 108,
    MonsterAllNumbers = 45,
}

namespace MonsterCharacterNameSpace
{
    public class Monstercharacter
    {
        #region 몬스터 정보 변수
        public MonsterCharacterData.MonsterClass monClass; //몬스터 클래스
        public Monster_StatRecord monStatRecord;           //몬스터 스탯 레코드
        public Monster_SkillsRecord monSkillRecord;      //몬스터 스킬정보
        public MSkillData mSkillData;                      //몬스터 스킬 데이터
        public MonsterCharacterData.Mstats monStats;       //몬스터 스탯
        public MonsterCharacterData.MResist mResist;       //몬스터 상태이상유무

        //public Dictionary<int, Monster_SkillsRecord> monsterSkillList = new Dictionary<int, Monster_SkillsRecord>(); //몬스터들의 모든스킬리스트참조변수

        Dictionary<int, int> monsterIDWithSkills = new Dictionary<int, int>();
        //몬스터들의 스킬을 리스트 식으로 만든 딕셔너리(0, 100 등등)  

        public List<int> monterLearnSkillNumLists = new List<int>();  //몬스터가 배우고 있는 스킬 번호 리스트

        public List<string> monterLearnSkillNameLists; //몬스터가 배우고 있는 스킬 이름 리스트

        //스킬 레코드 가져옴


        #endregion
        public Monstercharacter()
        { }

        public Monstercharacter(int mID)
        {
            //몬스터 클래스 지정
            if (mID < 200) monClass = MonsterCharacterData.MonsterClass.Normal;
            else if (mID < 300) monClass = MonsterCharacterData.MonsterClass.BigMonster;
            else if (mID < 400) monClass = MonsterCharacterData.MonsterClass.FOE;
            else monClass = MonsterCharacterData.MonsterClass.BOSS;

            //스탯 레코드 가져옴
            monStatRecord = TableMgr.Instance.monster_StatTable.GetRecord(mID);

            //스킬 레코드 가져옴
            //GetSkillNumData(mID);

            //처음부터 learnskilllist

        }

        #region Setter

        //몬스터 데이터 세팅
        public void SetMonster(int MaxHp, int Patk, int Matk, int Pdef, int Mdef)
        {
            monStats.Hp = MaxHp;
            monStats.pAtk = Patk;
            monStats.mAtk = Matk;
            monStats.pDef = Pdef;
            monStats.mDef = Mdef;
        }

        //public void SetMonsterSkills()
        //{
        //    //for문으로 스킬리스트에 모든스킬 정보를 받게 해는게 좋을듯 ?
        //    for (int i = 0; i < (int)monsterProperties.MonsterAllSkills; i++)
        //    {
        //        monsterIDWithSkills.Add(i, monSkillRecord.UseMonsterID);
        //    }



        //}

        //public void MonsterSkillSetting(int selectedMonster)
        //{
        //    //딕셔너리를 통해 스킬넘버를 받아서, 이 몬스터번호와 usemonsterID가 같은 스킬을 monsterlearnskillList리스트에 넣어버림

        //    //monsterSkillList.ContainsKey(monSkillRecord.UseMonsterID)
        //    //monSkillRecord.UseMonsterID
        //    monterLearnSkillLists.Clear();
        //    var _var = monsterSkillList.GetEnumerator();
        //    while( _var.MoveNext())
        //    {
        //        if( _var.Current.Value.UseMonsterID == selectedMonster)
        //        {
        //            monterLearnSkillLists.Add(_var.Current.Value.nID);
        //        }
        //    }     
        //}
        #endregion

        #region Getter
        //public void GetSkillNumData(int monsterID)
        //{
        //    for (int i = 0; i < monsterIDWithSkills.Count; i++)
        //    {
        //        if (monsterIDWithSkills.ContainsValue(monsterID))
        //        {


        //        }
        //    }

        //}

        #endregion
    }
}


