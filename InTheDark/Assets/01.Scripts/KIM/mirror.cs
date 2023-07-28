using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class mirror : MonoBehaviour
{

    public GameObject player;
    public GameObject _mirror;
    public Image image;
    Color color;

    private void Start()
    {
        color = Color.white;
        color.a = 0f;
        image = GetComponentInChildren<Image>();
        image.color = color;
    }

    void Update()
    {
      if(Input.GetButtonDown("1") && CompareTag("Mirror"))
      { 
            //랜덤스폰 호출
            SpwanPoints(); 
            //페이드인 코루틴 호출
            StartCoroutine(FadeIn()); 
           
      }
       
    }


    //플레이어 스폰 포인트에서 랜덤 스폰
    void SpwanPoints()
    {
       Transform[]spawnpoint = GameObject.Find("PlayerspawnpointGroup").GetComponentsInChildren<Transform>();
       int point = Random.Range(1, spawnpoint.Length);
       player.transform.position = spawnpoint[point].transform.position;
       
    }

    //화면 페이드 인
    IEnumerator FadeIn()
    {
            while(color.a < 1) 
            {
                color.a += 0.1f;
                yield return new WaitForSeconds(0.05f);
                image.color = color;
            }

        //페이드 아웃 코루틴호출(페이드인에서 바로 페이드아웃)
        StartCoroutine(FadeOut());

    }
   
    //화면 페이드 아웃
    IEnumerator FadeOut()
    {
        color.a = 1f;
        while(color.a > 0) 
        {
            color.a -= 0.1f;
            yield return new WaitForSeconds(0.05f);
            image.color = color;
        }

    }
    
   
}
