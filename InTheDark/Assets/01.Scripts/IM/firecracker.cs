using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firecracker : MonoBehaviour
{
    public GameObject fire;
    public ParticleSystem particle;
    


    private void Start()
    {
     particle = GetComponentInChildren<ParticleSystem>();
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!particle.isPlaying)
            {
                particle.Play();
            }
            
        }
    }



   
}
