using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertoryManager : MonoBehaviour
{
    public slot [] slots;
    public GameObject gameObjectprefab;
    public int maxcount = 8;

    //아이템 추가
    public bool AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slot slot = slots[i];

            //아이템을 인벤토리 안에 위치 시킴
            Item slotitem = slot.GetComponentInChildren<Item>();
            //인벤토리에 같은 아이템이 있을 경우 개수 누적
            if (slot != null && slot.item == item && slot.count < maxcount)
            {
                //갯수 증가
                slot.count++;
                slot.ItemCount();
                return true;
            }

        }
        //비어있는 인벤토리 찾기
        for (int i = 0; i < slots.Length; i++)
        {
            slot slot = slots[i];

            //아이템을 인벤토리 안에 위치 시킴
            Item slotitem = slot.GetComponentInChildren<Item>();
            //인벤토리 슬롯이 비어있으면
            if(slot == null)
            {
                SpawnItem(item, slot);
                return true;
            }
            
        }
        return false;
    }

    //인벤토리에 아이템 생성
    public void SpawnItem(Item item, slot slot)
    {
        //아이템생성
        GameObject items = Instantiate(gameObjectprefab,slot.transform);
        slot Slotitem = items.GetComponent<slot>();
        //아이템 생성 받음 프리팹 할당 
        Slotitem.InitialiseItem(item);
    }
    
}
