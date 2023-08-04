using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PuzzleDoor : MonoBehaviour
{
    Animator anim;
    [SerializeField] private Text Text;
    string codeValue = "";
    public string Code;
    public string Exit;
    public GameObject keypad;
    bool ispanel;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", false);
    }

   
    void Update()
    {
        Text.text = codeValue;


        if (codeValue == Code)
        {
            Dooropen();
            keypad.SetActive(false);
            
            
        }
        if (codeValue.Length >= 5)
        {
            codeValue = "";
        }
        if (Input.GetKeyDown(KeyCode.E) && ispanel == true)
        {
            keypad.SetActive(true);
            
        }

        if(codeValue == Exit)
        {
            keypad.SetActive(false);
        }
        
        
    }

    //¹®¿­¸²
    public void Dooropen()
    {
        anim.SetBool("Open", true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            ispanel = true;
        }
    }

    /*private void OnCollisionExit(Collision collision)
    {
        ispanel = false;
        keypad.SetActive(false);
    }*/


   

    public void digit(string digit)
    {
        codeValue += digit;
    }
}
