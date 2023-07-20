using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public Image image; //슬롯 이미지
    public Item item; // 아이템
    public GameObject prefab; // 아이템 오브젝트
    public int count = 1; //아이템 개수 저장
    public Text countText; //아이템 개수 텍스트
    
    //아이템 정보 저장
    public void InitialiseItem(Item newitem)
    {
        item = newitem;
        //image.sprite = newitem.image;
        //prefab = newitem.GameObject;
        ItemCount();
    }

    //개수 초기화
    public void ItemCount()
    {
        countText.text = count.ToString();
        //1개일경우 갯수 표시 지움
        bool textable = count > 1;
        countText.gameObject.SetActive(textable);
    }

   
}
