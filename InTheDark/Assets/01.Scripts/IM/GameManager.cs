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
    public GameObject[] exititems;
    public List<GameObject> exitpools = new List<GameObject>();

    [Header("튜토리얼 진행 여부")]
    public int tutorial;
    public GameDateManager gameDateManager;

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
        DontDestroyOnLoad(this.gameObject);
        
    }
    private void Start()
    {
        
        CreatTrapPooling();
        CreateExitOBJ();
        
    }

    //오브젝트 풀 생성 함수
    public void CreatTrapPooling()
    {
        trapPool.Clear();
        GameObject TrapObjectPools = new GameObject("TrapObjectPools");
        for(int i = 0; i < maxPool; i++)
        {
            var obj = Instantiate<GameObject>(trapPrefab, TrapObjectPools.transform);
            obj.name = "Trap" + i.ToString("00");
            obj.SetActive(false);
            trapPool.Add(obj);
        }
    }

    public void CreateExitOBJ()
    {
        exitpools.Clear();
        GameObject ExitItemPools = new GameObject("ExitItemPools");
        for(int i = 0; i <exititems.Length; i++)
        {
            var obj = Instantiate<GameObject>(exititems[i], ExitItemPools.transform);
            obj.name = exititems[i].ToString();
            obj.SetActive(false);
            exitpools.Add(obj);

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

    public void Load()
    {
        camPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    
    void Update()
    {
        
    }
}
