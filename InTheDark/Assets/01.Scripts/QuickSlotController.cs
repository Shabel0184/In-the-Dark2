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
    int itemUseing = 0;
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
        if (Input.GetKeyDown(KeyCode.Alpha1) && itemUseing < 1)
        {
            
            StartCoroutine(_Useitem(0));
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha2) && itemUseing < 1)
        {
            StartCoroutine(_Useitem(1));
            ChangeSlot(1);
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha3) && itemUseing < 1)
        {
            StartCoroutine(_Useitem(2));
            ChangeSlot(2);
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha4) && itemUseing < 1)
        {
            StartCoroutine(_Useitem(3));
            ChangeSlot(3);
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha5) && itemUseing < 1)
        {
            StartCoroutine(_Useitem(4));
            ChangeSlot(4);
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha6) && itemUseing < 1)
        {
            StartCoroutine(_Useitem(5));
            ChangeSlot(5);
        }
            
    }
    IEnumerator _Useitem(int num)
    {
        itemUseing = 1;

        selectItem = quickSlots[num].item;
        if (quickSlots[num].itemUse())
        {
            GameObject _item = Instantiate(selectItem.itemPrefab);
            yield return new WaitForSeconds(1f);
            itemUseing = 0;
        }
        else
        {
            yield return null;
        }
    }


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
