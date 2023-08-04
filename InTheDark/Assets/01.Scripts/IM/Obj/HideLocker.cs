using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HideLocker : MonoBehaviour
{
    int isHide = 0;
    
    
   
    Rigidbody rb;
    
    public float moveDuration = 1f; // 이동에 걸리는 시간

    private void Awake()
    {
        //doorOffset = transform.position;
       
    }
    private void Start()
    {
        
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("HideIn / 0 -> 1");

            rb.isKinematic = true;


        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("HideOut -> 0");
            rb.isKinematic = false;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("HideOut -> 0");
            rb.isKinematic = false;
           
        }
       
    }
   /* private void OnTriggerStay(Collider other)
    {
        if (isHide < 1 && other.CompareTag("Player") && Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("HideIn / 0 -> 1");
            isHide = 1;
            rb.isKinematic = true;
            door.DoorOpen();

        }
        else if (isHide > 0 && other.CompareTag("Player") && Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("HideOut -> 0");
            isHide = 0;
            rb.isKinematic = false;
            door.DoorOpen();

        }
        else
        {
            door.DoorClose();
        }
       
    }
*/
    /*IEnumerator HideDoor(Collider playerCollider)
    {
        //캐비닛 상호작용 중

        switch (isHide)
        {
            
            case 0: //캐비닛 OUT
                rb.isKinematic = true;
                yield return new WaitForSeconds(0.5f);
                //문 닫힘
                //doorOffset = transform.position;
                door.DoorClose();
                break;

            case 1: //캐비닛 IN
                rb.isKinematic = true;
                //문 열림
                //transform.Translate(0, 0, -1.5f);
                door.DoorOpen();
                yield return new WaitForSeconds(0.2f);
                
                break;
        }
    }*/
}
