using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gunflare : MonoBehaviour
{
    public GameObject flarebulletPrefab;
    public Transform firepos;

    public int maxBullet = 3; //ÃÖ´ë ÃÑ¾Ë °¹¼ö
    public int remainbullet = 3;
    

    public bool isfire = false;

    int enemyLayer;
    int exitobjLayer;
    int layerMask;



    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("ENEMY");
        exitobjLayer = LayerMask.NameToLayer("EXIT");

        layerMask = 1 << enemyLayer | 1 << exitobjLayer;

    }

   
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(firepos.position, firepos.forward, out hit,10f,layerMask))
        {
            isfire = hit.collider.CompareTag("ENEMY") | hit.collider.CompareTag("EXIT");

        }
        else
        {
            isfire=false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            remainbullet--;
            Fire();
            if(remainbullet == 0)
            {
                isfire = false;
                enabled = false;
            }

        }
    }

    void Fire()
    {
        Instantiate(flarebulletPrefab, transform.position, Quaternion.identity);
    }
}
