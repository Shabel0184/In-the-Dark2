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
    
    //������ ���� �ޱ�
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
            //������ �̹��� ����
            RectTransform itemrectTransform = Instantiate(itemimage,Slottranform).GetComponent<RectTransform>();
            //������ �̹��� Ȱ��ȭ
            itemrectTransform.gameObject.SetActive(true);

            //�׸��巹�̾ƿ�
            itemrectTransform.anchoredPosition = new Vector2(x*itemslotSize,0);
            Image image = itemrectTransform.Find("image").GetComponent<Image>();
            image.sprite = itemData.GetPlayerSprite();
            image.sprite = itemData.GetExitSprite();
            x++;
        }
    }
}
