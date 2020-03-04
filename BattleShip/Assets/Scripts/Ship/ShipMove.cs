using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class ShipMove : MonoBehaviour
{
    public float checkShipRange = 2.0f;     //주변에 함선 있는지 검출할 거리
    public bool isLeftShipExist = false;    //왼쪽에 배가 있음
    public bool isRightShipExist = false;   //오른쪽에 배가 있음
    public bool isAlreadyAct = false;  //이동하거나 공격하거나 스킬 사용시 체크되고, 다음 턴이 되었을 때 false로 돌아감

    public float rayDistance = 2.0f;        //이동할 수 있는 범위를 검출할 때 쓸 레이캐스트 길이
    public bool isSelected = false;         //선택되어 있음
    public bool isMoving = false;           //움직이는 중

    public float moveStartTime;             //움직인 시간

    Transform selectedGrid;                 //현재 선택된 격자
    public Vector3 originPos;               //원래 위치
    public Vector3 movePos;                 //이동할 위치
    RaycastHit[] hit;                       //검출된 레이캐스트

    private void OnMouseDown()
    {
        //다른 턴에 선택되는 걸 막기 위해서 비교
        if (GameManager.instance.isGameProgressing && (GameManager.instance.turn1 && CompareTag("Player1") || GameManager.instance.turn2 && CompareTag("Player2")))
        {
            //현재 선택된 배가 없고, 이동중이 아니고, 이미 행동을 하지 않았을 때 선택되게 함
            if (GameManager.instance.selectedShip == null && GameManager.instance.isGameProgressing && !isMoving && !isAlreadyAct)
            {
                //선택된 함선을 지금 게임오브젝트로
                GameManager.instance.selectedShip = gameObject;
                //선택되었음
                isSelected = true;

                //이미 이동하지 않았으면
                if (!GameManager.instance.isAlreadyMoveShip)
                {
                    //좌우에 함선이 있는지 검출
                    IsCheckShip();

                    //현재 회전 각도를 검출
                    float yRot = transform.parent.rotation.eulerAngles.y;

                    if (WaterTimeControll.waterArrow.Arrow == 1)    // 바다 방향 오른쪽
                    {
                        if ((yRot - 90.0f) <= 0.1f && (yRot - 90.0f) >= -0.1f)  // 배 오른쪽
                            rayDistance = 3.0f;
                        else if ((yRot - 270.0f) <= 0.1f && (yRot - 270.0f) >= -0.1f)   // 배 왼쪽
                            rayDistance = 1.0f;
                        else
                            rayDistance = 2.0f;
                    }
                    else if (WaterTimeControll.waterArrow.Arrow == 2) // 바다 방향 아래쪽
                    {
                        if ((yRot - 180.0f) <= 0.1f && (yRot - 180.0f) >= -0.1f)    // 배 아래쪽
                            rayDistance = 3.0f;
                        else if ((yRot - 0f) <= 0.1f && (yRot - 0f) >= -0.1f)   // 배 위쪽
                            rayDistance = 1.0f;
                        else
                            rayDistance = 2.0f;
                    }
                    else if (WaterTimeControll.waterArrow.Arrow == 3)   // 바다 방향 왼쪽
                    {
                        if ((yRot - 270.0f) <= 0.1f && (yRot - 270.0f) >= -0.1f)    // 배 왼쪽
                            rayDistance = 3.0f;
                        else if ((yRot - 90.0f) <= 0.1f && (yRot - 90.0f) >= -0.1f) // 배 오른쪽
                            rayDistance = 1.0f;
                        else
                            rayDistance = 2.0f;
                    }
                    // 바다 방향 위쪽
                    else
                    {
                        if ((yRot - 0.0f) <= 0.1f && (yRot - 0.0f) >= -0.1f)    // 바다 방향 위쪽
                            rayDistance = 3.0f;
                        else if ((yRot - 180.0f) <= 0.1f && (yRot - 180.0f) >= -0.1f)   // 배 아래쪽
                            rayDistance = 1.0f;
                        else
                            rayDistance = 2.0f;
                    }

                    //Raycast를 통해서 AttackPoint 검출
                    hit = Physics.RaycastAll(transform.parent.GetChild(1).position, transform.parent.TransformDirection(Vector3.forward), rayDistance, 1 << LayerMask.NameToLayer("AttackPoint"));

                    //검출된 지점의 색을 바꿀건데                   
                    for (int i = 0; i < hit.Length; i++)
                    {
                        //그 위에 배가 있으면 이동 못하니까 위에 배가 있으면 초기화해버리자!
                        if (Physics.Raycast(hit[i].transform.position + Vector3.down, Vector3.up, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ship")))
                        {
                            hit[i] = new RaycastHit();
                        }

                        //중간에 배로 막히면 뒤에 거 전부 초기화
                        if (i >= 1)
                        {
                            if (hit[i - 1].collider == null)
                            {
                                hit[i] = new RaycastHit();
                            }
                        }

                        //다른 팀의 격자를 검출할 수도 있음
                        if (hit[i].collider != null && (GameManager.instance.turn1 && hit[i].collider.transform.parent.name.Equals("AttackPoint2") || GameManager.instance.turn2 && hit[i].collider.transform.parent.name.Equals("AttackPoint1")))
                            hit[i] = new RaycastHit();
                    }
                }
                //이미 이동을 했으면 이전에 검출되었던 지점을 전부 초기화
                else
                {
                    if (hit != null)
                    {
                        for (int i = 0; i < hit.Length; i++)
                        {
                            hit[i] = new RaycastHit();
                        }
                    }
                }
            }
        }
    }

    //기즈모
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.parent.position, checkShipRange);
    }

    //회전할 반경 안에 배가 있는지를 검출
    public void IsCheckShip()
    {
        if (transform == null) return;

        //피봇 위치
        Transform pivot = transform.parent;

        //좌우로 배와 바운더리 검출
        Collider[] colls = Physics.OverlapSphere(pivot.position, checkShipRange, (1 << LayerMask.NameToLayer("Ship")) | (1 << LayerMask.NameToLayer("Boundary")));

        //검출이 되었으면
        if (colls.Length > 0)
        {
            //검출된 애들이랑 각도를 비교해서
            foreach (var obj in colls)
            {
                if (!obj.transform.Equals(transform.parent.GetChild(1)) && !obj.transform.Equals(transform))
                {
                    Vector3 dir = (obj.transform.position - pivot.position).normalized;

                    //일단 함선 앞방향이랑 90도 안이면 범위 안에 있으니까
                    //그게 왼쪽인지 오른쪽인지 검출해야 됨             
                    if (Vector3.Angle(pivot.forward, dir) <= 90.0f)
                    {
                        //근데 이미 true가 되었으면 다시 검출할 필요가 없어짐
                        if (!isRightShipExist)
                            isRightShipExist = Vector3.Angle(pivot.right, dir) <= 90.0f;
                        if (!isLeftShipExist)
                            isLeftShipExist = Vector3.Angle(-pivot.right, dir) <= 90.0f;
                    }
                }
            }
        }
    }

    //좌우 함선 체크 상태 해제
    public void InitiallizeShipCheck()
    {
        isLeftShipExist = false;
        isRightShipExist = false;
    }

    // Use this for initialization
    void Start()
    {
        hit = Physics.RaycastAll(transform.parent.GetChild(1).position, transform.parent.TransformDirection(Vector3.forward), rayDistance, 1 << LayerMask.NameToLayer(""));
    }

    // Update is called once per frame
    void Update()
    {
        //게임 진행 중이면
        if (GameManager.instance.isGameProgressing)
        {
            //턴 진행중이면 전부 초기화

            if (GameManager.instance.isTurnLoading)
            {
                isLeftShipExist = false;
                isRightShipExist = false;
                isSelected = false;
                isMoving = false;
                isAlreadyAct = false;
            }

            //움직이는 중이면
            if (isMoving)
            {
                //선택된 그리드의 색깔을 다시 바꾸고
                foreach (var obj in hit)
                    if (obj.collider != null && obj.collider.CompareTag("AttackPoint"))
                    {
                        AttackPointCtrl apc = obj.collider.GetComponent<AttackPointCtrl>();
                        apc.ChangeColor(false);
                        apc.isMoveAvailable = false;
                    }

                //현재까지 이동한 거리 측정
                float duration = (Time.time - moveStartTime) * 3.0f / Vector3.Distance(originPos, movePos);

                //포지션을 이동
                transform.parent.position = Vector3.Lerp(originPos, movePos, duration);

                //거리가 0.1미만이면 움직임 상태 종료
                if (Vector3.Distance(transform.parent.position, movePos) <= 0.1f)
                {
                    transform.parent.position = movePos;
                    isMoving = false;
                    GameManager.instance.selectedShip = null;
                    GameManager.instance.UpdateLog("함선 이동");
                }
            }
            //움직이는 중이 아니면
            else
            {
                //선택되었을때
                if (isSelected)
                {
                    //외곽선 그려줌
                    if (gameObject.GetComponentInChildren<Outline>() != null)
                        GetComponentInChildren<Outline>().color = 0;

                    foreach (var obj in hit)
                    {
                        if (obj.collider != null && obj.collider.CompareTag("AttackPoint"))
                        {
                            AttackPointCtrl apc = obj.collider.GetComponent<AttackPointCtrl>();
                            apc.ChangeColor(1);
                            apc.isMoveAvailable = true;
                        }
                    }

                    //마우스 왼쪽 버튼 클릭
                    if (Input.GetMouseButtonDown(0))
                    {
                        //선택된 Grid(공격포인트)의 좌표를 가져옴
                        selectedGrid = Camera.main.GetComponent<Camera2DPointToWorldPoint>().GetWorldPointIfMouseDown();
                        if (selectedGrid == null)
                            return;

                        foreach (var obj in hit)
                        {
                            //선택된 지점이랑 레이캐스트에 검출된 게임오브젝트가 같으면
                            //움직임 상태로 바꾸고 움직일 좌표를 계산
                            if (obj.collider != null && selectedGrid.gameObject == obj.collider.gameObject)
                            {
                                //이동중
                                isMoving = true;

                                //이미 1번 이동을 끝냄
                                GameManager.instance.isAlreadyMoveShip = true;

                                //이 배는 이미 이동했다
                                isAlreadyAct = true;

                                //원래 위치
                                originPos = transform.parent.position;

                                //이동할 위치
                                movePos = originPos + (selectedGrid.position - transform.parent.GetChild(1).position);

                                //움직임이 시작된 시간
                                moveStartTime = Time.time;

                                //선택상태 해제
                                isSelected = false;
                            }
                        }
                    }
                }
                //선택이 해제되면
                else
                {
                    //외곽선 빼고
                    if (gameObject.GetComponentInChildren<Outline>() != null)
                        GetComponentInChildren<Outline>().color = 1;

                    foreach (var obj in hit)
                        if (obj.collider != null)
                        {
                            AttackPointCtrl apc = obj.collider.GetComponent<AttackPointCtrl>();
                            apc.ChangeColor(false);
                            apc.isMoveAvailable = false;
                        }
                }
            }
        }
    }
}
