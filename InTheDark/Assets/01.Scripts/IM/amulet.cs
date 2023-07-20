using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amulet : MonoBehaviour
{
    public GameObject amulets;
    public GameObject enemy;

    bool stun;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) &&other.CompareTag("ENEMY"))
        {
            StartCoroutine(Stun());
        }
    }

    IEnumerator Stun()
    {
        if(stun == false)
        {
            Time.timeScale = 0f;
            stun = true;
        }
        yield return new WaitForSecondsRealtime(1f);

        if(stun == true)
        {
            Time.timeScale = 1f;
            stun = false;
        }
    }


}
