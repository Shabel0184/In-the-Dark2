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

            //탈출 조건 충족했는지 확인하는 함수
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
            //자동차 탈출 성공 이미지 활성화 && 타이틀씬 로드
        }
    }
}
