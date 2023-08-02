using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;

    //트랩 오브젝트풀
    public GameObject trapPrefab;
    public int maxPool = 5;
    public List<GameObject> trapPool = new List<GameObject>();
    public Transform camPos;
    
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
        camPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    private void Start()
    {
        CreatTrapPooling();
        
    }

    //오브젝트 풀 생성 함수
    public void CreatTrapPooling()
    {
        GameObject TrapObjectPools = new GameObject("TrapObjectPools");
        for(int i = 0; i < maxPool; i++)
        {
            var obj = Instantiate<GameObject>(trapPrefab, TrapObjectPools.transform);
            obj.name = "Trap" + i.ToString("00");
            obj.SetActive(false);
            trapPool.Add(obj);
        }
    }

    //오브젝트 풀의 오브젝트 넘기는? 함수
    public GameObject GetTrap()
    {
        for(int i =0; i < trapPool.Count; i++)
        {
            //풀에 있는 트랩 중 비활성화 된 오브젝트 가져오기
            if (!trapPool[i].activeSelf)
            {
                //비활성화 되어 있는 트랩 반환
                return trapPool[i];
            }
        }
        return null;
    }


    
    void Update()
    {
        
    }
}
