using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    EnemyAI enemyAI;

   
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            //플레이어 사망 메서드 호출
            enemyAI.PlayerDie();
            //플레이어 사망시 더 이상 움직이지 못 하게
            collision.collider.GetComponent<PlayerMove>().isPlayerDie = true;


        }
    }

}
