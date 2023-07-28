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
            //�������� ȣ��
            SpwanPoints(); 
            //���̵��� �ڷ�ƾ ȣ��
            StartCoroutine(FadeIn()); 
           
      }
       
    }


    //�÷��̾� ���� ����Ʈ���� ���� ����
    void SpwanPoints()
    {
       Transform[]spawnpoint = GameObject.Find("PlayerspawnpointGroup").GetComponentsInChildren<Transform>();
       int point = Random.Range(1, spawnpoint.Length);
       player.transform.position = spawnpoint[point].transform.position;
       
    }

    //ȭ�� ���̵� ��
    IEnumerator FadeIn()
    {
            while(color.a < 1) 
            {
                color.a += 0.1f;
                yield return new WaitForSeconds(0.05f);
                image.color = color;
            }

        //���̵� �ƿ� �ڷ�ƾȣ��(���̵��ο��� �ٷ� ���̵�ƿ�)
        StartCoroutine(FadeOut());

    }
   
    //ȭ�� ���̵� �ƿ�
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
