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
                //����Ʈ Ȱ��ȭ
                flashlight.gameObject.SetActive(true);
                flashlightactive = true;
            }
            else
            {
                //����Ʈ ��Ȱ��ȭ
                flashlight.gameObject.SetActive(false);
                flashlightactive = false;
            }
        }
        
    }
}
