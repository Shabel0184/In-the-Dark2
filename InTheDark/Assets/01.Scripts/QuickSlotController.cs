using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Progress;

public class QuickSlotController : MonoBehaviour
{
    [SerializeField] Slot[] quickSlots; // 퀵슬롯들
    [SerializeField] Transform tf_parent; // 퀵슬롯들의 부모 오브젝트
    public GameObject flaregun;
    int itemIndex;
    bool itemUse;

    public Item selectItem;

    public int selectedSlot; // 선택된 퀵슬롯의 인덱스
    [SerializeField] GameObject go_SelectedIamge; // 선택된 퀵슬롯의 이미지
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
            
            StartCoroutine(_Useitem2(0));
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha2) && itemUseing < 1)
        {
            StartCoroutine(_Useitem2(1));
            ChangeSlot(1);
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha3) && itemUseing < 1)
        {
            StartCoroutine(_Useitem2(2));
            ChangeSlot(2);
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha4) && itemUseing < 1)
        {
            StartCoroutine(_Useitem2(3));
            ChangeSlot(3);
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha5) && itemUseing < 1)
        {
            StartCoroutine(_Useitem2(4));
            ChangeSlot(4);
        }
            
        else if (Input.GetKeyDown(KeyCode.Alpha6) && itemUseing < 1)
        {
            StartCoroutine(_Useitem2(5));
            ChangeSlot(5);
        }
            
    }
    /*IEnumerator _Useitem(int num)
    {
        itemUseing = 1;

        selectItem = quickSlots[num].item;
        if (quickSlots[num].itemUse())
        {
            if(selectItem.itemName == "firecracker")
            {
                 GameObject _item = Instantiate(selectItem.itemPrefab);
                 yield return new WaitForSeconds(1f);
                 itemUseing = 0;
            }
            else
            {
                GameObject _item = Instantiate(selectItem.itemPrefab);
                Destroy(gameObject);
            }
            
        }
        else
        {
            yield return null;
        }
    }*/




    IEnumerator _Useitem2(int num)
    {
        if (quickSlots[num] != null)
        {
            itemUseing = 1;
            selectItem = quickSlots[num].item;
            quickSlots[num].itemUse2(out itemIndex, out itemUse);
            if (itemUse)
            {
                switch (itemIndex)
                {
                    case 0:
                        GameObject _item = Instantiate(selectItem.itemPrefab);
                        yield return new WaitForSeconds(1f);
                        itemUseing = 0;
                        //estroy( _item );
                        break;
                    case 1:
                        _item = Instantiate(selectItem.itemPrefab);
                        yield return new WaitForSeconds(1f);
                        itemUseing = 0;
                        break;
                    case 2:
                        flaregun.SetActive(true);
                        itemUseing = 0;
                        break;
                    case 3:
                        _item = Instantiate(selectItem.itemPrefab);
                        yield return new WaitForSeconds(1f);
                        itemUseing = 0;
                        Destroy(_item );
                        break;
                    default:
                        itemUseing = 0;
                        break;
                }

            }
            else
            {
                yield return null;
            }
        }
        yield return null;
    }



    void ChangeSlot(int _num)
    {
        SelectedSlot(_num);
    }

    void SelectedSlot(int _num)
    {
        // 선택된 슬롯
        selectedSlot = _num;

        // 선택된 슬롯으로 이미지 이동
        go_SelectedIamge.transform.position = quickSlots[selectedSlot].transform.position;

    }

    //아이템 습득
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
        //탈출 아이템이 아니면 개수 표시
        if (Item.ItemType.Exititem != _item.itemType)
        {
            for (int i = 0; i < quickSlots.Length; i++)
            {
                if (quickSlots[i].item != null) //null이면 slots[i].item.itemName 할 떄 런타임 에러남
                {
                    //아이템 이름이 같으면 카운트 증가
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
