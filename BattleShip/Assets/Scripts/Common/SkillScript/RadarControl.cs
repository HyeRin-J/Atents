using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarControl : MonoBehaviour
{
    public RadarMang radarMang;

    private void Start()
    {
        radarMang = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RadarMang>();
    }

    // Update is called once per frame
    void Update()
    {
        //턴이 바뀔때 레이더 망에 걸렸던 포인트 삭제
        if (GameManager.instance.isTurnLoading == true)
        {
            foreach (var obj in radarMang.RadarPoint)
                if (obj != null)
                {
                    AttackPointCtrl apc = obj.GetComponent<AttackPointCtrl>();
                    apc.isDetected = false;
                    apc.ChangeColor(false);
                }
            Destroy(gameObject);
        }
    }
}

