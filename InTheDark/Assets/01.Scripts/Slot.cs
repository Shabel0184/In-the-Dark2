using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템의 개수
    public Image itemImage; // 아이템 이미지
    

    bool itempull;

    [SerializeField]
    Text text_Count;
    [SerializeField]
    GameObject go_CountImage;
    public GameObject a;



    private void Start()
    {
        //a = go_CountImage.GetComponentInChildren<Image>().gameObject.GetComponent<Image>().gameObject;
        a = transform.GetChild(0).transform.GetChild(0).gameObject;
    }

    // 아이템 이미지의 투명도 조절
    void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if (item.itemType == Item.ItemType.PlayerItem)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else if (item.itemType == Item.ItemType.Exititem)
        {
            go_CountImage.SetActive(true);
            a.SetActive(false);
            
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);

    }

    // 해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotCount(int _count)
    {
        if (itemCount < 6)
        {
            itempull = false;
        }
        else
        {
            itempull = true;
        }

        if (!itempull)
        {
            itemCount += _count;
            text_Count.text = itemCount.ToString();
            itempull = false;

            if (itemCount <= 0)
                ClearSlot();
            
        }
        else
        {
            return;
        }


    }

   


   
    public void itemUse2(out int index, out bool _itemUse)
    {

        index = 0;
        _itemUse = false;

        if (item != null && itemCount > 0 && item.itemType != Item.ItemType.Exititem) 
        {
           

            switch (item.itemName)
            {
                case "Amulet":
                    index = 0;
                    _itemUse = true;
                    break;
                case "firecracker":
                    index = 1;
                    _itemUse = true;
                    break;
                case "FlareGun":
                    index = 2;
                    _itemUse = true;
                    break;
                case "Mirror":
                    index = 3;
                    _itemUse = true;
                    break;

            } 
            itemCount--;
            if (itemCount == 0)
            {
                ClearSlot();
            }
            text_Count.text = itemCount.ToString();
        }
        else if (item != null && itemCount > 0 && item.itemType == Item.ItemType.Exititem)
        {
            int exindex;
            //GameObject _item = Instantiate(item.itemPrefab, GameManager.instance.camPos);

            GameObject __item; 
            switch (item.itemName)
            {
                case "airtank":
                    exindex = 0;
                    __item = GameManager.instance.exitpools[exindex].gameObject;
                    __item.transform.position = GameManager.instance.camPos.position;
                    __item.SetActive(true);
                    StartCoroutine(obfalse(__item));

                    index = 5;
                    _itemUse = true;
                    break;
                case "Book":
                    exindex = 1;
                    __item = GameManager.instance.exitpools[exindex].gameObject;
                    __item.transform.position = GameManager.instance.camPos.position;
                    __item.SetActive(true);
                    StartCoroutine(obfalse(__item));

                    index = 5;
                    _itemUse = true;
                    break;
               case "CarKey":
                    exindex = 2;
                    __item = GameManager.instance.exitpools[exindex].gameObject;
                    __item.transform.position = GameManager.instance.camPos.position;
                    __item.SetActive(true);
                    StartCoroutine(obfalse(__item));

                    index = 5;
                    _itemUse = true;
                    break;
                case "DoorHandle":
                    exindex = 3;
                    __item = GameManager.instance.exitpools[exindex].gameObject;
                    __item.transform.position = GameManager.instance.camPos.position;
                    __item.SetActive(true);
                    StartCoroutine(obfalse(__item));

                    index = 5;
                    _itemUse = true;
                    break;
                case "FlashLight":
                    exindex = 4;
                    __item = GameManager.instance.exitpools[exindex].gameObject;
                    __item.transform.position = GameManager.instance.camPos.position;
                    __item.SetActive(true);
                    StartCoroutine(obfalse(__item));

                    index = 5;
                    _itemUse = true;
                    break;
                case "Fueltank":
                    exindex = 5;
                    __item = GameManager.instance.exitpools[exindex].gameObject;
                    __item.transform.position = GameManager.instance.camPos.position;
                    __item.SetActive(true);
                    StartCoroutine(obfalse(__item));

                    index = 5;
                    _itemUse = true;
                    break;
                case "MatchBox":
                    exindex = 6;
                    __item = GameManager.instance.exitpools[exindex].gameObject;
                    __item.transform.position = GameManager.instance.camPos.position;
                    __item.SetActive(true);
                    StartCoroutine(obfalse(__item));

                    index = 5;
                    _itemUse = true;
                    break;
                
            }
            // Destroy(_item.gameObject, 0.5f);
            
        }
        else
        {
            index = 5;
            _itemUse = true;
        }



    }

    // 해당 슬롯 하나 삭제
    void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }


    IEnumerator obfalse(GameObject a)
    {
        //yield return new WaitForSeconds(0.1f);
        yield return null;
        if(a.GetComponent<ItemPickUp>().item.exititemUse > 0)
        {
            //ExitUseing = 1;
            itemCount--;
            ClearSlot();
        }
        //yield return new WaitForSeconds(0.1f);
        yield return null;
        a.SetActive(false);

    }

}
