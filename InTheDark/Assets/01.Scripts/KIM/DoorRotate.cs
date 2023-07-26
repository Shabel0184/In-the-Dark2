using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Player" && Input.GetKeyDown(KeyCode.F))
        {
                DoorOpen();
        }
        else
        {
            DoorClose();
        }

        if (other.CompareTag("ENEMY"))
        {
            DoorOpen();
        }

    }

    void DoorOpen()
    {
        Debug.Log("����");
        anim.SetBool("Open", true);
        anim.SetBool("Close", false);
    }

    void DoorClose()
    {
        Debug.Log("����");
        anim.SetBool("Open", false);
        anim.SetBool("Close", true);
    }
}
