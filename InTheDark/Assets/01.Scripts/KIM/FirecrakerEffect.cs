using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/PlayerItem/Firecracker")]
public class FirecrakerEffect : ItemEffect
{
    firecracker firecracker;
    public override bool Excute()
    {
       if(GameObject.Find("firecracker"))
       {
            firecracker.fireUseItem();
       }
        
        Debug.Log("used");
        return true;
    }
}
