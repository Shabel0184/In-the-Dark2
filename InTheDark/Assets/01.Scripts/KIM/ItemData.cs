using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour 
{
    [Header("Item")]
    public string itemName;
    public Sprite itemImage;
    public GameObject prefab;
    public int stacksize;

    public playerType PlayerType;
    public enum playerType
    {
        amulet, Mirror, FireCracker, FlareGun
    }

    public exitType ExitType;
    public enum exitType
    {
        airtank, book, CarKey, ClimbingAxe, DoorHandle, Flashlight, FuelTank, Harness, Matchbox, rope
    }

    public Sprite GetPlayerSprite()
    {
        switch(PlayerType)
        {
            default:
            case playerType.amulet:
                return ItemAsset.instance.amuletsprite;
            case playerType.FlareGun:
                return ItemAsset.instance.flaregunsprite;
            case playerType.FireCracker:
                return ItemAsset.instance.firecrackersprite;
            case playerType.Mirror:
                return ItemAsset.instance.mirrorsprite;
        }
    }
    public Sprite GetExitSprite()
    {
        switch(ExitType)
        {
            default:
            case exitType.Harness:
                return ItemAsset.instance.harnesssprite;
            case exitType.CarKey:
                return ItemAsset.instance.Carkeysprite;
            case exitType.ClimbingAxe:
                return ItemAsset.instance.climbingAxesprite;
            case exitType.DoorHandle:
                return ItemAsset.instance.doorhandlesprite;
            case exitType.Flashlight:
                return ItemAsset.instance.flashlightsprite;
            case exitType.book:
                return ItemAsset.instance.booksprite;
            case exitType.airtank:
                return ItemAsset.instance.airtanksprite;
            case exitType.FuelTank:
                return ItemAsset.instance.Fueltanksprite;
            case exitType.Matchbox:
                return ItemAsset.instance.matchboxsprite;
            case exitType.rope:
                return ItemAsset.instance.ropesprite;
        }
    }

}
