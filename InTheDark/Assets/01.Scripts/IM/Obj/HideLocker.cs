using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLocker : MonoBehaviour
{
    int isHide = 0;
    
    public Vector3 doorOffset;
    
    public float moveDuration = 1f; // 이동에 걸리는 시간

    private void Awake()
    {
        doorOffset = transform.position;
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
        //캐비닛 상호작용 중

        switch (isHide)
        {
            case 0: //캐비닛 OUT
                yield return new WaitForSeconds(0.5f);
                //문 닫힘
                transform.position = doorOffset;
                break;

            case 1: //캐비닛 IN
                
                //문 열림
                transform.Translate(0, 0, -1.5f);
                yield return new WaitForSeconds(0.2f);
                
                break;
        }
    }
}
