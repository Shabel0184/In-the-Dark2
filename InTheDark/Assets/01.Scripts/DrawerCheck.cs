using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrawerCheck : MonoBehaviour
{
    public int drawerState = 0;

    public Vector3 startPoint;
    public Vector3 endPoint;

    void Start()
    {
        startPoint = transform.position;
        endPoint = transform.right + new Vector3(0.001f, 0f, 0f);
        //endPoint.z = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenClose()
    {
        switch (drawerState)
        {
            case 0:
                //transform.position = Vector3.Lerp(startPoint, endPoint, 1);
                transform.position += endPoint;
                
                drawerState = 1;
                break;
            case 1:
                //transform.position = Vector3.Lerp(endPoint, startPoint, 1);
                transform.position = startPoint;
                drawerState = 0;
                break;
        }
    }
}
