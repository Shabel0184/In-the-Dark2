using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
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

    public float drawerSpeed = 1f;
    public float drawerDist = 0.3f;
    
    void Update()
    {
        CheckItem();
        //TryAction();
    }

    void TryAction()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
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
                    //CheckItem();
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
                    
                    DrawerAction(hitInfo.collider);
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
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� �߽��ϴ�."); //�����Կ� �ֱ�
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }


    void DrawerAction(Collider hit)
    {
        var drCheck = hit.GetComponent<DrawerCheck>();
        Vector3 endPoint = drCheck.startPoint + new Vector3(drawerDist, hit.transform.position.y, hit.transform.position.z);
        float progress = 0f;
        isDarwer =drCheck.drawerState;
        switch (isDarwer)
        {
            case 0:
                while (progress < 1)
                {
                    progress += Time.deltaTime * drawerSpeed;
                    progress = Mathf.Clamp01(progress);
                    hit.transform.position = Vector3.Lerp(drCheck.startPoint, endPoint, progress);
                }
                hit.GetComponent<DrawerCheck>().drawerState = 1;
                break;
            case 1:
                progress += Time.deltaTime * drawerSpeed;
                progress = Mathf.Clamp01(progress);
                hit.transform.position = Vector3.Lerp(endPoint, drCheck.startPoint, progress);
                hit.GetComponent<DrawerCheck>().drawerState = 0;
                break;
        }
        
    }


}
