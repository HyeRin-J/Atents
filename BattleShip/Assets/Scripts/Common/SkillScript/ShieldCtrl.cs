using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCtrl : MonoBehaviour {
    //미사일이나 어뢰랑 만나면 실드랑 미사일 삭제
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torpedo") || other.CompareTag("Missile"))
        {
            GameManager.instance.UpdateLog("실드에 막혔습니다");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
