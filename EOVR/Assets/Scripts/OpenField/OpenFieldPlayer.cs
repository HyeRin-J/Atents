using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenFieldPlayer : MonoBehaviour {
    public bool isMoving = false;
    public bool isRotating = false;
    float duration = 0.0f;
    float movingTime = 0.0f;
    public float speed = 49f;
    public float moveDistance = 0;
    public GameObject pointLight;

    Vector3 startPos;
    Vector3 endPos;
    Quaternion endRot;

    public Image buttonCheckImage;
    public Image mapImage;
    public Sprite[] openFieldMaps;
    public Image directionArrowImage;
    public int directionNum;
    RectTransform airBalloon;

    float colorTime;

    int currentFloor = 1;
    public float maxFloor = 1;

    public Material[] skyboxes;

    bool isForwardLabyrinthGate = false;

    // Use this for initialization
    void Start ()
    {
        colorTime = Time.time;
        directionNum = SceneChanger.instance.playerDirectionNum;
        airBalloon = directionArrowImage.rectTransform.parent.GetComponent<RectTransform>();
        airBalloon.anchoredPosition = SceneChanger.instance.startPosition;
        directionArrowImage.transform.localEulerAngles = SceneChanger.instance.directionArrowRotation;
        transform.position = SceneChanger.instance.playerCameraPosition;
        transform.eulerAngles = SceneChanger.instance.playerCameraRotation;
    }
	
	// Update is called once per frame
	void Update ()
    {       
        if (Time.time - colorTime > .5f)
        {
            if (directionArrowImage.GetComponent<Outline>().effectColor.a == 0f)
                directionArrowImage.GetComponent<Outline>().effectColor = new Color(1, 1, 1, 1);
            else
                directionArrowImage.GetComponent<Outline>().effectColor = new Color(1, 1, 1, 0);

            colorTime = Time.time;
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
                if (transform.position.x >= 225 && transform.position.z >= 165)
                {
                    Camera.main.GetComponent<Skybox>().material = skyboxes[1];
                    pointLight.GetComponent<Light>().enabled = true;
                }
                else
                {
                    Camera.main.GetComponent<Skybox>().material = skyboxes[0];
                    pointLight.GetComponent<Light>().enabled = false;
                }

                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, moveDistance))
                {
                    if (hit.collider.CompareTag("LabyrinthGate"))
                    {
                        isForwardLabyrinthGate = true;
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
                    if (hit.collider.CompareTag("LabyrinthGate"))
                    {
                        isForwardLabyrinthGate = true;
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
            Debug.DrawRay(Camera.main.transform.position, transform.forward * moveDistance, Color.yellow);
            Debug.DrawRay(Camera.main.transform.position, -transform.forward * moveDistance, Color.blue);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    direction = transform.up;
                    startPos = transform.position;
                    if (currentFloor < maxFloor)
                    {
                        isMoving = true;
                        endPos = transform.position + direction * 10;
                        currentFloor++;
                        mapImage.sprite = openFieldMaps[currentFloor - 1];
                    }
                }
                else if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    direction = -transform.up;
                    startPos = transform.position;

                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.transform.position, direction, out hit, moveDistance))
                    {

                    }
                    else
                    {
                        if (currentFloor > 1)
                        {
                            isMoving = true;
                            endPos = transform.position + direction * 10;
                            currentFloor--;
                            mapImage.sprite = openFieldMaps[currentFloor - 1];
                        }
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                direction = transform.forward;
                startPos = transform.position;

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, moveDistance))
                {
                    if (hit.collider.CompareTag("Wall"))
                        Debug.Log("Wall");
                    else if (hit.collider.CompareTag("ShortCut"))
                    {
                        endPos = transform.position + direction * moveDistance * 2;
                        isMoving = true;
                    }
                    else if (hit.collider.CompareTag("LabyrinthGate"))
                    {

                    }
                    else if (hit.collider.name.Equals("Terrain"))
                        Debug.Log("Terrain");
                    else
                    {
                        isMoving = true;
                        endPos = transform.position + direction * moveDistance;
                        if (directionNum == 0)
                        {
                            airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x, airBalloon.anchoredPosition.y + 15f);
                        }
                        else if (directionNum == 1)
                        {
                            airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x - 15f, airBalloon.anchoredPosition.y);
                        }
                        else if (directionNum == 2)
                        {
                            airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x, airBalloon.anchoredPosition.y - 15f);
                        }
                        else if (directionNum == 3)
                        {
                            airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x + 15f, airBalloon.anchoredPosition.y);
                        }
                    }
                }
                else
                {
                    isMoving = true;
                    endPos = transform.position + direction * moveDistance;
                    if (directionNum == 0)
                    {
                        airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x, airBalloon.anchoredPosition.y + 15f);
                    }
                    else if (directionNum == 1)
                    {
                        airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x - 15f, airBalloon.anchoredPosition.y);
                    }
                    else if (directionNum == 2)
                    {
                        airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x, airBalloon.anchoredPosition.y - 15f);
                    }
                    else if (directionNum == 3)
                    {
                        airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x + 15f, airBalloon.anchoredPosition.y);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                direction = -transform.forward;
                startPos = transform.position;
                isForwardLabyrinthGate = false;
                buttonCheckImage.gameObject.SetActive(false);
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, -Camera.main.transform.forward, out hit, moveDistance))
                {
                    Debug.Log("Wall");
                }
                else
                {
                    isMoving = true;
                    endPos = transform.position + direction * moveDistance;
                    if (directionNum == 0)
                    {
                        airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x, airBalloon.anchoredPosition.y - 15f);
                    }
                    else if (directionNum == 1)
                    {
                        airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x + 15f, airBalloon.anchoredPosition.y);
                    }
                    else if (directionNum == 2)
                    {
                        airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x, airBalloon.anchoredPosition.y + 15f);
                    }
                    else if (directionNum == 3)
                    {
                        airBalloon.anchoredPosition = new Vector2(airBalloon.anchoredPosition.x - 15f, airBalloon.anchoredPosition.y);
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
                isForwardLabyrinthGate = false;
                buttonCheckImage.gameObject.SetActive(false);
                directionArrowImage.transform.Rotate(Vector3.forward, -90f);
                directionNum--;
                if (directionNum <= -1) directionNum = 3;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                endRot = transform.rotation * Quaternion.Euler(0, -90, 0);
                isRotating = true;
                isForwardLabyrinthGate = false;
                buttonCheckImage.gameObject.SetActive(false);
                directionArrowImage.transform.Rotate(Vector3.forward, 90f);
                directionNum++;
                if (directionNum >= 4) directionNum = 0;
            }
            if (isForwardLabyrinthGate && Input.GetKeyUp(KeyCode.A))
            {
                SceneChanger.instance.playerCameraPosition = new Vector3(8.5f, 20f, 128.8f);
                SceneChanger.instance.playerCameraRotation = new Vector3(0f, 180f, 0f);
                SceneChanger.instance.startPosition = new Vector2(-7, -113f);
                SceneChanger.instance.directionArrowPos[0] = 16;
                SceneChanger.instance.directionArrowPos[1] = 8;
                SceneChanger.instance.directionArrowRotation = new Vector3(0, 0, 0);
                SceneManager.LoadScene("Alice 1");
            }
        }
    }
}
