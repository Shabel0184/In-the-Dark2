using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class amulet : MonoBehaviour
{
    
    //public EnemyAI enemyAI;
    public int laymask;// 레이어 저장
    public Collider[] coll;

    Transform Cam;

    private void Awake()
    {
        laymask = LayerMask.NameToLayer("ENEMY");
        Cam = GameManager.instance.camPos;
        transform.position = Cam.position;
    }
    void Start()
    {
        StartCoroutine(Stun());
       
    }


    IEnumerator Stun()
    {
        yield return null;
        coll = Physics.OverlapSphere(transform.position, 10f,  1 << laymask);
        

        if(coll.Length > 0)
        {
            EnemyAI enemyAI = coll[0].GetComponent<EnemyAI>();
            enemyAI.isStun = 1;
        }
       
      
        yield return new WaitForSecondsRealtime(3f);

    }


}
