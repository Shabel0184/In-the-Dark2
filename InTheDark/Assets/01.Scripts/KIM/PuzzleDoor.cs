using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Dooropen();
    }

    //¹®¿­¸²
    void Dooropen()
    {
        anim.SetBool("Open", true);
    }
}
