using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnergyBar : MonoBehaviour {

	[SerializeField]
	private Image contentBar;

	private float maxValue; // max value of shown stat
	private float minValue =0.0f; // min value of shown stat
	private float initValue;

	private CoreHealth coreHealthScript;

	private float currentValue;

	// Use this for initialization
	void Start () {
		coreHealthScript = GameObject.Find ("Core").GetComponent<CoreHealth> ();
		currentValue = coreHealthScript.getHealth();
		maxValue = coreHealthScript.maxHealth;
	}

	// Update is called once per frame
	void Update () {
		updateBar ();
	}

	public void updateBar(){
		currentValue = coreHealthScript.getHealth();
		contentBar.fillAmount = (currentValue - minValue) / (maxValue - minValue);
	}

}
