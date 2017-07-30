using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHealth : Health {

	public float energyRegenRate = 0.2f;
	public Light coreLight;
	public static CoreHealth Instance;
	private float initialIntensity;

	void Start(){
		if (Instance != null) {
			Destroy (gameObject);
			return;
		}
		currentHealth = maxHealth;
		isAlive = true;
		Instance = this;
		initialIntensity = coreLight.intensity;
	}

	void Update(){
		heal (energyRegenRate*Time.deltaTime);
		coreLight.intensity = getHealth () / maxHealth * initialIntensity;
	}
		
}
