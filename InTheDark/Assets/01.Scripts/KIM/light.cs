using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class light : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject smartphone;
    private bool flashlightactive = false;

    
    void Start()
    {
        flashlight.gameObject.SetActive(false);
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && CompareTag("smartphone"))
        {
            if(flashlightactive == false)
            {
                //라이트 활성화
                flashlight.gameObject.SetActive(true);
                flashlightactive = true;
            }
            else
            {
                //라이트 비활성화
                flashlight.gameObject.SetActive(false);
                flashlightactive = false;
            }
        }
        
    }
}
