using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	void Start(){
		Time.timeScale = 1.0f;
	}


	public void loadScene(string sceneName){
		SceneManager.LoadScene (sceneName);

	}

	public void quitGame(){
		Application.Quit ();
	}
}
