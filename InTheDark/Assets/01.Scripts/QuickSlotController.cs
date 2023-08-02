using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Progress;

public class QuickSlotController : MonoBehaviour
{
    [SerializeField] Slot[] quickSlots; // �����Ե�
    [SerializeField] Transform tf_parent; // �����Ե��� �θ� ������Ʈ

   
    public Item selectItem;

    public int selectedSlot; // ���õ� �������� �ε���
    [SerializeField] GameObject go_SelectedIamge; // ���õ� �������� �̹���
    public int count = 0;

    private bool notput;
    void Start()
    {
        quickSlots = tf_parent.GetComponentsInChildren<Slot>();
        selectedSlot = 0;
        
    }

    void Update()
    {
        TryInputNumber();
    }

    public void TryInputNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //ChangeSlot(0);
           // Useitem();
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeSlot(4);
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            ChangeSlot(5);
    }
   /* void Useitem()
    {
        selectItem.Use();

    }*/
    void ChangeSlot(int _num)
    {
        SelectedSlot(_num);
    }

    void SelectedSlot(int _num)
    {
        // ���õ� ����
        selectedSlot = _num;

        // ���õ� �������� �̹��� �̵�
        go_SelectedIamge.transform.position = quickSlots[selectedSlot].transform.position;

    }

    //������ ����
    public void AcquireItem(Item _item, int count = 1)
    {
        PutSlot(_item, count);
        if(notput)
        {
            PutSlot(_item, count);
        }
        
    }

    private void PutSlot(Item _item, int count)
    {
        //Ż�� �������� �ƴϸ� ���� ǥ��
        if (Item.ItemType.Exititem != _item.itemType)
        {
            for (int i = 0; i < quickSlots.Length; i++)
            {
                if (quickSlots[i].item != null) //null�̸� slots[i].item.itemName �� �� ��Ÿ�� ������
                {
                    //������ �̸��� ������ ī��Ʈ ����
                    if (quickSlots[i].item.itemName == _item.itemName)
                    {
                        quickSlots[i].SetSlotCount(count);
                        notput = false;
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < quickSlots.Length; i++)
        {
            if (quickSlots[i].item == null)
            {
                quickSlots[i].AddItem(_item, count);
                notput = false;
                return;
            }
        }
        notput = true;
    }
  
}
