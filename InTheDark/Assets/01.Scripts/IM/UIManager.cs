using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;
//using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
   
    public Image fadeimage;
    float fadevalue = 0;
    public AudioSource audio;
    public AudioClip clickAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ReStartButtonClick()
    {
        audio.PlayOneShot(clickAudio, 1f);
        StartCoroutine(ReFadeOut());
    }

    public void ExitButton()
    {
        audio.PlayOneShot(clickAudio, 1f);
        StartCoroutine (ExitFadeOut());
    }

    IEnumerator ReFadeOut()
    {
        
        if (fadeimage != null)
        {
            while (fadevalue < 1f)
            {
               
                fadevalue += 0.1f;
                fadeimage.color = new Color(0, 0, 0, fadevalue);
                
                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return null;
        SceneManager.LoadScene(2);
    }

    IEnumerator ExitFadeOut()
    {
        
        if (fadeimage != null)
        {
            while (fadevalue < 1f)
            {

                fadevalue += 0.1f;
                fadeimage.color = new Color(0, 0, 0, fadevalue);

                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return null;
        SceneManager.LoadScene(0);
    }




}
