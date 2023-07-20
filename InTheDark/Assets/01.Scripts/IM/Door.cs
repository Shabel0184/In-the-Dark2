using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    int Count = 0;
   
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("박았다.");
        if(other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && Count == 0)
            {
                transform.Translate(0, 0, 4f);
                Count = 1;
                Debug.Log("문열어");
            }
            else if(Input.GetKeyDown(KeyCode.F) && Count > 0)
            {
                transform.Translate(0, 0, -4f);
                Count = 0;
            }
        }

        if(other.CompareTag("ENEMY") && Count == 0)
        {
            transform.Translate(0, 0, 4f);
            Count = 1;
        }
        
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
