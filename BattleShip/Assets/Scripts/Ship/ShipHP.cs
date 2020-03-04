using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHP : MonoBehaviour
{
    public int maxHP;       //최대 체력
    public int hp;          //현재 체력
    public bool isDead = false; //죽었는가?
    public AudioClip[] sfx;     //오디오 클립들
    public GameObject fireEffect;   //부딛히면 출력할 이펙트

    // Use this for initialization
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //hp가 0미만이면 죽음
        if (hp <= 0)
        {
            isDead = true;
        }

        //죽었으면 게임 오브젝트 비활성화
        if (isDead)
        {
            GameManager.instance.UpdateLog("적 함선을 파괴");

            //파괴음
            GetComponent<AudioSource>().PlayOneShot(sfx[1]);

            //태그 비교후 현재 함선 숫자 감소
            if (CompareTag("Player1")) GameManager.instance.player1Ships--;
            else if (CompareTag("Player2")) GameManager.instance.player2Ships--;

            //게임이 끝났는지 여부를 검출
            GameManager.instance.GameEnd();

            //부모 오브젝트 비활성화
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //미사일이거나 어뢰와 부딪히면
        if (other.CompareTag("Missile") || other.CompareTag("Torpedo"))
        {
            //폭발음
            GetComponent<AudioSource>().PlayOneShot(sfx[0]);

            //배의 체력을 깎음
            hp--;
            if (hp <= 0) hp = 0;

            //이펙트 생성될 지점
            Vector3 pos = new Vector3(other.transform.position.x, -0.6f, other.transform.position.z);

            //이펙트 생성
            GameObject temp = Instantiate(fireEffect, pos, transform.rotation);
            Destroy(temp, 2.0f);

            //현재 선택된 함선 초기화
            GameManager.instance.selectedShip = null;

            //미사일이나 어뢰 삭제
            Destroy(other.gameObject, 0.05f);
        }
    }
}
