using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    //MoveAgent ��ũ��Ʈ 
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
        //�Ҵ�
        moveAgent = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<MoveAgent>();
        enemyAI = moveAgent.gameObject.GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
