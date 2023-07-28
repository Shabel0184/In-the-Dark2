using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    //지속시간
    public float curTime;
    //최대 지속시간
    public float lifeTime = 20f;

    AudioSource _audio;
    public AudioClip clip;
    
    int enemyLayer = 11;

    private void OnEnable()
    {
        //최초 지속시간 0으로
        curTime = 0;
        _audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        //최대 지속시간 보다 지속시간이 적다면
        if(curTime < lifeTime) 
        {
            //지속시간 초당 1씩 증가
            curTime += 1f * Time.deltaTime;
        }
        else
        {
            //최대 지속시간을 넘어가면 비활성화
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //플레이어 충돌 시
        if(collision.collider.CompareTag("Player"))
        {
            curTime = 0;
            //플레이어 정지 함수(이벤트) 호출
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
