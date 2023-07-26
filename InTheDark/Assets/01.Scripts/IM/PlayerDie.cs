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
            //�÷��̾� ��� �޼��� ȣ��
            enemyAI.PlayerDie();
            //�÷��̾� ����� �� �̻� �������� �� �ϰ�
            collision.collider.GetComponent<PlayerMove>().isPlayerDie = true;


        }
    }

}
