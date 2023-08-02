using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    

    [SerializeField]
    private GameObject SlotsParent; //Grid

    private Slot[] slots;

    private void Start()
    {
        slots = SlotsParent.GetComponentsInChildren<Slot>();
    }

    //아이템 습득
    public void AcquireItem(Item _item, int _count = 1)
    {
        //탈출 아이템이 아니면 개수 표시
        if(Item.ItemType.Exititem != _item.itemType)
        {
            for(int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null) //null이면 slots[i].item.itemName 할 떄 런타임 에러남
                {
                    //아이템 이름이 같으면 카운트 증가
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for(int i=0; i< slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item,_count);
                return;
            }
        }
    }
}
