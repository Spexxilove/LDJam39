using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {


	public float fireDelay =1.0f; //time between shots in seconds
	private float timeSinceShot = 0.0f;
	public float shotSpeed =1.0f;
	[SerializeField]
	private float shotSurvivalTime =2.0f;
	public float shotDamage  =1.0f ;
	public float shotEnergyCost  =0.1f ;


	[SerializeField]
	private GameObject shotObject;


	[SerializeField]
	private AudioClip[] shotSounds;

	[SerializeField]
	private GameObject[] playerCannons;


	// Use this for initialization
	void Awake () {
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.isPaused)
			return;
		updateActionInput ();
	}

	private void updateActionInput(){
		timeSinceShot -= Time.deltaTime;

		if (Input.GetButton("Fire1")) {
			if (timeSinceShot <= 0.0f) {
				//shoot
				fireShot();
				timeSinceShot = fireDelay;
			}
		}
	}

	private void fireShot(){
		foreach (GameObject playerCannon in playerCannons) {
			GameObject shotInstance = Instantiate (shotObject, playerCannon.transform.position, playerCannon.transform.rotation);
			ShotScript shotScript = shotInstance.GetComponent<ShotScript> ();
			shotScript.damage = shotDamage;
			shotScript.shotSpeed = shotSpeed;
			shotScript.aliveTime = shotSurvivalTime;
			shotScript.targetTag = "Enemy";
		}
		CoreHealth.Instance.takeDamage (shotEnergyCost);
		playRandomShotSound ();
	}

	private void playRandomShotSound(){
		AudioSource.PlayClipAtPoint (shotSounds [Random.Range (0, shotSounds.Length)], transform.position);
	}
}
