using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotController : MonoBehaviour
{
    [SerializeField] Slot[] quickSlots; // �����Ե�
    [SerializeField] Transform tf_parent; // �����Ե��� �θ� ������Ʈ

    int selectedSlot; // ���õ� �������� �ε���
    [SerializeField] GameObject go_SelectedIamge; // ���õ� �������� �̹���


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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeSlot(4);
        else if(Input.GetKeyDown(KeyCode.Alpha5))
            ChangeSlot(5);
    }

    void ChangeSlot(int _num)
    {
        SelectedSlot(_num);
    }

    void SelectedSlot(int _num)
    {
        // ���õ� ����
        selectedSlot = _num;

        // ���õ� �������� �̹��� �̵�
        go_SelectedIamge.transform.position = quickSlots[selectedSlot].transform.position;
    }

}
