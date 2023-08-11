using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;
//using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    public Sound UIsound;


    public Image fadeimage;
    float fadevalue = 0;
    AudioSource audio;
    
    public GameObject esPanel;

    int escape;
    public Image Panel;


   

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.CreatTrapPooling();
        GameManager.instance.CreateExitOBJ();
        GameManager.instance.Load();
        StartCoroutine(StartFadeOut());
        audio = GetComponent<AudioSource>();
        escape = 0;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        EnemyAI.OnTraceSoundEvent += this.SoundCheck;
        EnemyAI.OffSoundEvent += this.SoundOff;
    }
    private void OnDisable()
    {
        EnemyAI.OnTraceSoundEvent -= this.SoundCheck;
        EnemyAI.OffSoundEvent -= this.SoundOff;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escape < 1)
        {
            escape = 1;
            Time.timeScale = 0;
            esPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escape > 0)
        {
            escape = 0;
            Time.timeScale = 1;
            esPanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }



    public void ReStartButtonClick()
    {
        audio.PlayOneShot(UIsound.audioClips[0], 1f);
        StartCoroutine(ReFadeOut());
    }

    public void ExitButton()
    {
        audio.PlayOneShot(UIsound.audioClips[0], 1f);
        StartCoroutine(ExitFadeOut());
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    IEnumerator StartFadeOut()
    {
        fadevalue = 1f;
        yield return new WaitForSeconds(0.5f);
        if (fadeimage != null)
        {
            while (fadevalue > 0)
            {
                Panel.color = new Color(0, 0, 0, fadevalue);
                fadevalue -= 0.1f;


                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return null;


    }
    
    void SoundCheck()
    {
        if(!audio.isPlaying)
        audio.PlayOneShot(UIsound.audioClips[Random.Range(1, 2)], 1f);
    }


    void SoundOff()
    {
        audio.Stop();
    }

}
