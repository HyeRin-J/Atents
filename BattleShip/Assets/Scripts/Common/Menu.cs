using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public GameObject[] shipObj;    //함선 오브젝트
    public GameObject menu;         //메뉴 오브젝트

    bool isRotate = false;            //회전 상태

    public Text turnButtonText;      //턴 종료 버튼
    private ShipMove shipMove;       //선택된 함선의 ShipMove 스크립트
    public Sprite[] skillImage;      //스킬 타입에 따라 바꿔줄 스킬 스프라이트
    public Image skillButton;        //스킬 버튼
    public Button leftButton;        //왼쪽회전버튼
    public Button rightButton;       //오른쪽회전버튼

    Quaternion rotateAngle = Quaternion.identity;   //회전할 각도

    // Use this for initialization
    void Start () {
        menu.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameProgressing) turnButtonText.text = "턴 종료";

        //선택된 함선이 없으면 menu 비활성화
        if (GameManager.instance.selectedShip == null)
        {
            menu.SetActive(false);
        }
 
        if (shipMove != null)
        {
            //회전상태면
            if (isRotate)
            {
                shipMove.transform.parent.rotation = Quaternion.Lerp(shipMove.transform.parent.rotation, rotateAngle, Time.deltaTime * 3.0f);
            }

            //회전할 각도와 현재 각도를 계산해서 0.01 미만이면
            //회전상태 종료
            if (Quaternion.Angle(shipMove.transform.parent.rotation, rotateAngle) <= 0.01f && isRotate)
            {
                shipMove.transform.parent.rotation = rotateAngle;
                isRotate = false;
                shipMove.InitiallizeShipCheck();
                EndRotate();
            }
        }

        //메뉴를 열어줌
        MenuOpen();
    }

    //왼쪽 회전
    public void OnLeft()
    {
        menu.SetActive(false);
        shipMove.isSelected = false;

        GameManager.instance.isAlreadyMoveShip = true;

        //회전 각도 계산
        rotateAngle = shipMove.transform.parent.rotation * Quaternion.Euler(0, -90, 0);

        //회전 상태로 변경
        isRotate = true;
        GameManager.instance.UpdateLog("왼쪽으로 90' 회전");
    }

    //오른쪽 회전
    public void OnRight()
    {
        menu.SetActive(false);
        shipMove.isSelected = false;

        GameManager.instance.isAlreadyMoveShip = true;

        //회전 각도 계산
        rotateAngle = shipMove.transform.parent.rotation * Quaternion.Euler(0, 90, 0);

        //회전 상태로 변경
        isRotate = true;
        GameManager.instance.UpdateLog("오른쪽으로 90' 회전");
    }

    //메뉴 열어주는 부분
    public void MenuOpen()
    {
        for (int i = 0; i < shipObj.Length; i++)
        {
            //선택된 함선이 있으면
            if (shipObj[i].GetComponent<ShipMove>().isSelected == true)
            {
                //변수 저장하고
                shipMove = shipObj[i].GetComponent<ShipMove>();

                //스킬버튼 맞춰서 바꿔주고
                skillButton.sprite = skillImage[(int)shipMove.GetComponent<SkillCtrl>().skillType - 1];
                //스킬 카운트가 0이면 버튼 클릭 안 되고
                skillButton.transform.parent.GetComponent<Button>().interactable = GameManager.instance.skillCount > 0;

                //근데 선택된 함선이 전함이면
                //공격은 되야 하니까 클릭 되게 바꿔줌
                if (skillButton.sprite.Equals(skillImage[(int)3]) && !GameManager.instance.isAlreadyAttack)
                    skillButton.transform.parent.GetComponent<Button>().interactable = true;

                //왼쪽 회전, 오른쪽 회전 계산
                leftButton.GetComponent<Button>().interactable = !shipMove.isLeftShipExist && !GameManager.instance.isAlreadyMoveShip;
                rightButton.GetComponent<Button>().interactable = !shipMove.isRightShipExist && !GameManager.instance.isAlreadyMoveShip;

                //메뉴 활성화
                menu.SetActive(true);
                break;
            }
            
        }
    }
    
    void EndRotate()
    {
        //초기화
        shipMove.isAlreadyAct = true;
        shipMove.isSelected = false;
        GameManager.instance.isAlreadyMoveShip = true;
        GameManager.instance.selectedShip = null;
    }

    //스킬 버튼 클릭
    public void OnClickSkill()
    {
        shipMove.GetComponent<SkillCtrl>().isSelectedAttack = true;
        menu.SetActive(false);
    }

    //취소버튼
    public void OnCancle()
    {
        shipMove.GetComponent<SkillCtrl>().Initiallize();
        GameManager.instance.selectedShip = null;
        shipMove.isSelected = false;
        menu.SetActive(false);
    }
}
