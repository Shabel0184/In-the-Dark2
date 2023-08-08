using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField]
    //MoveAgent 스크립트 
    GameObject[] enemys;
    [SerializeField]
    MoveAgent moveAgent;
    [SerializeField]
    EnemyAI enemyAI;

    private void OnTriggerEnter(Collider other)
    {
        //플레이어 충돌 시
        if(other.CompareTag("Player") && enemyAI.state != EnemyAI.State.TRACE)
        {
            //MoveAget의 SpWn함수 
            moveAgent.Spawn();
            //귀신 오브젝트 비활성화
            moveAgent.gameObject.SetActive(false);
            //활성화
            moveAgent.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemys = GameObject.FindGameObjectsWithTag("ENEMY");
        for(int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i].GetComponent<EnemyAI>().type == EnemyAI.Type.TRAP)
            {
                moveAgent = enemys[i].GetComponent<MoveAgent>();
                enemyAI = enemys[i].GetComponent<EnemyAI>();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
