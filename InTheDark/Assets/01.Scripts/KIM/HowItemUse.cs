using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowItemUse : MonoBehaviour
{
    public GameObject itemUI;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemUI.SetActive(false);
        }
    }
}
