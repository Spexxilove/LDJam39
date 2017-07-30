using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenManager : MonoBehaviour {

	[SerializeField]
	private Text survivalTime;

	void Start(){
		survivalTime.text = GameManager.Instance.survivedTime.ToString ("0.0")+ "s";
	}

	public void toMainMenu(){
		SceneManager.LoadScene ("_mainMenu");
	}

	public void tryAgain(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
