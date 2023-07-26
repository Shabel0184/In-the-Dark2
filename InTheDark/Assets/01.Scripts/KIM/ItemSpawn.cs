using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomItem
{
    public GameObject Prefab;
    //Ȯ������
    [Range(0f, 100f)] public float Value;
    //����ġ
    [HideInInspector]public double itemweight;
}
public class ItemSpawn : MonoBehaviour
{
    public RandomItem[] items;
    public double accumulatedwight; //������ ����ġ ����
    public System.Random random = new System.Random();
    public GameObject itemspawnpoint;


    private void Awake()
    {
        CalculateWeight();
    }
    void Start()
    {
       SpawnItem();  
    }

    //������ ����
    void SpawnItem()
    {
      
      RandomItem randomItem = items[GetRandomIndex()];
      GameObject item = Instantiate(randomItem.Prefab, transform.position,Quaternion.identity);
      item.transform.parent = itemspawnpoint.transform;
     
    }

    //������ ���� ����
    private int GetRandomIndex()
   {
        double r  = random.NextDouble() * accumulatedwight;

        for(int i = 0; i < items.Length; i++)
        {
            if (items[i].itemweight >=r)
                return i;
        }
        return 0;
   }

    //����ġ ���
    void CalculateWeight()
    {
        accumulatedwight = 0f;
        foreach (RandomItem item in items)
        {
            accumulatedwight += item.Value;
            item.itemweight = accumulatedwight;
        }
    }

    

}
