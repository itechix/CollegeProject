using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate() {
		
		// Creating floats to hold the speed of the plater
		float playerSpeedHorizontal = 4f * Input.GetAxis ("Horizontal");
		float playerSpeedVertical = 4f * Input.GetAxis ("Vertical");


		//Vector3 velocity = transform.forward * playerSpeedVertical + transform.right * playerSpeedHorizontal;
		//velocity.Normalize();
		//velocity *= playerMaxSpeed;
		//velocity.y = rigidbody.velocity.y;
		//rigidbody.velocity = velocity;

		//rigidbody.AddForce (transform.forward * playerSpeedVertical, ForceMode.VelocityChange);
		//rigidbody.AddForce (transform.right * playerSpeedHorizontal, ForceMode.VelocityChange);


		// Transform statements to move the player by the playerSpeed amount.
		transform.Translate (Vector3.forward * playerSpeedVertical * Time.deltaTime);
		transform.Translate (Vector3.right * playerSpeedHorizontal * Time.deltaTime);

		// Calling the playerJump function when the jump key is pressed
		if (Input.GetButton("Jump"))
		{
			playerJump();
			Debug.Log ("Can jump");
		}
	}

	/// Here we handle anything to do with the jump, including the raycast, any animations, and the force setting it's self.
	void playerJump() {

		const float JumpForce = 1.75f;
		Debug.Log ("Should Jump");

		Vector3 rayOrigin = transform.position;
		rayOrigin.y += GetComponent<Collider>().bounds.extents.y; //move the ray origin up into the collider so that it won't begin in the ground / floor
		float rayDistance = GetComponent<Collider>().bounds.extents.y + 0.1f;

		Ray ray = new Ray ();
		ray.origin = rayOrigin;
		ray.direction = Vector3.down;

		if(Physics.Raycast(ray, rayDistance, 1 << 9)) {
		//	Debug.Log ("Can jump");
			GetComponent<Rigidbody>().AddForce (Vector3.up * JumpForce, ForceMode.VelocityChange);
		}
	}
}