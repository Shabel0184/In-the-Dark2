using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item",menuName = "New Item/item")]
public class Item : ScriptableObject // ���� ������Ʈ�� ���� �ʿ� x
{
    public enum ItemType // ������ ����
    {
        Equipment,
        normal,
        Special,
    }

    public string itemName; // ������ �̸�
    public ItemType itemType; // ������ ����
    public Sprite itemImage; //�������� �̹��� (������ �ȿ� ���)
    public GameObject itemPrefab; // �������� ������


}
