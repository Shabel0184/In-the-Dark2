using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarExitObj : MonoBehaviour
{
    public int carKey;
    public int book;
    public int fueltank;


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ItemPickUp>() != null && other.GetComponent<ItemPickUp>().item.itemType == Item.ItemType.Exititem)
        {
                switch(other.GetComponent<ItemPickUp>().item.itemName)
                {
                    case "CarKey":
                        other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                        carKey = 1;
                        break;
                    case "Book":
                        other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                        book = 1;
                        break;
                    case "Fueltank":
                        other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                        fueltank = 1;
                        break;
                }
            
            //Ż�� ���� �����ߴ��� Ȯ���ϴ� �Լ�
            Exit();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        carKey = 0;
        book = 0;
        fueltank = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Exit()
    {
        if(carKey > 0 && book > 0 && fueltank > 0) 
        {
            Debug.Log("exit");
            //�ڵ��� Ż�� ���� �̹��� Ȱ��ȭ && Ÿ��Ʋ�� �ε�
        }
    }
}
