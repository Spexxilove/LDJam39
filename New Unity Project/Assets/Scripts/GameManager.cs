using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public GameObject GameOverWindow;
	public GameObject PausedWindow;

	public bool isPaused = false;

	public float survivedTime = 0.0f;

	// Use this for initialization
	void Awake () {
		unpause ();

		if (Instance != null) {
			Destroy (gameObject);
			return;
		}
		survivedTime = 0.0f;
		Instance = this;
	}

	void Update ()
	{
		if (isPaused)
			return;
		if (Input.GetButtonDown ("Cancel")) {
			pause ();
			PausedWindow.SetActive (true);
		}

		survivedTime += Time.deltaTime;
	}

	public void gameOver(){
		GameOverWindow.SetActive (true);
		pause ();
	}

	public void pause(){
		Time.timeScale = 0.0f;
		isPaused = true;
	}
	public void unpause(){
		Time.timeScale = 1.0f;
		isPaused = false;
	}

}
