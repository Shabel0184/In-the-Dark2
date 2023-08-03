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

    public int maxBullet = 1; //최대 총알 개수
    public int remainbullet = 1;//남은 총알 개수
    public int currenbullet = 1;//탄창에있는 총알 개수


    public bool isfire = false;

    int enemyLayer;
    int exitobjLayer;
    int layerMask;

    private void OnEnable()
    {
        currenbullet = 1;
        

    }

    void Start()
    {
        anim = GetComponent<Animation>();

        enemyLayer = LayerMask.NameToLayer("ENEMY");
        exitobjLayer = LayerMask.NameToLayer("Fabric");

        layerMask = 1 << enemyLayer | 1 << exitobjLayer;

    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!anim.isPlaying)
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
        GameObject a = Instantiate(MuzzleParticle, barreEnd.position, barreEnd.rotation);
        Destroy(a, 0.3f);
    }

}
