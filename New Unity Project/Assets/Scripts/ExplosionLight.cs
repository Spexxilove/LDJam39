using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLight : MonoBehaviour {

	public float duration =1.0f;
	private float currentTime = 0.0f;
	private float initIntensity;
	private Light light;
	// Use this for initialization
	void Start () {
		currentTime = duration;
		light = GetComponent<Light> ();
		initIntensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime -= Time.deltaTime;
		light.intensity = currentTime / duration * initIntensity;
		if (currentTime <= 0.0f) {
			Destroy (gameObject);
		}

	}
}
