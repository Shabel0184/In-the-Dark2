using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerMoveUI : MonoBehaviour
{
    public GameObject playerctlUI;
    public GameObject crosshair;
    PlayerMove playerMove;

    int islook;
    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        islook = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        islook = 1;
        if (other.CompareTag("Player"))
        {
            StartCoroutine(playerUI());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerctlUI.SetActive(false);
            crosshair.SetActive(true);
        }
    }

    IEnumerator playerUI()
    {
        if(islook > 0)
        {
            playerctlUI.SetActive(true);
            crosshair.SetActive(false);
            playerMove.stun = true;
            yield return new WaitForSeconds(1f);
        }
        playerMove.stun = false;
    }

}
