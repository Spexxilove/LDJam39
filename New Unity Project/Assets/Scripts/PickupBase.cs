using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBase : MonoBehaviour {

	[SerializeField]
	protected AudioClip pickupSound;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			applyPickupEffect ();
			AudioSource.PlayClipAtPoint (pickupSound, transform.position);
			Destroy (gameObject);
		}
	}

	abstract public void applyPickupEffect ();
}
