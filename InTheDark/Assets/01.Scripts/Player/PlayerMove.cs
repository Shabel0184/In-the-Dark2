using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Transform cameraTransform;
    

    float moveSpeed = 5f;
    // 이동 속도
    float currStamina = 100;
    float maxStamina = 100;

    public bool isPlayerDie = false;
    public bool stun = false;
   

    RotateToMouse rotateToMouse; // 마우스 이동으로 카메라 회전
    Rigidbody rb;

    Vector3 moveVec;

    float hAxis;
    float vAxis;
    float mouseX;
    float mouseY;

    bool rDown;

    bool isRun = false;
    
    public Slider staminaBar;
    


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotateToMouse = GetComponentInChildren<RotateToMouse>();
        staminaBar.value = (currStamina / maxStamina) % 100;
        StartCoroutine(Stamina());
        cameraTransform = GetComponentInChildren<Camera>().GetComponent<Transform>();
       
    }

    void FixedUpdate()
    {
        if(isPlayerDie)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        if (!stun)
        {
            Move();
            UpdateRotate();
        }
        GetInput();
        FreezeRotation();
        

        staminaBar.value = (currStamina / maxStamina) % 100;
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
        
        if (isRun && moveVec.magnitude > 0 && currStamina > 1)
        {

            Debug.Log("스테미너 소모");
            currStamina -= 20 * Time.deltaTime;
            transform.position += moveVec * moveSpeed * 2f * Time.deltaTime;
            
        }
        else
        {
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


    //스테미나 회복 
    IEnumerator Stamina()
    {
        while(!isPlayerDie)
        {
            if(!isRun)
            {
                if(currStamina < maxStamina)
                { 
                    currStamina += 10 * Time.deltaTime;
                }
            }
            else
            {
                yield return new WaitForSeconds(3f);
            }
            yield return null;
        }
    }

}
