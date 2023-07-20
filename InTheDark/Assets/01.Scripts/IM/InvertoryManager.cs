using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertoryManager : MonoBehaviour
{
    public slot [] slots;
    public GameObject gameObjectprefab;
    public int maxcount = 8;

    //������ �߰�
    public bool AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slot slot = slots[i];

            //�������� �κ��丮 �ȿ� ��ġ ��Ŵ
            Item slotitem = slot.GetComponentInChildren<Item>();
            //�κ��丮�� ���� �������� ���� ��� ���� ����
            if (slot != null && slot.item == item && slot.count < maxcount)
            {
                //���� ����
                slot.count++;
                slot.ItemCount();
                return true;
            }

        }
        //����ִ� �κ��丮 ã��
        for (int i = 0; i < slots.Length; i++)
        {
            slot slot = slots[i];

            //�������� �κ��丮 �ȿ� ��ġ ��Ŵ
            Item slotitem = slot.GetComponentInChildren<Item>();
            //�κ��丮 ������ ���������
            if(slot == null)
            {
                SpawnItem(item, slot);
                return true;
            }
            
        }
        return false;
    }

    //�κ��丮�� ������ ����
    public void SpawnItem(Item item, slot slot)
    {
        //�����ۻ���
        GameObject items = Instantiate(gameObjectprefab,slot.transform);
        slot Slotitem = items.GetComponent<slot>();
        //������ ���� ���� ������ �Ҵ� 
        Slotitem.InitialiseItem(item);
    }
    
}
