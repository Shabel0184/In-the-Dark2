using UnityEngine;
using System.Collections;

public class flareround : MonoBehaviour {
	private GameObject flaregun;
	private Flaregun flare;
	public AudioClip pickupSound;	

	
	void Start () 
	{
		flaregun = GameObject.Find("flaregun");
		flare = flaregun.GetComponent<Flaregun>();
		
	
	}

	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.tag == "Player" && flare.spareRounds < flare.maxSpareRounds)
		{
			GetComponent<AudioSource>().PlayOneShot(pickupSound);			
			flare.spareRounds++;
			Destroy(this.gameObject,pickupSound.length);				
		}
		
	}
}

