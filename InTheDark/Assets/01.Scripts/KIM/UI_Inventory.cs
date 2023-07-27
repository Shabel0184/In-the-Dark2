 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UI_Inventory : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public RectTransform Slottranform;
    public Transform itemimage;

    private void Awake()
    {
        Slottranform = GetComponentInChildren<RectTransform>();
        itemimage = Slottranform.GetComponentInChildren<Transform>();
    }
    
    //아이템 정보 받기
    public void SetInventory(InventoryItem inventory)
    {
        this.inventoryItem = inventory;
        RefreshInven();
    }


    public void RefreshInven()
    {
        int x = 0;
        float itemslotSize = 35f;
        foreach(ItemData itemData in inventoryItem.GetItemDatas())
        {
            //아이템 이미지 생성
            RectTransform itemrectTransform = Instantiate(itemimage,Slottranform).GetComponent<RectTransform>();
            //아이템 이미지 활성화
            itemrectTransform.gameObject.SetActive(true);

            //그리드레이아웃
            itemrectTransform.anchoredPosition = new Vector2(x*itemslotSize,0);
            Image image = itemrectTransform.Find("image").GetComponent<Image>();
            image.sprite = itemData.GetPlayerSprite();
            image.sprite = itemData.GetExitSprite();
            x++;
        }
    }
}
