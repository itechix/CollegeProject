using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate() {
		
		// Creating floats to hold the speed of the plater
		float playerSpeedHorizontal = 4f * Input.GetAxis ("Horizontal");
		float playerSpeedVertical = 6f * Input.GetAxis ("Vertical");

		// Transform statements to move the player by the playerSpeed amount.
		transform.Translate (Vector3.forward * playerSpeedVertical * Time.deltaTime);
		transform.Translate (Vector3.right * playerSpeedHorizontal * Time.deltaTime);

		// Calling the playerJump function when the jump key is pressed
		if (Input.GetButton("Jump"))
		{
			playerJump();
		}
	}

	//Here we handle anything to do with the jump, including the raycast, any animations, and the force setting it's self.
	void playerJump() {

    	const float JumpForce = 1f;
		// Debug message for testing whether the function is being called.
//    	Debug.Log ("Should Jump");

    	Vector3 rayOrigin = GetComponent<Collider>().bounds.center;

    	float rayDistance = GetComponent<Collider>().bounds.extents.y + 0.1f;
    	Ray ray = new Ray ();
    	ray.origin = rayOrigin;
    	ray.direction = Vector3.down;

    	if(Physics.Raycast(ray, rayDistance, 1 << 8)) {
			// Debug message for testing whether the player is jumping and if the if statement is being run.
//        	Debug.Log ("Jumping");
        	GetComponent<Rigidbody>().AddForce (Vector3.up * JumpForce, ForceMode.VelocityChange);
    	}
	}
}
