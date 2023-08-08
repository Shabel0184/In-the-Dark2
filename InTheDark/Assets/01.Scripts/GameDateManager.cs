using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class TutorialData
{
    public int tutorial;
}

public class GameDateManager : MonoBehaviour
{
    //데이터 저장할 경로
    string path;

   

    // Start is called before the first frame update
    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();
        DontDestroyOnLoad(gameObject);
    }

    public void JsonLoad()
    {
        TutorialData data = new TutorialData();
        if(!File.Exists(path))
        {
            GameManager.instance.tutorial = 0;
            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            data = JsonUtility.FromJson<TutorialData>(loadJson);

            if(data != null)
            {
               GameManager.instance.tutorial = data.tutorial;
            }
        }
    }


    public void JsonSave()
    {
        TutorialData data = new TutorialData();
        data.tutorial = GameManager.instance.tutorial;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, json);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
