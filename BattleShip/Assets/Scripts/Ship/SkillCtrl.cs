using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : MonoBehaviour
{
    public bool isSelectedAttack = false;   //공격을 할지 선택
    public bool isRightClick = false;       //마우스 오른쪽 클릭 여부

    public SkillType skillType;         //스킬 타입
    GameObject[] prevSelectedPoints;    //이전 선택지점           
    public GameObject[] skillPrefabs;   //사용할 스킬 프리팹
    public GameObject fighter;          //비행기

    Menu menu;                          //배 클릭하면 생길 메뉴
    ShipMove shipMove;                  //각각의 ShipMove 스크립트

    public enum SkillType
    {
        Torpedo = 1, Shield, Scan, Attack, Bombing
    }

    //다른 스크립트에서 호출됨
    public void Initiallize()
    {
        isSelectedAttack = false;
        isRightClick = false;
    }

    // Use this for initialization
    void Start()
    {
        menu = FindObjectOfType<Menu>();
        shipMove = GetComponent<ShipMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shipMove.isSelected && !shipMove.isAlreadyAct)
        {
            if (GameManager.instance.selectedShip.Equals(gameObject))
            {
                //공격선택
                if (isSelectedAttack)
                {
                    Attack();
                }
            }
        }

        //턴 로딩이 되거나 배의 선택이 취소되면 이전 선택지점을 전부 비활성
        if (GameManager.instance.isTurnLoading || !shipMove.isSelected)
            InitiallizePrevPoint();
    }

    public void InitiallizePrevPoint()
    {
        if (prevSelectedPoints != null)
        {
            foreach (var obj in prevSelectedPoints)
            {
                if (obj != null)
                {
                    AttackPointCtrl apc = obj.GetComponent<AttackPointCtrl>();
                    apc.ChangeColor(false);
                    
                    if (GameManager.instance.isTurnLoading || !shipMove.isSelected)
                    {
                        apc.isDetected = false;
                    }
                }
            }
        }
    }

    //공격 선택후 마우스 왼쪽 클릭시 호출됨
    //대부분 초기화
    public void AfterAttack()
    {
        isSelectedAttack = false;
        shipMove.isSelected = false;
        shipMove.isAlreadyAct = true;

        prevSelectedPoints = null;
        menu.menu.SetActive(false);
    }

    //공격시 미사일 생성
    public void Attack()
    {
        //선택 지점
        Transform attackPos = Camera.main.GetComponent<Camera2DPointToWorldPoint>().GetWorldPointIfMouseDown();

        if (attackPos == null)
        {
            InitiallizePrevPoint();
            return;
        }

        Vector3 selectedPos = new Vector3();    //선택 지점
        //공격가능
        bool isAttackOK = false;
        bool isDefenseOK = false;

        string parentName = attackPos.parent.gameObject.name;
        //공격 가능 판단
        if ((parentName.Equals("AttackPoint2") && GameManager.instance.turn1) || (parentName.Equals("AttackPoint1") && GameManager.instance.turn2))
        {
            isAttackOK = true;
        }

        if ((parentName.Equals("AttackPoint1") && GameManager.instance.turn1) || (parentName.Equals("AttackPoint2") && GameManager.instance.turn2))
        {
            isDefenseOK = true;
        }

        //스킬 타입별로 동작 다름
        switch (skillType)
        {
            case SkillType.Torpedo:
                if (GameManager.instance.skillCount > 0 && isAttackOK)
                {
                    RaycastHit[] attackPoints;

                    //오른쪽 버튼으로 방향 회전
                    if (!isRightClick)
                    {
                        selectedPos = new Vector3(attackPos.position.x, attackPos.position.y, -7.5f);
                        attackPoints = Physics.RaycastAll(selectedPos, Vector3.forward, 10.0f, 1 << LayerMask.NameToLayer("AttackPoint"));
                    }
                    else
                    {
                        if (parentName.Equals("AttackPoint2"))
                            selectedPos = new Vector3(-11.5f, attackPos.position.y, attackPos.position.z);
                        else if (parentName.Equals("AttackPoint1"))
                            selectedPos = new Vector3(0.5f, attackPos.position.y, attackPos.position.z);

                        attackPoints = Physics.RaycastAll(selectedPos, Vector3.right, 10.0f, 1 << LayerMask.NameToLayer("AttackPoint"));
                    }

                    //공격 지점이 null이 아니고 공격가능할때
                    if (attackPoints != null)
                    {
                        if (prevSelectedPoints == null)
                        {
                            prevSelectedPoints = new GameObject[attackPoints.Length];
                        }
                        else
                            InitiallizePrevPoint();

                        int i = 0;

                        //Grid의 색을 바꿈
                        foreach (var obj in attackPoints)
                        {
                            prevSelectedPoints[i] = obj.collider.gameObject;
                            obj.collider.GetComponent<AttackPointCtrl>().ChangeColor(true);
                            i++;
                        }
                    }

                    //공격 가능한 지점에서 좌클릭 시 공격
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameManager.instance.UpdateLog(attackPos.name + "에 어뢰 발사.");
                        float dir = isRightClick ? 90.0f : 0f;
                        Instantiate(skillPrefabs[(int)skillType - 1], selectedPos, Quaternion.AngleAxis(dir, Vector3.up));
                        InitiallizePrevPoint();
                        AfterAttack();
                        GameManager.instance.skillCount--;
                    }

                    //오른쪽 마우스 버튼 클릭시 회전
                    if (Input.GetMouseButtonDown(1))
                    {
                        isRightClick = !isRightClick;
                    }
                }
                break;
            case SkillType.Shield:
                if (GameManager.instance.skillCount > 0)
                {
                    if (prevSelectedPoints == null)
                    {
                        prevSelectedPoints = new GameObject[1];
                        prevSelectedPoints[0] = attackPos.gameObject;
                    }
                    attackPos.GetComponent<AttackPointCtrl>().ChangeColor(true);

                    if (prevSelectedPoints[0] != attackPos)
                    {
                        prevSelectedPoints[0].GetComponent<AttackPointCtrl>().ChangeColor(false);
                        prevSelectedPoints[0] = attackPos.gameObject;
                    }

                    if (Input.GetMouseButtonDown(0) && isDefenseOK)
                    {
                        GameManager.instance.UpdateLog(attackPos.name + "을 보호");
                        Instantiate(skillPrefabs[(int)skillType - 1], attackPos.position, attackPos.rotation);
                        InitiallizePrevPoint();
                        AfterAttack();
                        GameManager.instance.selectedShip = null;
                        isDefenseOK = false;
                        GameManager.instance.skillCount--;                        
                    }
                }
                break;

            case SkillType.Scan:
                if (GameManager.instance.skillCount > 0)
                {
                    if (isAttackOK)
                    {
                        Collider[] attackPoints;

                        attackPoints = Physics.OverlapBox(new Vector3(attackPos.position.x + 0.5f, attackPos.position.y, attackPos.position.z - 0.5f), new Vector3(0.5f, 0.5f, 0.5f), attackPos.rotation, 1 << LayerMask.NameToLayer("AttackPoint"));

                        if (attackPoints != null && isAttackOK)
                        {
                            if (prevSelectedPoints == null)
                            {
                                prevSelectedPoints = new GameObject[4];
                            }
                            else
                            {
                                InitiallizePrevPoint();
                            }

                            int i = 0;

                            //Grid의 색을 바꿈
                            foreach (var obj in attackPoints)
                            {
                                prevSelectedPoints[i] = obj.gameObject;
                                obj.GetComponent<AttackPointCtrl>().ChangeColor(true);
                                i++;
                            }
                        }

                        if (Input.GetMouseButtonDown(0))
                        {
                            GameManager.instance.UpdateLog(attackPos.name + "에 스캔 사용.");
                            Instantiate(skillPrefabs[(int)skillType - 1], attackPos.position, skillPrefabs[(int)skillType - 1].transform.rotation);
                            InitiallizePrevPoint();
                            AfterAttack();
                            GameManager.instance.selectedShip = null;
                            isAttackOK = false;
                            GameManager.instance.skillCount--;                            
                        }
                    }
                }
                break;
            case SkillType.Attack:
                if (isAttackOK)
                {
                    if (prevSelectedPoints == null)
                    {
                        prevSelectedPoints = new GameObject[1];
                        prevSelectedPoints[0] = attackPos.gameObject;
                    }

                    if (!prevSelectedPoints[0].name.ToString().Equals(attackPos.name.ToString()))
                    {
                        prevSelectedPoints[0] = attackPos.gameObject;
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        GameManager.instance.UpdateLog(attackPos.name + "을 공격");
                        Instantiate(skillPrefabs[(int)skillType - 1], new Vector3(attackPos.position.x, attackPos.position.y + 10.0f, attackPos.position.z), skillPrefabs[(int)skillType - 1].transform.rotation);
                        InitiallizePrevPoint();
                        AfterAttack();
                        GameManager.instance.isAlreadyAttack = true;
                    }
                }
                break;
            case SkillType.Bombing:
                if (GameManager.instance.skillCount > 0)
                {
                    if (isAttackOK)
                    {
                        Collider[] attackPoints;

                        attackPoints = Physics.OverlapBox(attackPos.position, new Vector3(1.0f, 1.0f, 1.0f), attackPos.rotation, 1 << LayerMask.NameToLayer("AttackPoint"));

                        if (attackPoints != null && isAttackOK)
                        {
                            if (prevSelectedPoints == null)
                            {
                                prevSelectedPoints = new GameObject[9];
                            }
                            else
                                InitiallizePrevPoint();

                            int i = 0;

                            //Grid의 색을 바꿈
                            foreach (var obj in attackPoints)
                            {
                                prevSelectedPoints[i] = obj.gameObject;
                                obj.GetComponent<AttackPointCtrl>().ChangeColor(true);

                                i++;
                            }
                        }

                        if (Input.GetMouseButtonDown(0))
                        {
                            GameManager.instance.UpdateLog(attackPos.name + "에 폭격 개시");
                            GameObject fighterAttackPoint = Instantiate(skillPrefabs[(int)skillType - 1], attackPos.position, attackPos.rotation);

                            if (parentName.Equals("AttackPoint1"))
                                Instantiate(fighter, new Vector3(12.5f, fighter.transform.position.y, attackPos.transform.position.z), fighter.transform.rotation);
                            else if (parentName.Equals("AttackPoint2"))
                                Instantiate(fighter, new Vector3(-13.5f, fighter.transform.position.y, attackPos.transform.position.z), fighter.transform.rotation * Quaternion.Euler(0, 180, 0));
                            InitiallizePrevPoint();
                            AfterAttack();
                            GameManager.instance.skillCount--;
                        }
                    }
                }
                break;
        }

        //공격가능하지 않으면 이전 선택지점 해제
        if (!isAttackOK)
        {
            InitiallizePrevPoint();
        }

    }
}
