using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
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
                Debug.Log("서랍 충돌");
                DrawerAppear();
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Debug.Log("서랍 열기 키 누름");
                    
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
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "획득" + "<color=yellow>" + "(E)" + "</color>";
    }
    void DrawerAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "열기" + "<color=yellow>" + "(E)" + "</color>";
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
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 했습니다."); //퀵슬롯에 넣기
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
