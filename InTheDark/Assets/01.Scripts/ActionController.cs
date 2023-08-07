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
    float range; //������ ������ ������ �ִ� �Ÿ�
    bool pickupActivated = false; //������ ���� ������ �� true
    RaycastHit hitInfo; // �浹ü ���� ����

    //[SerializeField]
    //LayerMask layerMask; // Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ������ �� �־�� �Ѵ�.

    [SerializeField]
    Text actionText; // �ൿ�� ���� �� �ؽ�Ʈ

    //���̾� ����ũ ��Ʈ ����
    const int itemLayer = 1 << 6;
    const int drawerLayer = 1 << 20;
    //OR�� �� ���� ���̾� 
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
                Debug.Log("���� �浹");
                DrawerAppear();
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Debug.Log("���� ���� Ű ����");
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
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "ȹ��" + "<color=yellow>" + "(E)" + "</color>";
    }
    void DrawerAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "��ȣ�ۿ�" + "<color=yellow>" + "(E)" + "</color>";
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
                //Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� �߽��ϴ�."); //�����Կ� �ֱ�
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

