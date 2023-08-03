using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/newitem")]
public class Item : ScriptableObject // 게임 오브젝트에 붙일 필요 x
{
    private void Awake()
    {
        exititemUse = 0;
    }
    public enum ItemType // 아이템 유형
    {
        PlayerItem,
        Exititem,
    }

    public string itemName; // 아이템 이름
    public ItemType itemType; // 아이템 유형
    public Sprite itemImage; //아이템의 이미지 (퀵슬롯 안에 띄움)
    public GameObject itemPrefab; // 아이템의 프리팹

    public int exititemUse = 0;

}