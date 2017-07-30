using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] enemies;
	[SerializeField]
	private GameObject[] cornerObjects;

	private float spawnTime = 2.3f;
	private float spawnTimeMulti =0.96f;
	private float timeSinceLastSpawn = 0.0f;


	private Vector3[] cornerPoints;
	// Use this for initialization
	void Start () {
		cornerPoints = new Vector3[3];
		for (int i = 0; i < 3; i++) {
			cornerPoints [i] = cornerObjects [i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= spawnTime) {
			spawnEnemy ();
		}

	}

	private void spawnEnemy(){
		Vector3 spawnLocation = cornerPoints [0] + Random.value * (cornerPoints [1]-cornerPoints [0]) + Random.value * (cornerPoints [2]-cornerPoints [0]);
		Instantiate (enemies [Random.Range (0, enemies.Length - 1)], spawnLocation, Quaternion.identity);
		timeSinceLastSpawn = 0.0f;
		spawnTime = Mathf.Max(0.25f,spawnTime * spawnTimeMulti);
	}
}
