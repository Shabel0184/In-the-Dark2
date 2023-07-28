using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    //���ӽð�
    public float curTime;
    //�ִ� ���ӽð�
    public float lifeTime = 20f;

    AudioSource _audio;
    public AudioClip clip;
    
    int enemyLayer = 11;

    private void OnEnable()
    {
        //���� ���ӽð� 0����
        curTime = 0;
        _audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        //�ִ� ���ӽð� ���� ���ӽð��� ���ٸ�
        if(curTime < lifeTime) 
        {
            //���ӽð� �ʴ� 1�� ����
            curTime += 1f * Time.deltaTime;
        }
        else
        {
            //�ִ� ���ӽð��� �Ѿ�� ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�÷��̾� �浹 ��
        if(collision.collider.CompareTag("Player"))
        {
            curTime = 0;
            //�÷��̾� ���� �Լ�(�̺�Ʈ) ȣ��
            StartCoroutine(PlayerStun(collision.collider));
            Collider[] coll = Physics.OverlapSphere(transform.position, 30f, 1 << enemyLayer);
            if(coll.Length > 0)
            {
                var AI = coll[0].GetComponent<EnemyAI>();
                AI.isTrapping = 1;
            }

        }
    }


    IEnumerator PlayerStun(Collider PlayerColl)
    {
        PlayerColl.GetComponent<PlayerMove>().stun = true;
        _audio.PlayOneShot(clip, 1f);
        yield return new WaitForSeconds(3f);
        PlayerColl.GetComponent<PlayerMove>().stun = false;
        gameObject.SetActive(false);

    }

}
