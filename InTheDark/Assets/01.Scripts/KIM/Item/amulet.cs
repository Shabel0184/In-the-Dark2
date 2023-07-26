using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class amulet : MonoBehaviour
{
    public GameObject amulets;
    public GameObject enemy;
    MoveAgent moveAgent;
    public LayerMask laymask;// 레이어 저장
    

    bool stun;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            moveAgent = other.GetComponent<MoveAgent>();
            StartCoroutine(Stun());
        }
    }

    IEnumerator Stun()
    {
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit rayhit;

        if(Physics.Raycast(ray, out rayhit,10,laymask))
        {
            if (rayhit.collider.CompareTag("ENEMY"))
            {
                moveAgent.Stop();
            }
            
        }
      
        yield return new WaitForSecondsRealtime(3f);

    }


}
