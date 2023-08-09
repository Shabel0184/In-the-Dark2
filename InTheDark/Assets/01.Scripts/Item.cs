using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/newitem")]
public class Item : ScriptableObject // ���� ������Ʈ�� ���� �ʿ� x
{
    
    public enum ItemType // ������ ����
    {
        PlayerItem,
        Exititem,
    }

    public string itemName; // ������ �̸�
    public ItemType itemType; // ������ ����
    public Sprite itemImage; //�������� �̹��� (������ �ȿ� ���)
    public GameObject itemPrefab; // �������� ������
    public GameObject CreatePrefab; //�����ʿ��� �����Ǵ� ������ ������

    public int exititemUse = 0;

}