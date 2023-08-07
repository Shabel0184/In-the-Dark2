using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    QuickSlotController QuickSlotController;

    [SerializeField]
    float range; //아이템 습득이 가능한 최대 거리
    bool pickupActivated = false; //아이템 습득 가능할 시 true
    RaycastHit hitInfo; // 충돌체 정보 저장

    //[SerializeField]
    //LayerMask layerMask; // 특정 레이어를 가진 오브젝트에 대해서만 습득할 수 있어야 한다.

    [SerializeField]
    Text actionText; // 행동을 보여 줄 텍스트

    //레이어 마스크 비트 연산
    const int itemLayer = 1 << 6;
    const int drawerLayer = 1 << 20;
    //OR로 두 개의 레이어 
    int _layerMask = itemLayer | drawerLayer;

    int isDarwer = 0;

    public Slot[] solts;
    int soltsLength;

    private void Start()
    {
        solts = QuickSlotController.quickSlots;
        soltsLength = solts.Length;
    }
    void Update()
    {
        CheckItem();
    }

    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, _layerMask))
        {
            if (hitInfo.transform.tag == "ITEM")
            {
                ItemInfoAppear();
                if (Input.GetKeyUp(KeyCode.E))
                {
                    CanPickUp();
                }
            }
            else if (hitInfo.transform.tag == "DRAWERS")
            {
                Debug.Log("서랍 충돌");
                DrawerAppear();
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Debug.Log("서랍 열기 키 누름");
                    hitInfo.collider.GetComponent<DrawerCheck>().OpenClose();

                }
            }

        }
        else
        {
            ItemInfoDisappear();
        }
    }

    void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득" + "<color=yellow>" + "(E)" + "</color>";
    }
    void DrawerAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "상호작용" + "<color=yellow>" + "(E)" + "</color>";
    }

    void ItemInfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                //Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 했습니다."); //퀵슬롯에 넣기
                if (hitInfo.transform.tag == "ITEM")
                {
                    Item _item = hitInfo.transform.GetComponent<ItemPickUp>().item;
                    int a = 0, b = 0;
                    for (int i = 0; i < solts.Length; i++)
                    {
                        if (solts[i].item != null)
                        {
                            if ((solts[i].item.itemName == _item.itemName && solts[i].itemCount > 5) || (solts[i].item.itemName == _item.itemName && solts[i].item.itemType == Item.ItemType.Exititem))
                            {
                                a = 1;
                                break;
                            }
                        }
                        else
                        {
                            b = 1;
                        }
                    }
                    if (a > 0)
                    {
                        return;
                    }
                    else if (a < 1 && b > 0)
                    {
                        Destroy(hitInfo.transform.gameObject);
                        ItemInfoDisappear();
                        QuickSlotController.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    }
                    else if (a > 0 && b > 0)
                    {
                        Destroy(hitInfo.transform.gameObject);
                        ItemInfoDisappear();
                        QuickSlotController.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    }
                    else if (b > 0)
                    {
                        return;
                    }
                }


            }

        }

    }





}

