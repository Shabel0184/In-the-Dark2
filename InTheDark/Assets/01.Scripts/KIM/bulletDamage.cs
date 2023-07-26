using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy�� Ż���� õ�� �־�־���
public class bulletDamage : MonoBehaviour
{
    MoveAgent moveAgent;
    public GameObject Particle;
    
    void Start()
    {
        moveAgent = GetComponent<MoveAgent>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("BULLET") )
        {
            Destroyfabric();
            StartCoroutine(StunEnemy());
        }
    }

    //õ ����
    void Destroyfabric()
    {
        GameObject fabric = GameObject.Find("Fabric");
        Instantiate(Particle, transform.position, transform.rotation);
        Destroy(fabric,3);
    }

    //�� ����
    IEnumerator StunEnemy()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("ENEMY");
        if(enemy != null )
        {
            moveAgent.Stop();
        }
        
        yield return new WaitForSeconds(3f);
    }
}
