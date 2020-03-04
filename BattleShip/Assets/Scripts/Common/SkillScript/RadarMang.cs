using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarMang : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject currselectPoint;  //현재 선택된 포인트
    public GameObject[] RadarPoint = new GameObject[4]; //검출될 부분

    int count = 0;

    private void OnEnable() // 활성화 될 때마다 초기화 호출
    {
        count = 0;
        RadarPoint = new GameObject[4];
        currselectPoint = null;
        hit = new RaycastHit();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine("End");
    }

    void OnTriggerStay(Collider other)
    {
        //배가 감지 되면
        if (other.gameObject.tag.Equals("Player2") || other.gameObject.tag.Equals("Player1"))
        {
            //배가 감지된 부분 위에서 레이캐스트를 그려서 격자 검출
            if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("AttackPoint")))
            {
                //격자가 검출된 지점
                currselectPoint = hit.collider.gameObject;

                bool hasSame = false;

                //같은 게임오브젝트가 있는지 확인
                for (int i = 0; i < RadarPoint.Length; i++)
                {
                    if (RadarPoint[i] != null)  // Null 값이 아닐때 들어온다.
                    {
                        if (RadarPoint[i].gameObject.Equals(currselectPoint.gameObject))    // 중복된 값이 배열에 들어올 경우.
                        {
                            hasSame = true;
                            break;
                        }
                    }
                }

                //같은 게임오브젝트가 없을때
                if (hasSame == false)
                {
                    //검출된 지점에 추가
                    RadarPoint[count] = currselectPoint;
                    count++;
                }

                //현재 선택된 공격포인트의 색을 빨간색으로 바꿈
                AttackPointCtrl apc = currselectPoint.GetComponent<AttackPointCtrl>();
                apc.isDetected = true;
                apc.ChangeColor(true);
            }
        }
    }

    //4초 후에 삭제
    IEnumerator End()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(transform.parent.parent.parent.gameObject);
    }
}
