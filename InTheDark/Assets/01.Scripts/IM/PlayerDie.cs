using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDie : MonoBehaviour
{
    EnemyAI enemyAI;
    GameObject gameOverPanel;
   
    // Start is called before the first frame update
    void Start()
    {
        /* enemyAI = GetComponent<EnemyAI>();
         gameOverPanel = GameObject.Find("GameOverImage");
         gameOverPanel.SetActive(false);*/
        StartCoroutine(PanelOff());
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
            gameOverPanel.SetActive(true);

        }
    }

    public void PlayerDieEvent()
    {
        //�÷��̾� ��� �޼��� ȣ��
        enemyAI.PlayerDie();
        gameOverPanel.SetActive(true);
    }


    IEnumerator PanelOff()
    {
        enemyAI = GetComponent<EnemyAI>();
        gameOverPanel = GameObject.Find("GameOverImage");
        yield return new WaitForSeconds(0.2f);
        gameOverPanel.SetActive(false);
    }

}
