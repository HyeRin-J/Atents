using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonData;
using MonsterCharacterNameSpace;

public enum MonCurrentActionState
{
    None = 0,
    Attack = 1,
    Skill = 2,
}

public class BattleMonster : MonoBehaviour {

    public Monstercharacter monsterCharacter = new Monstercharacter();

    #region 몬스터 전투 변수
    public float monsterPatkRatio = 1.0f;       //몬스터 물공수치변화량(버프 디버프 모두포함)
    public float monsterMatkRatio = 1.0f;       //몬스터 마공버프
    public float monsterPdefRatio = 1.0f;       //몬스터 물방버프
    public float monsterMdefRatio = 1.0f;       //몬스터 마방버프

    //디버프 수치를 따로둘까 고민중 (변수가 좀 많아질것 같아서 일단 보류)
    //public float monsterDeBuffedPatk;         // 디버프 물공
    //public float monsterDeBuffedMatk;         // 디버프 마공
    //public float monsterDeBuffedPdef;         // 디버프 물방
    //public float monsterDeBuffedMdef;         // 디버프 마방

    public int monNID;                          //몬스터 아이디
    public int monLevel;                        //몬스터 레벨  
    public int monMaxHp;                        //몬스터 최대체력
    public int monCurHp;                        //몬스터 현재체력 
    public int monsterSelectedSpeed;            //선택된 몬스터의 속도
    public int monDamageAmount;                 //몬스터가 받는 데미지량
    public int monHealAmount;                   //몬스터가 받는 힐량

    public GameObject targetArrow;              //몬스터 지정시 몬스터 위에 화살표
    AnimatorStateInfo animatorState;            //몬스터 애니메이션 상태
    Animator animator;                          //몬스터 애니메이터

    public struct BuffSkillsInfo                //전투시 몬스터가 받는 버프스킬 정보
    {
        public int duration;
        public Monster_SkillsRecord buffs;
    }

    public struct DebuffSkillsInfo              //전투시 몬스터가 받는 디버프 스킬 정보
    {
        public int duration;
        public int skillLevel;
        public Character_SkillsRecord debuffs;
    }
    public List<BuffSkillsInfo> buffSkills = new List<BuffSkillsInfo>();                                  //몬스터가 받고 있는 버프스킬정보 리스트
    public List<DebuffSkillsInfo> debuffSkills = new List<DebuffSkillsInfo>();                            //몬스터가 받고 있는 디버프스킬정보 리스트
    #endregion
       
    #region 전투용 참조변수
    BattlePlayer battlePlayer;                   //효과를 주거나 받는 플레이어 정보
    public MonCurrentActionState monCurActionState = MonCurrentActionState.None; //몬스터 상태설정(공격,스킬)
    public int[] MonsterSkillAvailableList;

    public GameObject[] AllyMonsters = new GameObject[5]; //아군=몬스터 배열
    public GameObject[] EnemyPlayers = new GameObject[5]; //적=플레이어 배열 
    #endregion

    void Start()
    {
        monsterCharacter = new Monstercharacter(monNID);
        monsterCharacter.monStatRecord = TableMgr.Instance.monster_StatTable.GetRecord(monNID);
        monCurHp = monMaxHp = monsterCharacter.monStatRecord.Hp;
        monLevel = monsterCharacter.monStatRecord.Lv;
        targetArrow = transform.parent.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        MonsterSkillAvailableList = new int[3];

        //버프 디버프용 테스트
        /*
        BuffSkillsInfo buffSkillsInfo = new BuffSkillsInfo();
        Monster_SkillsRecord monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(505);
        buffSkillsInfo.duration = monster_Skills.Duration;
        buffSkillsInfo.buffs = monster_Skills;
        buffSkills.Add(buffSkillsInfo);

        monster_Skills = TableMgr.Instance.monster_SkillsTable.GetRecord(511);
        buffSkillsInfo.duration = monster_Skills.Duration;
        buffSkillsInfo.buffs = monster_Skills;
        buffSkills.Add(buffSkillsInfo);

        DebuffSkillsInfo debuffSkillsInfo = new DebuffSkillsInfo();
        Character_SkillsRecord character_Skills = TableMgr.Instance.character_SkillsTable.GetRecord(1132);
        debuffSkillsInfo.duration = 3;
        debuffSkillsInfo.debuffs = character_Skills;
        debuffSkills.Add(debuffSkillsInfo);
        */
    }

    void Update()
    {
        SetHpBar();
    }

    #region battle-monster에서 가져온 코드내용
    //몬스터 죽을 때 불러주는 함수
    public void Dead()
    {
        animator.SetTrigger("Dead");
        Destroy(gameObject, 1.5f);
    }

    //몬스터 빈사 상태(체력 1/4 미만)
    public void Coma()
    {
        animator.SetBool("Coma", true);
    }

    //몬스터 HPBar 갱신
    public void SetHpBar()
    {
        targetArrow.transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount = (float)monCurHp / (float)monMaxHp;
    }
    #endregion

    #region BattleMonster

    //리턴값 = 몬스터 물리공격 독립배율 
    public float CalcPhysicsIndependenceRate(GameObject player)
    {
        if (monsterCharacter.monStats.pAtk * 2 > (player.GetComponent<BattlePlayer>().playerInfo.physicalDef) / 2)
        { //monsterdependenceFrame = 1.0f;
            return (monsterCharacter.monStats.pAtk * 2 / ((player.GetComponent<BattlePlayer>().playerInfo.physicalDef) / 2)); //수치는 조정예정
        }

        else if (monsterCharacter.monStats.pAtk * 2 == (player.GetComponent<BattlePlayer>().playerInfo.physicalDef) / 2)
        { //monsterdependenceFrame = 1.0f;
            return 1.0f;
        }

        else
        { //monsterdependenceFrame = 1.0f;
            return 0.95f;
        }
    }

    //몬스터 속성(마법)공격 독립배율
    public float CalcMagicalIndependenceRate(GameObject player)
    {
        if (monsterCharacter.monStats.mAtk * 2 > (player.GetComponent<BattlePlayer>().playerInfo.magicDef) / 2)
        { //monsterdependenceFrame = 1.0f;
            return (monsterCharacter.monStats.mAtk * 2 / ((player.GetComponent<BattlePlayer>().playerInfo.magicDef) / 2));
        }

        else if (monsterCharacter.monStats.mAtk * 2 == (player.GetComponent<BattlePlayer>().playerInfo.magicDef) / 2)
        { //monsterdependenceFrame = 1.0f;
            return 1.0f;
        }

        else
        { //monsterdependenceFrame = 1.0f; 
            return 0.95f;
        }
    }

    //몬스터가 상태이상을 받는 함수
    public void MonsterStatusEffected()
    {
        // 상태이상을 받으면

        // 내성판정후 

        // 번호에 맞게 그 상태이상을 몬스터에게 부여

        // 생각해보니 플레이어한테는 독스킬이 없음-약간 데이터 수정해야함
    }

    //적->플레이어 주는 데미지 계산식 = 기본 데미지 × 독립 프레임 × 적의 스킬 배율 × 속성 배율

    public int MonsterNormalAttack(GameObject selectedPlayer) //몬스터가 플레이어를 일반공격시 데미지 계산
    {
        return (int)(monsterCharacter.monStats.pAtk * CalcPhysicsIndependenceRate(selectedPlayer) * monsterPatkRatio);
    }

    public int MonsterSkillAttack(int damageType) //몬스터 스킬공격시 데미지 계산
    {
        if (damageType == (int)MSkillData.DMGTYPE.Physics)
        {


            return 0;

        }
        else
        {


            return 0;
        }
    }

    //몬스터가 데미지를 입었을때 데미지 계산
    public int MonsterDamaged(int damage, MSkillData.DMGTYPE damageType)
    {
        int DamageAmount;
        if (damageType == MSkillData.DMGTYPE.Magical)
        { DamageAmount = damage - monsterCharacter.monStats.mDef; }
        else
        { DamageAmount = damage - monsterCharacter.monStats.pDef; }

        return DamageAmount; //단순 (공격력-방어력) 데미지 계산
    }

    //받은 데미지 값으로 몬스터 현재체력에서 깍아주기
    public void MonsterDamagedHp(int damaged)
    {
        if (damaged > monCurHp)
        { monCurHp = 0; }
        else
        { monCurHp -= damaged; }
    }
    #endregion

}
