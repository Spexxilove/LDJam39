using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedScreenManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.isPaused) {
			if (Input.GetButtonDown ("Cancel")) {
				unPause ();
			}
		}
	}

	public void unPause(){
		GameManager.Instance.unpause ();
		gameObject.SetActive (false);
	}

	public void toMenu(){
		unPause ();
		Destroy(GameObject.Find ("Player"));
		SceneManager.LoadScene ("_mainMenu");
	}
}
