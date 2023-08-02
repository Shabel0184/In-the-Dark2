using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    PuzzleDoor door;
    [SerializeField] private Text Text;
    string codeValue = "";
    public string Code;
    public GameObject keypad;
    bool ispanel;

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Text.text = codeValue;
        if(codeValue == Code)
        {
            door.Dooropen();
            keypad.SetActive(false);
        }
        if(codeValue.Length >= 4)
        {
            codeValue = "";
        }
        if(Input.GetKeyDown(KeyCode.E) && ispanel == true)
        {
            keypad.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            ispanel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ispanel=false;
        keypad.SetActive(false);
    }

    public void digit(string digit)
    {
        codeValue += digit;
    }
}
