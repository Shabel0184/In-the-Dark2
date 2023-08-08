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
    public AudioClip backgroundClip;
    public AudioClip buttonClip;
    public GameObject glassImage;
    public GameObject glassImage_2;
    private void Start()
    {
        backgroundM = GetComponent<AudioSource>();
        backgroundM.clip = backgroundClip;
        backgroundM.Play();

    }
    public void StartButtonCleckEvent()
    {
        backgroundM.PlayOneShot(buttonClip, 1f);
        glassImage.SetActive(true);
        StartCoroutine(StartFadeOut());
    }


    public void EixtButtonCleckEvent()
    {
        backgroundM.PlayOneShot(buttonClip, 1f);
        glassImage_2.SetActive(true);
        StartCoroutine(EixtFadeOut());
    }


    IEnumerator StartFadeOut()
    {
        yield return new WaitForSeconds(0.8f);
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
        if (GameManager.instance.tutorial < 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(Random.Range(2, 3));
        }
    }

    IEnumerator EixtFadeOut()
    {
        yield return new WaitForSeconds(0.8f);
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
