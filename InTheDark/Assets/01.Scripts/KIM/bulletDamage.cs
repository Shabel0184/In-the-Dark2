using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy�� Ż���� õ�� �־�־���
public class bulletDamage : MonoBehaviour
{
    EnemyAI enemyAI;
    public GameObject Particle;//õ Ÿ�������� ���� ��ƼŬ
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
