using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAsset : MonoBehaviour
{
   public static ItemAsset instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public Sprite amuletsprite;
    public Sprite firecrackersprite;
    public Sprite flaregunsprite;
    public Sprite mirrorsprite;
    public Sprite airtanksprite;
    public Sprite booksprite;
    public Sprite Fueltanksprite;
    public Sprite Carkeysprite;
    public Sprite matchboxsprite;
    public Sprite ropesprite;
    public Sprite harnesssprite;
    public Sprite climbingAxesprite;
    public Sprite doorhandlesprite;
    public Sprite flashlightsprite;
}
