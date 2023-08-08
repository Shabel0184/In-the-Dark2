using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField]
    //MoveAgent ��ũ��Ʈ 
    GameObject[] enemys;
    [SerializeField]
    MoveAgent moveAgent;
    [SerializeField]
    EnemyAI enemyAI;

    private void OnTriggerEnter(Collider other)
    {
        //�÷��̾� �浹 ��
        if(other.CompareTag("Player") && enemyAI.state != EnemyAI.State.TRACE)
        {
            //MoveAget�� SpWn�Լ� 
            moveAgent.Spawn();
            //�ͽ� ������Ʈ ��Ȱ��ȭ
            moveAgent.gameObject.SetActive(false);
            //Ȱ��ȭ
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
