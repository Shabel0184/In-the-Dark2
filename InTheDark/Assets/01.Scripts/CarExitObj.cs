using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExitObj : MonoBehaviour
{
    public int carKey;
    public int book;
    public int fueltank;


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Item>() != null)
        {
            if(other.GetComponent<Item>().itemType == Item.ItemType.Exititem)
            {
                switch(other.GetComponent<Item>().itemName)
                {
                    case "CarKey":
                        other.GetComponent<Item>().exititemUse = 1;
                        carKey = 1;
                        break;
                    case "Book":
                        other.GetComponent<Item>().exititemUse = 1;
                        book = 1;
                        break;
                    case "Fueltank":
                        other.GetComponent<Item>().exititemUse = 1;
                        fueltank = 1;
                        break;
                }
            }
            //Ż�� ���� �����ߴ��� Ȯ���ϴ� �Լ�

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
            //�ڵ��� Ż�� ���� �̹��� Ȱ��ȭ
        }
    }
}
