using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public bool isPaused = false;

	// Use this for initialization
	void Awake () {
		if (Instance != null) {
			Destroy (gameObject);
			return;
		}

		Instance = this;
	}

}
