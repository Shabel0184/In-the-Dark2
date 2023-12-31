using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    public Image fadePanel;
    float fadevalue = 0;
    float backgroundvolum = 1;
    AudioSource backgroundM;
    private void Start()
    {
        backgroundM = GetComponent<AudioSource>();
    }
    public void StartButtonCleckEvent()
    {
        StartCoroutine(StartFadeOut());
    }


    public void EixtButtonCleckEvent()
    {
        StartCoroutine(EixtFadeOut());
    }


    IEnumerator StartFadeOut()
    {
        if(fadePanel != null)
        {
            while (fadevalue < 1f)
            {
                backgroundvolum -= 0.1f; 
                fadevalue += 0.1f;
                fadePanel.color = new Color(0, 0, 0, fadevalue);
                backgroundM.volume = backgroundvolum;
                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return null;
        SceneManager.LoadScene(1);
    }

    IEnumerator EixtFadeOut()
    {
        if (fadePanel != null)
        {
            while (fadevalue < 1f)
            {
                backgroundvolum -= 0.1f;
                fadevalue += 0.1f;
                fadePanel.color = new Color(0, 0, 0, fadevalue);
                backgroundM.volume = backgroundvolum;
                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return null;
        Application.Quit();
    }




}
