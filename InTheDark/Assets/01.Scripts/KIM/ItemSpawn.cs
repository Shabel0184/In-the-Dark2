using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomItem
{
    public GameObject Prefab;
    //확률변수
    [Range(0f, 100f)] public float Value;
    //가중치
    [HideInInspector]public double itemweight;
}
public class ItemSpawn : MonoBehaviour
{
    public RandomItem[] items;
    public double accumulatedwight; //누적된 가중치 변수
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

    //아이템 생성
    void SpawnItem()
    {
      
      RandomItem randomItem = items[GetRandomIndex()];
      GameObject item = Instantiate(randomItem.Prefab, transform.position,randomItem.Prefab.transform.rotation);
      item.transform.parent = itemspawnpoint.transform;
     
    }

    //아이템 랜덤 생성
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

    //가중치 계산
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
