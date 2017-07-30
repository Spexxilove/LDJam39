using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffEffectBase : MonoBehaviour {

	protected float buffTime = 0.0f;

	// Use this for initialization
	void Start () {
		startEffect ();
	}
	
	// Update is called once per frame
	void Update () {
		updateEffect ();
		buffTime -= Time.deltaTime;
		if (buffTime <= 0.0f) {
			endEffect ();
			Destroy (this);
		}
	}

	protected abstract void startEffect ();
	protected abstract void updateEffect ();
	protected abstract void endEffect ();

}
