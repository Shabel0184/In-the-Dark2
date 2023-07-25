using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform cameraTransform;
    public Camera cam;

    public float moveSpeed = 2f;
    // 이동 속도
    public float currStamina = 100;
    public float maxStamina = 100;
    // 캐릭터 스태미너


    RotateToMouse rotateToMouse; // 마우스 이동으로 카메라 회전
    Rigidbody rb;

    Vector3 moveVec;

    float hAxis;
    float vAxis;
    float mouseX;
    float mouseY;

    bool rDown;

    bool isRun = false;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotateToMouse = GetComponent<RotateToMouse>();
    }

    void FixedUpdate()
    {

        FreezeRotation();
        UpdateRotate();
        Move();
        GetInput();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        rDown = Input.GetButton("Run");

        isRun = rDown;
    }

    void Move()
    {
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        moveVec = cameraForward * vAxis + cameraRight * hAxis;
        moveVec.Normalize();

        if (isRun && moveVec.magnitude > 0 && currStamina > 10)
        {

            Debug.Log("스테미너 소모");
            currStamina -= 20 * Time.deltaTime;
            transform.position += moveVec * moveSpeed * 2f * Time.deltaTime;

        }
        else
        {
            if (currStamina < maxStamina)
            {
                Debug.Log("스테미너 회복");
                currStamina += 15 * Time.deltaTime;
            }
            transform.position += moveVec * moveSpeed * Time.deltaTime;
        }





    }

    void FreezeRotation()
    {
        rb.angularVelocity = Vector3.zero;
    }

    void UpdateRotate()
    {
        rotateToMouse.CalculateRotation(mouseX, mouseY);
    }

}
