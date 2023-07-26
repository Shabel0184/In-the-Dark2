using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    //���ӽð�
    public float curTime;
    //�ִ� ���ӽð�
    public float lifeTime = 20f;


    private void OnEnable()
    {
        //���� ���ӽð� 0����
        curTime = 0;
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
            //�÷��̾� ���� �Լ�(�̺�Ʈ) ȣ��

            //������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);

        }
    }

}
