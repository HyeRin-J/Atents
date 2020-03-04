using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoCtrl : MonoBehaviour
{
    public float speed = 100.0f;    //스피드
    private Rigidbody rb;
    private Transform tr;

    public int boundaryIncount = 0;     //바운더리 충돌 횟수

    void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();       
    }

    private void OnEnable()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //바운더리랑 충돌하면
        if (other.CompareTag("Boundary"))
        {
            boundaryIncount++;
            if (boundaryIncount >= 2)
                Destroy(transform.parent.gameObject, 0.1f);
        }
    }

    //삭제 될때 선택된 함선 초기화
    private void OnDestroy()
    {
        GameManager.instance.selectedShip = null;    
    }
}
