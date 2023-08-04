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

    public GameObject keypad;

        void Update()
        {
            CheckItem();
        OnKeyPad();
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
            //actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "ȹ��" + "<color=yellow>" + "(E)" + "</color>";
        }
        void DrawerAppear()
        {
            pickupActivated = true;
            actionText.gameObject.SetActive(true);
            actionText.text = "����" + "<color=yellow>" + "(E)" + "</color>";
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
                    if(hitInfo.transform.tag == "ITEM")
                    {
                        Destroy(hitInfo.transform.gameObject);
                        ItemInfoDisappear();
                    }
                   

                }
                QuickSlotController.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
            }

        }

        void OnKeyPad()
        {
            LayerMask mask = LayerMask.NameToLayer("LockDoor");
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 20,mask))
            {
                if (hitInfo.collider.tag == "LockDoor" && Input.GetKeyDown(KeyCode.E))
                {
                    keypad.SetActive(true);
                }
            }
        }





    }

