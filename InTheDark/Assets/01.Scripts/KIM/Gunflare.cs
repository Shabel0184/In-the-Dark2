using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gunflare : MonoBehaviour
{
    public GameObject flarebulletPrefab;
    public Transform barreEnd;
    public GameObject MuzzleParticle;

    Animation anim;

    public int maxBullet = 1; //�ִ� �Ѿ� ����
    public int remainbullet = 1;//���� �Ѿ� ����
    public int currenbullet = 1;//źâ���ִ� �Ѿ� ����
    

    public bool isfire = false;

    int enemyLayer;
    int exitobjLayer;
    int layerMask;



    void Start()
    {
        anim = GetComponent<Animation>();

        enemyLayer = LayerMask.NameToLayer("ENEMY");
        exitobjLayer = LayerMask.NameToLayer("Fabric");

        layerMask = 1 << enemyLayer | 1 << exitobjLayer;

        
            

        
        

    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(barreEnd.position, barreEnd.forward, out hit, 10f, layerMask))
        {
            isfire = hit.collider.CompareTag("ENEMY") | hit.collider.CompareTag("Fabric");
        }
        else
        {
            isfire = false;
        }



        //�߻�
        if (isfire && !anim.isPlaying)
        {
            if (currenbullet > 0)
            {
                Fire();
                gameObject.SetActive(false);
                
            }
            else
            {
                anim.Play("noAmmo");
            }
        }
       

    }


    void Fire()
    {
        currenbullet--;
        if (currenbullet == 0)
        {
            currenbullet = 0;
        }
        anim.CrossFade("Shoot");
        Instantiate(flarebulletPrefab, barreEnd.position, barreEnd.rotation);
        Instantiate(MuzzleParticle, barreEnd.position, barreEnd.rotation);
    }

}
