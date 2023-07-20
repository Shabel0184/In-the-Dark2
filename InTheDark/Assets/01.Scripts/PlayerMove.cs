using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform cameraTransform;
    public Camera cam;

    public float moveSpeed = 2f;
    // �̵� �ӵ�
    public float currStamina = 100;
    public float maxStamina = 100;
    // ĳ���� ���¹̳�


    RotateToMouse rotateToMouse; // ���콺 �̵����� ī�޶� ȸ��
    Rigidbody rb;

    Vector3 moveVec;

    float hAxis;
    float vAxis;
    float mouseX;
    float mouseY;

    bool rDown;

    bool isRun;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotateToMouse = GetComponent<RotateToMouse>();
    }

    void Update()
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

        if (!isRun && rDown && moveVec.magnitude > 0)
        {
            if (currStamina > 1)
            {
                currStamina -= 20 * Time.deltaTime;
                transform.position += moveVec * moveSpeed * 3f * Time.deltaTime;
            }
            
        }

        if (currStamina < maxStamina)
        {
            currStamina += 5 * Time.deltaTime;
        }

        transform.position += moveVec * moveSpeed * Time.deltaTime;

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
