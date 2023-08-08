using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WellExitObj : MonoBehaviour
{
    public int Flashlight;
    public int airtank;
    public int rope;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemPickUp>() != null && other.GetComponent<ItemPickUp>().item.itemType == Item.ItemType.Exititem)
        {
            switch (other.GetComponent<ItemPickUp>().item.itemName)
            {
                case "FlashLight":
                    other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                    Flashlight = 1;
                    break;
                case "airtank":
                    other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                    airtank = 1;
                    break;
                case "Rope":
                    other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                    rope = 1;
                    break;
            }

            //Ż�� ���� �����ߴ��� Ȯ���ϴ� �Լ�
            Exit();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Flashlight = 0;
        airtank = 0;
    }

    void Exit()
    {
        if (Flashlight > 0 && airtank > 0 && rope > 0)
        {
            Debug.Log("exit");
            //�ڵ��� Ż�� ���� �̹��� Ȱ��ȭ && Ÿ��Ʋ�� �ε�
        }
    }
}
