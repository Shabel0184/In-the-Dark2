using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy와 탈출할 천에 넣어둬야함
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

    //천 제거
    void Destroyfabric()
    {
        GameObject fabric = GameObject.Find("Fabric");
        Instantiate(Particle, transform.position, transform.rotation);
        Destroy(fabric,3);
    }

    //적 스턴
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
