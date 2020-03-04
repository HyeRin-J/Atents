using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOEMove : MonoBehaviour
{
    //이동할 칸수(세로, 가로 순)
    public int[] movingCount = new int[2];
    public PlayerMove playerMove;
    public bool isMoving;
    public bool isRotating;
    public bool isForwardPlayer = false;
    public bool isColumnMoving = false;
    public bool isRowMoving = false;
    public bool columnFlag = false;
    public bool rowFlag = false;
    public int columnCount = 0;
    public int rowCount = 0;

    float duration = 0.0f;
    float movingTime = 0.0f;
    public float speed = 10f;
    public float moveDistance = 0;

    Vector3 startPos;
    Vector3 endPos;
    Vector3 moveDirection;

    public RectTransform directionArrowImage;
    public Animator foeAnimator;

    public int foeNum = 1;

    // Use this for initialization
    void Start()
    {
        playerMove = SceneChanger.instance.playerObj.GetComponent<PlayerMove>();
        moveDistance = playerMove.moveDistance;
        foeAnimator = GetComponent<Animator>();
        foeAnimator.SetBool("Waiting", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isForwardPlayer)
        {
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.up * moveDistance, Color.yellow);

            if (Physics.Raycast(transform.position, transform.up, out hit, moveDistance))
            {
                if (hit.collider.CompareTag("Player") && !playerMove.isMoving)
                {
                    float angle = Vector3.SignedAngle(-transform.up, playerMove.transform.forward, Vector3.up);
                    playerMove.RotateSetting(angle);
                    foeAnimator.SetTrigger("FoeAttack");
                    isForwardPlayer = false;
                    isMoving = false;
                }
                return;
            }
        }
        //이동중
        if (isMoving)
        {
            movingTime += Time.deltaTime * speed;
            float frac = movingTime / duration;

            transform.rotation = Quaternion.LookRotation(transform.forward, moveDirection);

            if(duration != 0)
                transform.position = Vector3.Lerp(startPos, endPos, frac);

            //어느정도 이동하면 위치 고정
            if (Vector3.Distance(transform.position, endPos) <= 0.1f)
            {
                transform.position = endPos;
                movingTime = 0.0f;
                isMoving = false;
                foeAnimator.SetBool("Moving", false);
                foeAnimator.SetBool("Waiting", true);
                if (isRotating)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
                    isRotating = false;
                }
            }
        }
        AnimatorStateInfo animatorState = foeAnimator.GetCurrentAnimatorStateInfo(0);
        if (animatorState.IsName("Foe_Attack") && animatorState.normalizedTime >= 1.0f)
        {
            SceneChanger.instance.foeId = foeNum;
            SceneChanger.instance.spawnCase = SpawnCase.Foe;
            playerMove.GetComponent<Encounter>().LoadBattleScene();
        }
    }

    public void ColumnRowCount()
    {
        Vector3 arrowDirection = playerMove.directionArrowImage.position - directionArrowImage.position;
        float distance = Vector3.Distance(directionArrowImage.transform.localPosition, playerMove.directionArrowImage.transform.localPosition);
        if (distance <= 15 && arrowDirection.normalized == directionArrowImage.up.normalized)
        {
            isForwardPlayer = true;
            return;
        }

        isMoving = true;

        foeAnimator.SetBool("Moving", true);
        foeAnimator.SetBool("Waiting", false);

        startPos = transform.position;
        moveDirection = Vector3.zero;

        if (isColumnMoving)
        {
            if (!columnFlag)
            {
                columnCount++;

                directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y - 15);
                moveDirection = Vector3.forward;

                if (columnCount == movingCount[0])
                {
                    directionArrowImage.transform.Rotate(0, 0, 90);
                    isColumnMoving = false;
                    columnFlag = true;
                    isRowMoving = true;
                    isRotating = true;
                }
            }
            else if (columnFlag)
            {
                columnCount--;

                directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x, directionArrowImage.anchoredPosition.y + 15);
                moveDirection = Vector3.back;

                if (columnCount == 0)
                {
                    directionArrowImage.transform.Rotate(0, 0, 90);
                    isColumnMoving = false;
                    columnFlag = false;
                    isRowMoving = true;
                    isRotating = true;

                }
            }
            endPos = transform.position + moveDirection * playerMove.moveDistance;
            duration = Vector3.Distance(startPos, endPos);
            return;
        }
        else if (isRowMoving)
        {
            if (rowFlag)
            {
                rowCount--;

                directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x - 15, directionArrowImage.anchoredPosition.y);
                moveDirection = Vector3.right;

                if (rowCount == 0)
                {
                    directionArrowImage.transform.Rotate(0, 0, 90);
                    isRowMoving = false;
                    rowFlag = false;
                    isColumnMoving = true;
                    isRotating = true;

                }
            }
            else if (!rowFlag)
            {
                rowCount++;

                directionArrowImage.anchoredPosition = new Vector2(directionArrowImage.anchoredPosition.x + 15, directionArrowImage.anchoredPosition.y);
                moveDirection = Vector3.left;

                if (rowCount == movingCount[1])
                {
                    directionArrowImage.transform.Rotate(0, 0, 90);
                    isRowMoving = false;
                    rowFlag = true;
                    isColumnMoving = true;
                    isRotating = true;

                }
            }
            endPos = transform.position + moveDirection * playerMove.moveDistance;
            duration = Vector3.Distance(startPos, endPos);
            return;
        }

    }
}
