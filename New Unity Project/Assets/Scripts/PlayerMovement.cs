using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float movementspeed =1.0f;



	void Awake(){

	}

	void FixedUpdate () {
		if (!GameManager.Instance.isPaused) {
			updateMovement ();
		}
	}

	private void updateMovement(){
		//translate
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		Vector2 inputVector = new Vector2 (horizontal, vertical);
		inputVector.Normalize ();

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.MovePosition (new Vector2(transform.position.x,transform.position.y)+inputVector * movementspeed * Time.fixedDeltaTime);

		//rotate player to face pointer
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(ray,out hit)){
			Vector3 direction = hit.point-transform.position;
			direction.z = transform.position.z;
			if (direction.magnitude > 1) {
				if (direction.magnitude < 5 && Vector3.Angle (transform.up, direction) < 8.0f) {
					return;
				}
				if (Vector3.Angle (transform.up, direction) > 3.0f) {
					rb.MoveRotation (rb.rotation - Vector3.Angle (transform.up, direction) * Mathf.Sign (Vector3.Dot (transform.right, direction)));
				}
			}
		}
	}


}
