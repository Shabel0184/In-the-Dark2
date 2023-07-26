using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotController : MonoBehaviour
{
    [SerializeField] Slot[] quickSlots; // 퀵슬롯들
    [SerializeField] Transform tf_parent; // 퀵슬롯들의 부모 오브젝트

    int selectedSlot; // 선택된 퀵슬롯의 인덱스
    [SerializeField] GameObject go_SelectedIamge; // 선택된 퀵슬롯의 이미지


    void Start()
    {
        quickSlots = tf_parent.GetComponentsInChildren<Slot>();
        selectedSlot = 0;
    }

    void Update()
    {
        TryInputNumber();
    }

    void TryInputNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeSlot(4);
        else if(Input.GetKeyDown(KeyCode.Alpha6))
            ChangeSlot(5);
    }

    void ChangeSlot(int _num)
    {
        SelectedSlot(_num);
    }

    void SelectedSlot(int _num)
    {
        // 선택된 슬롯
        selectedSlot = _num;

        // 선택된 슬롯으로 이미지 이동
        go_SelectedIamge.transform.position = quickSlots[selectedSlot].transform.position;
    }

}
