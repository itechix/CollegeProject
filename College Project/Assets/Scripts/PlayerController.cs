using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate() {
		
		// Creating floats to hold the speed of the plater
		float playerSpeedHorizontal = 0.1f * Input.GetAxis ("Horizontal");
		float playerSpeedVertical = 0.1f * Input.GetAxis ("Vertical");
		float playerMaxSpeed = 4f;

		// Transform statements to move the player by the playerSpeed amount.
		Vector3 velocity = transform.forward * playerSpeedVertical + transform.right * playerSpeedHorizontal;
		velocity.Normalize();
		velocity *= playerMaxSpeed;
		velocity.y = rigidbody.velocity.y;
		rigidbody.velocity = velocity;

		//rigidbody.AddForce (transform.forward * playerSpeedVertical, ForceMode.VelocityChange);
		//rigidbody.AddForce (transform.right * playerSpeedHorizontal, ForceMode.VelocityChange);

		// Calling the playerJump function when the jump key is pressed
		if (Input.GetButton("Jump"))
		{
			playerJump();
			Debug.Log ("Can jump");
		}
	}

	/// Here we handle anything to do with the jump, including the raycast, any animations, and the force setting it's self.
	void playerJump() {

		const float JumpForce = 2.0f;
		Debug.Log ("Should Jump");

		Vector3 rayOrigin = transform.position;
		rayOrigin.y += collider.bounds.extents.y; //move the ray origin up into the collider so that it won't begin in the ground / floor
		float rayDistance = collider.bounds.extents.y + 0.1f;

		Ray ray = new Ray ();
		ray.origin = rayOrigin;
		ray.direction = Vector3.down;

		if(Physics.Raycast(ray, rayDistance, 1 << 9)) {
		//	Debug.Log ("Can jump");
			rigidbody.AddForce (Vector3.up * JumpForce, ForceMode.VelocityChange);
		}
	}
}