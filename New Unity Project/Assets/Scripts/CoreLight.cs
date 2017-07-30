using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreLight : MonoBehaviour {

	public float energyRegenRate = 0.2f;
	public Light coreLight;
	private float initialIntensity;

	void Start(){
		coreLight = GetComponent<Light> ();
		initialIntensity = coreLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		coreLight.intensity = CoreHealth.Instance.getHealth () / CoreHealth.Instance.maxHealth * initialIntensity;
	}
}
