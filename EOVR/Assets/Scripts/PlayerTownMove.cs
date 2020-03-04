using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTownMove : MonoBehaviour {

    static PlayerTownMove instance;

    public static PlayerTownMove _instance
    {
        get { return instance; }
    }

    Vector3 targetPosition;
	public Vector3 curPosition;
	float offset = 1f;
    float curTime = 0f;
    private float mouseX = 10.0f;
    private float mouseY = 10.0f;
    public float rotationSpeed;
    public float moveSpeed = 7.0f;
    private float moveHorizontal = 0.0f;
    private float moveVertical = 0.0f;
    public bool isMove = false;

    private void Start()
	{
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void FixedUpdate()
	{

        mouseY = Input.GetAxis("Mouse Y"); // 좌우 회전
        mouseX = Input.GetAxis("Mouse X"); // 좌우 회전
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0.0f);
        curPosition = transform.position;

        if (isMove == false) { transform.position = curPosition; return; }

        #region Character Controller

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 MoveDirection = (Vector3.forward * moveVertical) + (Vector3.right * moveHorizontal);
        transform.Translate(MoveDirection.normalized * moveSpeed * Time.deltaTime, Space.Self);

        #endregion

        #region Mouse Pointer Moving
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    if (isMove == true)
        //        return;

        //    curTime = 0;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 15.0f) && hit.collider.tag == "MovePoint")
        //    {
        //        Transform hitObjTR = hit.transform;
        //        //targetPosition = hit.point;
        //        targetPosition = hitObjTR.position;
        //        //targetPosition = targetPosition + new Vector3(0, offset, 0);
        //        isMove = true;
        //    }
        //}
        //if(isMove==true)
        //{
        //    Moving();
        //}
        #endregion
    }

    private void Moving()
    {
        curTime += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPosition, curTime);

        if (targetPosition == curPosition)
        {
            isMove = false;
        }
    }

}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WandController : MonoBehaviour
//{
//    // have SteamVR Prefabs : CameraRig -> Controller(left)   or   Controller(right)
//    //  https://www.youtube.com/watch?v=LZTctk19sx8  참고 동영상
//    //
//    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
//    public bool gripButtonDown = false;
//    public bool gripButtonUp = false;
//    public bool gripButtonPressed = false;

//    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
//    public bool triggerButtonDown = false;
//    public bool triggerButtonUp = false;
//    public bool triggerButtonPressed = false;

//    private SteamVR_TrackedObject trackedObj;
//    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

//    // Use this for initialization
//    void Start()
//    {
//        trackedObj = GetComponent<SteamVR_TrackedObject>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (controller == null)
//        {
//            Debug.Log("Controller not initialized");
//            return;
//        }

//        gripButtonDown = controller.GetPressDown(gripButton);
//        gripButtonUp = controller.GetPressUp(gripButton);
//        gripButtonPressed = controller.GetPress(gripButton);

//        triggerButtonDown = controller.GetPressDown(triggerButton);
//        triggerButtonUp = controller.GetPressUp(triggerButton);
//        triggerButtonPressed = controller.GetPress(triggerButton);

//        if (gripButtonDown)
//        {
//            Debug.Log("Grip Button was just pressed");
//        }
//        if (gripButtonUp)
//        {
//            Debug.Log("Grip Button was just unpressed");
//        }
//        if (triggerButtonDown)
//        {
//            Debug.Log("Trigger Button was just pressed");
//        }
//        if (triggerButtonUp)
//        {
//            Debug.Log("Trigger Button was just unpressed");
//        }
//    }
//}
