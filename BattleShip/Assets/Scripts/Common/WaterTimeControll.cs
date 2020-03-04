using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTimeControll : MonoBehaviour
{

    // private GameManager gameManager;

    public int Arrow;

    public static WaterTimeControll waterArrow;      // ArrowControl 에서 화살표 위치 조절 변수 Arrow 사용하기 위해.
    public GameObject[] water;

    private void Awake()
    {
        if (WaterTimeControll.waterArrow == null)
        {
            WaterTimeControll.waterArrow = this;
        }
    }

    public void RanNum(int random)  // GameManager 와 연결.
    {
        foreach (var obj in water)
        {
            Material mat = obj.GetComponent<MeshRenderer>().material;
            Vector4 speed = mat.GetVector("WaveSpeed");

            //Debug.Log(random);
            switch (random)
            {
                case 1: // 오른쪽                             

                    speed = new Vector4(10, 5, -20, 5);

                    mat.SetVector("WaveSpeed", speed);

                    //Debug.Log("오른쪽");

                    Arrow = 1;
                    break;
                case 2: // 아래쪽
                    speed = new Vector4(10, 5, -20, 40);

                    mat.SetVector("WaveSpeed", speed);

                    //Debug.Log("아래쪽");

                    Arrow = 2;

                    break;
                case 3: // 왼쪽
                    speed = new Vector4(10, 5, 20, 5);

                    mat.SetVector("WaveSpeed", speed);

                    //Debug.Log("왼쪽");

                    Arrow = 3;

                    break;
                default: // 위쪽
                    speed = new Vector4(10, 5, -20, -40);

                    mat.SetVector("WaveSpeed", speed);

                    //Debug.Log("위쪽");

                    Arrow = 4;

                    break;
            }

        }
    }
}

