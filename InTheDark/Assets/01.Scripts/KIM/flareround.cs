using UnityEngine;
using System.Collections;

public class flareround : MonoBehaviour {
	private GameObject flaregun;
	private Gunflare flare;
	public AudioClip pickupSound;	

	// Use this for initialization
	void Start () 
	{
		flaregun = GameObject.Find("flaregun");
		flare = flaregun.GetComponent<Gunflare>();
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.tag == "Player" && flare.currenbullet < flare.maxBullet)
		{
			GetComponent<AudioSource>().PlayOneShot(pickupSound);			
			flare.remainbullet++;
			Destroy(this.gameObject,pickupSound.length);				
		}
		
	}
}

