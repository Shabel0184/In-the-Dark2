using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public Image image; //���� �̹���
    public Item item; // ������
    public GameObject prefab; // ������ ������Ʈ
    public int count = 1; //������ ���� ����
    public Text countText; //������ ���� �ؽ�Ʈ
    
    //������ ���� ����
    public void InitialiseItem(Item newitem)
    {
        item = newitem;
        //image.sprite = newitem.image;
        //prefab = newitem.GameObject;
        ItemCount();
    }

    //���� �ʱ�ȭ
    public void ItemCount()
    {
        countText.text = count.ToString();
        //1���ϰ�� ���� ǥ�� ����
        bool textable = count > 1;
        countText.gameObject.SetActive(textable);
    }

   
}
