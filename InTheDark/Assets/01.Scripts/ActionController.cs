using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    float range; //������ ������ ������ �ִ� �Ÿ�
    bool pickupActivated = false; //������ ���� ������ �� true
    RaycastHit hitInfo; // �浹ü ���� ����

    [SerializeField]
    LayerMask layerMask; // Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ������ �� �־�� �Ѵ�.

    [SerializeField]
    Text actionText; // �ൿ�� ���� �� �ؽ�Ʈ


    void Update()
    {
        CheckItem();
        TryAction();
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
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if(hitInfo.transform.tag == "ITEM")
            {
                ItemInfoAppear();
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

    void ItemInfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    void CanPickUp()
    {
        if(pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� �߽��ϴ�."); //�����Կ� �ֱ�
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }


}
