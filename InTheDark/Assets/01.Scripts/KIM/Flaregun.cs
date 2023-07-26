using UnityEngine;
using System.Collections;

public class Flaregun : MonoBehaviour {
	
	public Rigidbody flareBullet;
	public Transform barrelEnd;
	public GameObject muzzleParticles;
	public AudioClip flareShotSound;
	public AudioClip noAmmoSound;	
	public AudioClip reloadSound;	
	public int bulletSpeed = 2000;
	public int maxSpareRounds = 3;
	public int spareRounds = 3;
	public int currentRound = 3;

	Animation anim;
	AudioSource audioSource;


    private void Start()
    {
		anim = GetComponent<Animation>();
		audioSource = GetComponent<AudioSource>();
    }
    void Update () 
	{
		
		if(Input.GetButtonDown("Fire1") && !anim.isPlaying)
		{
			if(currentRound > 0){
				Shoot();
			}else{
				anim.Play("noAmmo");
				audioSource.PlayOneShot(noAmmoSound);
			}
		}
		if(Input.GetKeyDown(KeyCode.R) && !anim.isPlaying)
		{
			Reload();	
		}
	
	}
	
	void Shoot()
	{
			currentRound--;
		if(currentRound <= 0){
			currentRound = 0;
		}
		
			anim.CrossFade("Shoot");
			audioSource.PlayOneShot(flareShotSound);
		
			
			Rigidbody bulletInstance;
			bulletInstance = Instantiate(flareBullet, barrelEnd.position, barrelEnd.rotation);
				
			
			bulletInstance.AddForce(barrelEnd.forward * bulletSpeed); 
			
			//플레어 파티클 생성
			Instantiate(muzzleParticles, barrelEnd.position,barrelEnd.rotation);		
	}
	
	void Reload()
	{
		if(spareRounds >= 1 && currentRound == 0){
			audioSource.PlayOneShot(reloadSound);			
			spareRounds--;
			currentRound++;
			anim.CrossFade("Reload");
		}
		
	}
}
