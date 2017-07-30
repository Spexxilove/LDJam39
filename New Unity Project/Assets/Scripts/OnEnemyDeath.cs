using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDeath : MonoBehaviour {
	public GameObject[] pickups;
	public float[] pickupSpawnProbability;
	public GameObject explosionLight;

	public void enemyDeathEffecs(GameObject enemy){
		spawnPickups (enemy.transform.position);
		Instantiate(explosionLight,enemy.transform.position,Quaternion.identity);
	}

	private void spawnPickups(Vector3 pos){
		for(int i = 0; i< pickups.Length; i++){
			if(Random.value<= pickupSpawnProbability[i]){
				Instantiate(pickups[i],pos,Quaternion.identity);
				return;
			}
		}
	}
}
