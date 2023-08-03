using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy와 탈출할 천에 넣어둬야함
public class bulletDamage : MonoBehaviour
{
    EnemyAI enemyAI;
    public GameObject Particle;//천 타고있을때 쓰는 파티클
    flarebullet flarebullet;

    void Start()
    {
        flarebullet = GetComponent<flarebullet>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("ENEMY") )
        {
            enemyAI = collision.collider.GetComponent<EnemyAI>();
            StartCoroutine(StunEnemy());
        }
        else if (collision.collider.CompareTag("OBSTACLE"))
        {
            flarebullet.rb.velocity = Vector3.zero;
            flarebullet.rb.useGravity = true;
            flarebullet.a = 1;
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
       
        if(enemyAI != null )
        {
            enemyAI.isStun = 1;
        }
        flarebullet.rb.velocity = Vector3.zero;
        flarebullet.rb.useGravity = true;
        flarebullet.a = 1;
        yield return new WaitForSeconds(3f);
    }
}
