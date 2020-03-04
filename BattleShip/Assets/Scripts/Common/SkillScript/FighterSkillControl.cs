using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSkillControl : MonoBehaviour
{
    public GameObject missile;      //생길 미사일 변수
    public GameObject detectedPoint;    //검출된 Point
    public GameObject[] FighterPoint = new GameObject[3];   //폭격할 지점
    GameObject fighterAttackPoint;

    public bool isDetectedFighterPoint = false;

    int count = 0;

    private void Start()
    {
        //미사일 떨구는 코루틴
        StartCoroutine("Drop");
    }

    // Update is called once per frame
    void Update()
    {
        //비행기 이동
        transform.Translate(new Vector3(0, 0, -0.02f * 2f));

        //화면 밖으로 벗어나면 삭제
        if (transform.position.x <= -14f || transform.position.x >= 14f)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    IEnumerator Drop()
    {
        while (true)
        {
            
            RaycastHit fighterHit;

            //FighterPoint 검출
            if (Physics.Raycast(transform.position, Vector3.down, out fighterHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("FighterPoint")))
            {
                if (!isDetectedFighterPoint)
                {
                    isDetectedFighterPoint = true;
                    fighterAttackPoint = fighterHit.collider.gameObject;
                }
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("AttackPoint")))
                {
                    //검출된 지점
                    detectedPoint = hit.collider.gameObject;

                    if (count == 0)
                    {
                        FighterPoint[count] = detectedPoint;
                        count++;

                        Transform pos = detectedPoint.transform;

                        Vector3 missilePos = new Vector3(pos.position.x, pos.position.y + 4.65f, pos.position.z);
                        Instantiate(missile, missilePos, pos.rotation);
                    }

                    bool hasSame = false;

                    //같은 게임오브젝트 검출
                    for (int i = 0; i < FighterPoint.Length; i++)
                    {
                        if (FighterPoint[i] != null)
                        {
                            if (FighterPoint[i].gameObject.Equals(detectedPoint.gameObject))
                            {
                                hasSame = true;
                                break;
                            }
                        }
                    }

                    //같은 게 없으면
                    if (!hasSame)
                    {
                        FighterPoint[count] = detectedPoint;
                        count++;

                        Transform pos = detectedPoint.transform;

                        Vector3 missilePos = new Vector3(pos.position.x, pos.position.y + 4.65f, pos.position.z);
                        Instantiate(missile, missilePos, pos.rotation);
                    }                    
                }
            }
            else
            {
                if (isDetectedFighterPoint)
                {
                    Destroy(fighterAttackPoint);
                    GameManager.instance.selectedShip = null;
                }
            }

            yield return null;
        }
    }
}