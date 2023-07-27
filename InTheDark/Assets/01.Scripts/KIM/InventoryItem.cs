using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    private List<ItemData> itemDatas;
    public InventoryItem()
    {
        itemDatas = new List<ItemData>();
        //플레이어 아이템
        AddItem(new ItemData { PlayerType = ItemData.playerType.amulet, stacksize = 3 });
        AddItem(new ItemData { PlayerType = ItemData.playerType.FireCracker, stacksize = 6 });
        AddItem(new ItemData { PlayerType = ItemData.playerType.FlareGun, stacksize = 3 });
        AddItem(new ItemData { PlayerType = ItemData.playerType.amulet, stacksize = 1 });
        //탈출아이템
        AddItem(new ItemData { ExitType = ItemData.exitType.airtank, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.Matchbox, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.FuelTank, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.DoorHandle, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.rope, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.ClimbingAxe, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.book, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.CarKey, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.Flashlight, stacksize = 1 });
        AddItem(new ItemData { ExitType = ItemData.exitType.Harness, stacksize = 1 });
    }
    public void AddItem(ItemData item)
    {
        itemDatas.Add(item);
    }
    public List<ItemData> GetItemDatas()
    {
        return itemDatas;
    }
}
