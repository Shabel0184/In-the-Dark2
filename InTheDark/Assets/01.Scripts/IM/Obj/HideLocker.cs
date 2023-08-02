using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HideLocker : MonoBehaviour
{
    int isHide = 0;
    
    public Vector3 doorOffset;
    DoorRotate door;
    Rigidbody rb;
    
    public float moveDuration = 1f; // �̵��� �ɸ��� �ð�

    private void Awake()
    {
        //doorOffset = transform.position;
       
    }
    private void Start()
    {
        door = GetComponent<DoorRotate>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (isHide < 1 && other.CompareTag("Player") && Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("HideIn / 0 -> 1");
            isHide = 1;
            StartCoroutine(HideDoor(other));

        }
        else if (isHide > 0 && other.CompareTag("Player") && Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("HideOut -> 0");
            isHide = 0;
            StartCoroutine(HideDoor(other));

        }
       
    }

    IEnumerator HideDoor(Collider playerCollider)
    {
        //ĳ��� ��ȣ�ۿ� ��

        switch (isHide)
        {
            
            case 0: //ĳ��� OUT
                rb.isKinematic = true;
                yield return new WaitForSeconds(0.5f);
                //�� ����
                //doorOffset = transform.position;
                door.DoorClose();
                break;

            case 1: //ĳ��� IN
                rb.isKinematic = true;
                //�� ����
                //transform.Translate(0, 0, -1.5f);
                door.DoorOpen();
                yield return new WaitForSeconds(0.2f);
                
                break;
        }
    }
}
