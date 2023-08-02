using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostSelect : MonoBehaviour
{
    public GameObject walkGost;

    public GameObject trapGost;
    [SerializeField]
    int Index;

    private void Awake()
    {
        Index = Random.Range(0, 3);
        switch (Index)
        {
            case 0:
                walkGost.SetActive(true);
                break;

            case 1:
                trapGost.SetActive(true);
                break;
            case 2:
                trapGost.SetActive(true);
                break;
            default:
                walkGost.SetActive(true);
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
