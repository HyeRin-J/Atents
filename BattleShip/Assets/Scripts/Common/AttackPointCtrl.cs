using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointCtrl : MonoBehaviour {
    public bool isDetected = false;     //레이더에 감지
    public bool isMoveAvailable = false;    //이동 가능
    public GameObject waterEffect;      //미사일과 감지되었을 때 표시할 물 튀기는 이펙트임

    // Use this for initialization
    void Start () {
        ChangeColor(false);
    }

    private void Update()
    {
        if (GameManager.instance.isTurnLoading)
        {
            isDetected = false;
            ChangeColor(false);
        }
    }

    //색깔 변경
    public void ChangeColor(bool isSelect)
    {
        Material mat = gameObject.GetComponent<MeshRenderer>().material;

        if (isSelect)
        {
            mat.SetColor("_Color", new Color(1, 0, 0, 1));
        }
        else
        {
            if(!isDetected)
                mat.SetColor("_Color", new Color(1, 0, 0, 0));
        }
    }

    //색깔변경 2
    public void ChangeColor(int colorCode)
    {
        Material mat = gameObject.GetComponent<MeshRenderer>().material;

        switch (colorCode)
        {
            case 0:
                mat.SetColor("_Color", new Color(1, 0, 0, 1));
                break;
            case 1:
                mat.SetColor("_Color", new Color(0, 1, 0, 1));
                break;
            default:
                if (!isDetected)
                    gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0);
                break;

        }
    }

    //미사일이랑 충돌 시
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            //물 튀기는 이펙트 생길 지점
            Vector3 pos = new Vector3(transform.position.x, -0.6f, transform.position.z);

            //물 튀기는 이펙트 생성
            GameObject temp = Instantiate(waterEffect, pos, transform.rotation);
            Destroy(temp, 2.0f);

            //물 튀기는 소리 재생
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);

            GameManager.instance.selectedShip = null;

            //미사일 삭제
            Destroy(other.gameObject);
        }
    }
}
