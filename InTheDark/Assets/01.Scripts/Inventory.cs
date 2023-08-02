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

    //������ ����
    public void AcquireItem(Item _item, int _count = 1)
    {
        //Ż�� �������� �ƴϸ� ���� ǥ��
        if(Item.ItemType.Exititem != _item.itemType)
        {
            for(int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null) //null�̸� slots[i].item.itemName �� �� ��Ÿ�� ������
                {
                    //������ �̸��� ������ ī��Ʈ ����
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
