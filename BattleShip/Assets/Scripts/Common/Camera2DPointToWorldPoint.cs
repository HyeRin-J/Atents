using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DPointToWorldPoint : MonoBehaviour
{

    private int attackLayer;

    GameObject currSelectPoint;

    // Use this for initialization
    void Start()
    {
        attackLayer = LayerMask.NameToLayer("AttackPoint");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //카메라에 입력된 마우스의 Vector2 좌표를 Vector3 월드 좌표로 변환
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -transform.position.z));//원본

        //변환된 월드좌표와 카메라와의 방향 벡터 계산
        Vector3 dir = (worldPoint - transform.position).normalized;

        //레이캐스트로 충돌 검사
        if (Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity, 1 << attackLayer))
        {
            //Layer가 AttackPoint일때
            if (hit.collider.CompareTag("AttackPoint"))
            {
                //처음으로 검출된 AttackPoint이면 그 포인트를 저장
                if (currSelectPoint == null)
                {
                    currSelectPoint = hit.collider.gameObject;
                }

                //선택된 공격포인트
                GameObject pointedObject = hit.collider.gameObject;

                //이전에 선택된 공격포인트와 현재 선택된 공격포인트가 다르면
                //이전에 선택된 공격포인트는 다시 투명하게 바꾸고
                //이전에 선택딘 공격포인트를 현재 선택된 포인트로 변경
                if (currSelectPoint != pointedObject)
                {
                    currSelectPoint.GetComponent<AttackPointCtrl>().ChangeColor(false);
                    pointedObject.GetComponent<AttackPointCtrl>().ChangeColor(true);
                    currSelectPoint = pointedObject;
                }
            }
        }
        //검출이 안 됐을 때
        else
        {
            //이전 선택지점이 있으면 색을 투명하게 바꿈
            if (currSelectPoint != null)
            {
                currSelectPoint.GetComponent<AttackPointCtrl>().ChangeColor(false);
                currSelectPoint = null;
            }
        }
    }

    //현재 선택된 공격포인트의 Transform을 반환하는 함수
    public Transform GetWorldPointIfMouseDown()
    {
        if(currSelectPoint != null)
            return currSelectPoint.transform;

        return null;
    }
}
