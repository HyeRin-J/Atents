using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControl : MonoBehaviour {
    public Sprite[] arrow = new Sprite[4];  //스프라이트 이미지

    // Use this for initialization
    void Start () {
        arrow = Resources.LoadAll<Sprite>("Images/Arrows");
    }

    // Update is called once per frame
    void Update ()
    {
        //파도 방향에 맞춰서 스프라이트 이미지 교체
        switch (WaterTimeControll.waterArrow.Arrow)
        {
            case 1: // 오른쪽
                GetComponent<Image>().sprite = arrow[2];
                break;
            case 2: // 아래쪽
                GetComponent<Image>().sprite = arrow[0];
                break;
            case 3: // 왼쪽
                GetComponent<Image>().sprite = arrow[1];
                break;
            default: // 위쪽
                GetComponent<Image>().sprite = arrow[3];
                break;
        }        
    }
}
