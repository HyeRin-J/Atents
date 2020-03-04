using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public bool isMoving = false;
    public bool isRotating = false;
    bool isForwardShortCut = false;
    bool isForwardNextStair = false;
    bool isForwardPrevStair = false;

    float duration = 0.0f;
    float movingTime = 0.0f;
    public float speed = 49f;
    public float moveDistance = 0;

    Vector3 startPos;
    Vector3 endPos;
    Quaternion endRot;

    Encounter encounter;

    public Image buttonCheckImage;
    public RawImage mapImage;
    public RectTransform directionArrowImage;
    public int directionNum;

    public Vector2 startPosition;

    PlayerArrowTrigger playerArrow;

    static PlayerMove _instance;
    public static PlayerMove instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
            _instance = this;
            return;
        }
    }

    // Use this for initialization
    void Start()
    {
        encounter = GetComponent<Encounter>();      
       
        playerArrow = GetComponentInChildren<PlayerArrowTrigger>();
    }

    public void RotateSetting(float angle)
    {
        endRot = transform.rotation * Quaternion.Euler(0, -angle, 0);
        isRotating = true;
        isForwardShortCut = false;
        isForwardNextStair = false;
        isForwardPrevStair = false;
        buttonCheckImage.gameObject.SetActive(false);
        if (angle > 0f)
        {
            directionArrowImage.transform.Rotate(Vector3.forward, 90f * (int)Mathf.Round(angle / 90));
            directionNum += (int)Mathf.Round(angle / 90);
            if (directionNum >= 5) directionNum = 1;
            if (directionNum >= 4) directionNum = 0;        
        }
        else if (angle < 0f)
        {
            directionArrowImage.transform.Rotate(Vector3.forward, -90f * (int)Mathf.Round(-angle / 90));
            directionNum -= (int)Mathf.Round(-angle / 90);
            if (directionNum <= -2) directionNum = 2;
            if (directionNum <= -1) directionNum = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(encounter.loadingState == LoadingState.Loading)
        {
            enabled = false;
        }

        //이동중
        if (isMoving)
        {
            movingTime += Time.deltaTime * speed;
            float frac = movingTime / duration;

            transform.position = Vector3.Lerp(startPos, endPos, frac);

            //어느정도 이동하면 위치 고정
            if (Vector3.Distance(transform.position, endPos) <= 0.1f)
            {
                transform.position = endPos;
                movingTime = 0.0f;
                isMoving = false;
                if (encounter != null) encounter.ChangeColor();

                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, moveDistance))
                {
                    if (hit.collider.CompareTag("ShortCut"))
                    {
                        isForwardShortCut = true;
                        buttonCheckImage.gameObject.SetActive(true);
                    }
                    else if(hit.collider.CompareTag("NextStair"))
                    {
                        isForwardNextStair = true;
                        buttonCheckImage.gameObject.SetActive(true);
                    }
                    else if(hit.collider.CompareTag("PrevStair"))
                    {
                        isForwardPrevStair = true;
                        buttonCheckImage.gameObject.SetActive(true);
                    }
                }
            }
        }
        //회전 중
        else if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, endRot, Time.deltaTime * 10f);

            //어느정도 회전하면 각도 고정
            if (Quaternion.Angle(transform.rotation, endRot) <= 0.3f)
            {
                transform.rotation = endRot;
                isRotating = false;

                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, moveDistance))
                {
                    if (hit.collider.CompareTag("ShortCut"))
                    {
                        isForwardShortCut = true;
                        buttonCheckImage.gameObject.SetActive(true);
                    }
                    else if(hit.collider.CompareTag("NextStair"))
                    {
                        isForwardNextStair = true;
                        buttonCheckImage.gameObject.SetActive(true);
                    }
                    else if(hit.collider.CompareTag("PrevStair"))
                    {
                        isForwardPrevStair = true;
                        buttonCheckImage.gameObject.SetActive(true);
                    }
                }
            }
        }
        else
        {
            //방향키 입력에 따른 동작
            //앞뒤 방향키 이동

            Vector3 direction = Vector3.zero;
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * moveDistance, Color.yellow);
            Debug.DrawRay(Camera.main.transform.position, -Camera.main.transform.forward * moveDistance, Color.blue);
            
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                direction = transform.forward;
                startPos = transform.position;
               
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, moveDistance))
                {
                    if (hit.collider.CompareTag("Wall"))
                        Debug.Log("Wall");
                    else if (hit.collider.CompareTag("ShortCut"))
                    {

                    }
                    else if (hit.collider.CompareTag("NextStair"))
                    {

                    }
                    else if(hit.collider.CompareTag("PrevStair"))
                    {

                    }
                    else if (hit.collider.CompareTag("FOE"))
                    {
                        float angle = Vector3.SignedAngle(transform.forward, -hit.collider.transform.up, Vector3.up);
                        hit.collider.transform.Rotate(0, 0, angle);
                        hit.collider.GetComponent<FOEMove>().foeAnimator.SetTrigger("Attack");
                    }
                    else
                    {                       
                        isMoving = true;
                        endPos = transform.position + direction * moveDistance;
                        if (directionNum == 0)
                        {
                            directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y + 15);
                            playerArrow.playerPos[0]--;
                        }
                        else if (directionNum == 1)
                        {
                            directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x - 15, directionArrowImage.anchoredPosition.y);
                            playerArrow.playerPos[1]--;
                        }
                        else if (directionNum == 2)
                        {
                            directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y - 15);
                            playerArrow.playerPos[0]++;
                        }
                        else if (directionNum == 3)
                        {
                            directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x + 15, directionArrowImage.anchoredPosition.y);
                            playerArrow.playerPos[1]++;
                        }
                        foreach (var foe in SceneChanger.instance.FOEs)
                        {
                            foe.GetComponent<FOEMove>().ColumnRowCount();
                        }
                    }
                }
                else
                {                    
                    isMoving = true;
                    endPos = transform.position + direction * moveDistance;
                    if (directionNum == 0)
                    {
                        directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y + 15);
                        playerArrow.playerPos[0]--;
                    }
                    else if (directionNum == 1)
                    {
                        directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x - 15, directionArrowImage.anchoredPosition.y);
                        playerArrow.playerPos[1]--;
                    }
                    else if (directionNum == 2)
                    {
                        directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y - 15);
                        playerArrow.playerPos[0]++;
                    }
                    else if (directionNum == 3)
                    {
                        directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x + 15, directionArrowImage.anchoredPosition.y);
                        playerArrow.playerPos[1]++;
                    }
                    foreach (var foe in SceneChanger.instance.FOEs)
                    {
                        foe.GetComponent<FOEMove>().ColumnRowCount();
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                direction = -transform.forward;
                startPos = transform.position;

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, -Camera.main.transform.forward, out hit, moveDistance))
                {
                    Debug.Log("Wall");
                    if (hit.collider.CompareTag("FOE"))
                    {
                        float angle = Vector3.SignedAngle(transform.forward, hit.collider.transform.up, Vector3.up);
                        hit.collider.transform.Rotate(0, 0, angle);
                        angle = Vector3.SignedAngle(transform.up, hit.collider.transform.forward, Vector3.up);
                        RotateSetting(angle);
                        hit.collider.GetComponent<FOEMove>().foeAnimator.SetTrigger("Attack");
                    }
                }
                else
                {
                    isMoving = true;
                    endPos = transform.position + direction * moveDistance;
                    isForwardShortCut = false;
                    isForwardNextStair = false;
                    isForwardPrevStair = false;
                    buttonCheckImage.gameObject.SetActive(false);
                    if (directionNum == 0)
                    {
                        directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y - 15);
                        playerArrow.playerPos[0]++;

                    }
                    else if (directionNum == 1)
                    {
                        directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x + 15, directionArrowImage.anchoredPosition.y);
                        playerArrow.playerPos[1]++;

                    }
                    else if (directionNum == 2)
                    {
                        directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y + 15);
                        playerArrow.playerPos[0]--;

                    }
                    else if (directionNum == 3)
                    {
                        directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x - 15, directionArrowImage.anchoredPosition.y);
                        playerArrow.playerPos[1]--;

                    }
                    foreach (var foe in SceneChanger.instance.FOEs)
                    {
                        foe.GetComponent<FOEMove>().ColumnRowCount();
                    }
                }
            }           

            duration = Vector3.Distance(startPos, endPos);

            //양옆 방향키는 회전
            Quaternion rotDirection = Quaternion.identity;

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                endRot = transform.rotation * Quaternion.Euler(0, 90, 0);
                isRotating = true;
                isForwardShortCut = false;
                isForwardNextStair = false;
                isForwardPrevStair = false;
                buttonCheckImage.gameObject.SetActive(false);
                directionArrowImage.transform.Rotate(Vector3.forward, -90f);
                directionNum--;
                if (directionNum <= -1) directionNum = 3;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                endRot = transform.rotation * Quaternion.Euler(0, -90, 0);
                isRotating = true;
                isForwardShortCut = false;
                isForwardNextStair = false;
                isForwardPrevStair = false;
                buttonCheckImage.gameObject.SetActive(false);
                directionArrowImage.transform.Rotate(Vector3.forward, 90f);
                directionNum++;
                if (directionNum >= 4) directionNum = 0;
            }
            else if (isForwardShortCut && Input.GetKeyUp(KeyCode.A))
            {
                isForwardShortCut = false;
                isForwardNextStair = false;
                isForwardPrevStair = false;
                buttonCheckImage.gameObject.SetActive(false);
                direction = transform.forward;
                startPos = transform.position;                
                isMoving = true;
                endPos = transform.position + direction * moveDistance * 2;
                duration = Vector3.Distance(startPos, endPos);
                if (directionNum == 0)
                {
                    directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y + 30);
                    playerArrow.playerPos[0] -= 2;
                }
                else if (directionNum == 1)
                {
                    directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x - 30, directionArrowImage.anchoredPosition.y);
                    playerArrow.playerPos[1] -= 2;
                }
                else if (directionNum == 2)
                {
                    directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y - 30);
                    playerArrow.playerPos[0] += 2;
                }
                else if (directionNum == 3)
                {
                    directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x + 30, directionArrowImage.anchoredPosition.y);
                    playerArrow.playerPos[1] += 2;

                }
                foreach (var foe in SceneChanger.instance.FOEs)
                {
                    foe.GetComponent<FOEMove>().ColumnRowCount();
                }
            }
            else if (isForwardNextStair && Input.GetKeyUp(KeyCode.A))
            {
                SceneChanger.instance.FindGameObjects();
                switch (SceneChanger.instance.floor)
                {   
                    case 1:
                        SceneChanger.instance.playerCameraPosition = new Vector3(0.2f, 0.25f, -1.3f);
                        SceneChanger.instance.playerCameraRotation = new Vector3(0f, 90f, 0f);
                        SceneChanger.instance.startPosition = new Vector2(0, 30);
                        SceneChanger.instance.directionArrowPos[0] = 9;
                        SceneChanger.instance.directionArrowPos[1] = 11;
                        SceneChanger.instance.directionArrowRotation = new Vector3(0, 0, 90);
                        SceneChanger.instance.playerObj.GetComponent<PlayerMove>().directionNum = 1;
                        break;
                    case 2:
                        SceneChanger.instance.playerCameraPosition = new Vector3(-6.7f, 0.3f, -1.5f);
                        SceneChanger.instance.playerCameraRotation = new Vector3(0f, 180f, 0f);
                        SceneChanger.instance.startPosition = new Vector2(165, 30);
                        SceneChanger.instance.directionArrowPos[0] = 12;
                        SceneChanger.instance.directionArrowPos[1] = 22;
                        SceneChanger.instance.directionArrowRotation = new Vector3(0, 0, 0);
                        SceneChanger.instance.playerObj.GetComponent<PlayerMove>().directionNum = 0;
                        break;
                    case 3:
                        SceneChanger.instance.playerCameraPosition = new Vector3(-0.55f, -8.9f, 118.5f);
                        SceneChanger.instance.playerCameraRotation = new Vector3(0f, 180f, 0f);
                        SceneChanger.instance.startPosition = new Vector2(0, -90);
                        SceneChanger.instance.directionArrowPos[0] = 13;
                        SceneChanger.instance.directionArrowPos[1] = 2;
                        SceneChanger.instance.directionArrowRotation = new Vector3(0, 0, 0);
                        SceneChanger.instance.playerObj.GetComponent<PlayerMove>().directionNum = 0;
                        break;
                }
                SceneManager.LoadScene("Alice " + (SceneChanger.instance.floor + 1));
                isForwardNextStair = false;
            }
            else if (isForwardPrevStair && Input.GetKeyUp(KeyCode.A))
            {
                SceneChanger.instance.FindGameObjects();

                switch (SceneChanger.instance.floor)
                {
                    case 1:
                        SceneChanger.instance.playerCameraPosition = new Vector3(245, 2, 205);
                        SceneChanger.instance.playerCameraRotation = new Vector3(0f, 180f, 0f);
                        SceneChanger.instance.startPosition = new Vector2(-172f, -150);
                        SceneChanger.instance.directionArrowRotation = new Vector3(0, 0, 0);
                        SceneChanger.instance.playerDirectionNum = 0;
                        SceneManager.LoadScene("OpenField");
                        break;
                    case 2:
                        SceneChanger.instance.playerCameraPosition = new Vector3(-88.5f, 20f, -65f);
                        SceneChanger.instance.playerCameraRotation = new Vector3(0f, 180f, 0f);
                        SceneChanger.instance.startPosition = new Vector2(52.5f, 7.5f);
                        SceneChanger.instance.directionArrowPos[0] = 8;
                        SceneChanger.instance.directionArrowPos[1] = 12;
                        SceneChanger.instance.directionArrowRotation = new Vector3(0, 0, 0);
                        SceneChanger.instance.playerObj.GetComponent<PlayerMove>().directionNum = 0;
                        break;
                    case 3:
                        SceneChanger.instance.playerCameraPosition = new Vector3(-5.8f, 0.25f, -2.5f);
                        SceneChanger.instance.playerCameraRotation = new Vector3(0f, 90f, 0f);
                        SceneChanger.instance.startPosition = new Vector2(150, 60);
                        SceneChanger.instance.directionArrowPos[0] = 7;
                        SceneChanger.instance.directionArrowPos[1] = 21;
                        SceneChanger.instance.directionArrowRotation = new Vector3(0, 0, 90);
                        SceneChanger.instance.playerObj.GetComponent<PlayerMove>().directionNum = 1;
                        break;
                    case 4:
                        SceneChanger.instance.playerCameraPosition = new Vector3(-0.1f, 0.3f, -8.1f);
                        SceneChanger.instance.playerCameraRotation = new Vector3(0, 0, 0);
                        SceneChanger.instance.startPosition = new Vector2(0, 195);
                        SceneChanger.instance.directionArrowPos[0] = 1;
                        SceneChanger.instance.directionArrowPos[1] = 11;
                        SceneChanger.instance.directionArrowRotation = new Vector3(0, 0, 180);
                        SceneChanger.instance.playerObj.GetComponent<PlayerMove>().directionNum = 2;
                        break;
                }
                SceneManager.LoadScene("Alice " + (SceneChanger.instance.floor - 1));
                isForwardPrevStair = false;
            }
        }
    }
}
