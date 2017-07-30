using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerBehaviour : MonoBehaviour {

	[SerializeField]
	private float movementSpeed = 5.0f;
	[SerializeField]
	private float aggroRadius = 5.0f;
	[SerializeField]
	private float rotateSpeed = 45.0f;
	private GameObject player;
	private GameObject core;
	private GameObject target;
	private Rigidbody2D rigidBody;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		core = GameObject.FindGameObjectWithTag ("Core");
		target = core;
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update(){
		if (leeching) {
			CoreHealth.Instance.takeDamage (leechRate*Time.deltaTime);

		}
	}

	void FixedUpdate () {
		chooseTarget ();
		if (target != null) {
			faceTarget ();
			rigidBody.MovePosition (rigidBody.position + (Vector2)rigidBody.transform.up * movementSpeed * Time.fixedDeltaTime);
		}
	}

	private void faceTarget (){

		//rotate to face target
		Vector3 direction = target.transform.position-transform.position;
		float angle = -Vector3.Angle(transform.up,direction)*Mathf.Sign(Vector3.Dot(transform.right,direction));
		float currentRotationSpeed = rotateSpeed ;
		angle = Mathf.Clamp (angle, -currentRotationSpeed, currentRotationSpeed);
		rigidBody.MoveRotation(rigidBody.rotation+angle);


	}

	private void chooseTarget(){
		if (Vector3.Distance (player.transform.position, transform.position) < aggroRadius) {
			target = player;
		} else {
			target = core;
		}
	}


	[SerializeField]
	private float contactDamage =1.0f;
	[SerializeField]
	private float leechRate= 1.0f;
	private bool leeching = false;

	void OnCollisionEnter2D(Collision2D collision){
		GameObject collisionObj = collision.gameObject;
		if (collisionObj.CompareTag ("Player")) {
			collisionObj.GetComponent<PlayerHealth> ().takeDamage (contactDamage);
			Health h = GetComponent<Health> ();
			h.takeDamage (h.getHealth());
		}else if(collisionObj.CompareTag ("Core")){
			leeching = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision){
		if (leeching) {
			GameObject collisionObj = collision.gameObject;
			if(collisionObj.CompareTag ("Core")){
				leeching = false;
			}
		}
	}
}
