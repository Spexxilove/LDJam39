using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

	public float displacement=1.0f;
	public float movementDistance = 0.4f;
	public float maxMovementSpeed = 0.5f;
	public Material alternativeMat;
	float movementSpeed;
	float currentMovementDist;
	Rigidbody rb;
	bool up = false;

	void Awake(){
		transform.position = transform.position + new Vector3 (0, 0, Random.value * displacement - displacement / 2);
		if (Random.value < 0.05f) {
			GetComponent<Renderer> ().material = alternativeMat;
		}

	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		up = Random.value < 0.5f;
		currentMovementDist = Random.value * movementDistance;
		movementSpeed = Random.value * maxMovementSpeed+0.1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (up) {
			rb.MovePosition(transform.position + new Vector3(0,0,movementSpeed*Time.deltaTime));
			currentMovementDist += movementSpeed * Time.deltaTime;
			if (currentMovementDist >= movementDistance) {
				up = false;
			}
		} else {
			rb.MovePosition(transform.position + new Vector3(0,0,-movementSpeed*Time.deltaTime));
			currentMovementDist -= movementSpeed * Time.deltaTime;
			if (currentMovementDist <= 0.0f) {
				up = true;
			}
		}
	}
}
