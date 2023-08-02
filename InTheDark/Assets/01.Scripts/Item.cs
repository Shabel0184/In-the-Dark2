using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/newitem")]
public class Item : ScriptableObject // 게임 오브젝트에 붙일 필요 x
{
    public enum ItemType // 아이템 유형
    {
        PlayerItem,
        Exititem,
    }

    public string itemName; // 아이템 이름
    public ItemType itemType; // 아이템 유형
    public Sprite itemImage; //아이템의 이미지 (퀵슬롯 안에 띄움)
    public GameObject itemPrefab; // 아이템의 프리팹
    public List<ItemEffect> effects; // 아이템 효과 리스트


    /*public bool Use()
    {
        bool isUesd = false;
        //반복문 사용해서 excute 실행
        foreach (ItemEffect effect in effects)
        {
            isUesd = effect.Excute();
        }
        return false;
    }*/

    public void Use()
    {
        
        //반복문 사용해서 excute 실행
        foreach (ItemEffect effect in effects)
        {
            effect.Excute();
        }
        
    }


}