using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

//��ũ��Ʈ�޴� ���� ����
[CreateAssetMenu(menuName ="Scriptable object/item")]
public class Item2 : ScriptableObject
{
    public TileBase tile;   
    public Items item;
    public Itemtype type;
    public GameObject GameObject;
    
    
    //�κ��丮�� �������� �׾����� ����
    public bool stackable = true;
   
    public enum Items {smartphone, mirror, flaregun, amulet, firecracker, carkey, oil, book, matchbox, flashlight, doorhandle, airtank, rope, belt, carabiner }
    public enum Itemtype {playerItem, ExitItem}
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


}
