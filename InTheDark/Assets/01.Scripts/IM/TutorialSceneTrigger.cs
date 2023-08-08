using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSceneTrigger : MonoBehaviour
{
    public Image image;
    Color color;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            GameManager.instance.tutorial = 1;
            GameManager.instance.gameDateManager.JsonSave();
            StartCoroutine(FadeIn());
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        color = Color.white;
        color.a = 0f;
        image = GetComponentInChildren<Image>();
        image.color = color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FadeIn()
    {
        while (color.a < 1)
        {
            color.a += 0.1f;
            yield return new WaitForSeconds(0.01f);
            image.color = color;
            if(color.a > 1)
            SceneManager.LoadScene(Random.Range(2, 3));
        }

    }
}
