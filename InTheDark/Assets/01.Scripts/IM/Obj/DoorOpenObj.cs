using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenObj : MonoBehaviour
{
    public int carkey;
    DoorRotate dooropen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemPickUp>() != null && other.GetComponent<ItemPickUp>().item.itemType == Item.ItemType.Exititem)
        {
            switch (other.GetComponent<ItemPickUp>().item.itemName)
            {
                case "CarKey":
                    other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                    carkey = 1;
                    break;
            }

            //탈출 조건 충족했는지 확인하는 함수
            Exit();
        }
    }

    void Start()
    {
        carkey = 0;
    }

    void Exit()
    {
        if (carkey > 0)
        {
            Debug.Log("exit");

            dooropen = gameObject.GetComponent<DoorRotate>();
            dooropen.DoorOpen();
            //탈출 성공 이미지 활성화 && 타이틀씬 로드
        }
    }
}
