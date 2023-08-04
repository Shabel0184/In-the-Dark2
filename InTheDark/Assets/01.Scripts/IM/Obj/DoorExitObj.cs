
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorExitObj : MonoBehaviour
{
    public int doorhandle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemPickUp>() != null && other.GetComponent<ItemPickUp>().item.itemType == Item.ItemType.Exititem)
        {
            switch (other.GetComponent<ItemPickUp>().item.itemName)
            {
                case "DoorHandle":
                    other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                    doorhandle = 1;
                    break;
            }

            //Ż�� ���� �����ߴ��� Ȯ���ϴ� �Լ�
            Exit();
        }
    }
    
    void Start()
    {
        doorhandle = 0;
    }

    void Exit()
    {
        if (doorhandle > 0)
        {
            Debug.Log("exit");
            //Ż�� ���� �̹��� Ȱ��ȭ && Ÿ��Ʋ�� �ε�
        }
    }
}
