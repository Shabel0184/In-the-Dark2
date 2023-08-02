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
    public List<ItemEffect> effects; // ������ ȿ�� ����Ʈ


    /*public bool Use()
    {
        bool isUesd = false;
        //�ݺ��� ����ؼ� excute ����
        foreach (ItemEffect effect in effects)
        {
            isUesd = effect.Excute();
        }
        return false;
    }*/

    public void Use()
    {
        
        //�ݺ��� ����ؼ� excute ����
        foreach (ItemEffect effect in effects)
        {
            effect.Excute();
        }
        
    }


}