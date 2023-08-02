using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�̱���
    public static GameManager instance;

    //Ʈ�� ������ƮǮ
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

    //������Ʈ Ǯ ���� �Լ�
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

    //������Ʈ Ǯ�� ������Ʈ �ѱ��? �Լ�
    public GameObject GetTrap()
    {
        for(int i =0; i < trapPool.Count; i++)
        {
            //Ǯ�� �ִ� Ʈ�� �� ��Ȱ��ȭ �� ������Ʈ ��������
            if (!trapPool[i].activeSelf)
            {
                //��Ȱ��ȭ �Ǿ� �ִ� Ʈ�� ��ȯ
                return trapPool[i];
            }
        }
        return null;
    }


    
    void Update()
    {
        
    }
}
