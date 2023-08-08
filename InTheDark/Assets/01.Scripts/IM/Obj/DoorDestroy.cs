using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroy : MonoBehaviour
{

    public int fueltank;
    public int matchbox;
    public ParticleSystem particle;



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemPickUp>() != null && other.GetComponent<ItemPickUp>().item.itemType == Item.ItemType.Exititem)
        {
            switch (other.GetComponent<ItemPickUp>().item.itemName)
            {
                case "Fueltank":
                    other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                    fueltank = 1;
                    break;
                case "MatchBox":
                    other.GetComponent<ItemPickUp>().item.exititemUse = 1;
                    matchbox = 1;
                    break;
            }

            
            Fire();
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        fueltank = 0;
        matchbox = 0;
    }

    void Fire()
    {
        if(fueltank > 0 && matchbox > 0 && !particle.isPlaying)
        {
            Debug.Log("Destory");
            particle.Play();
            Destroy(gameObject,5f);
            
            
        }
        
    }
}
