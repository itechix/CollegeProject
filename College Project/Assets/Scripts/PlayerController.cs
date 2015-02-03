using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate() {
		
		// Creating floats to hold the speed of 
		float playerSpeedHorizontal = 4f * Input.GetAxis ("Horizontal");
		float playerSpeedVertical = 4f * Input.GetAxis ("Vertical");



		//float playerSpeedJump = 10f * Input.GetAxis ("Jump");
		
		// Transform statements to move the player by the playerSpeed amount.
		transform.Translate (Vector3.forward * playerSpeedVertical * Time.deltaTime);
		transform.Translate (Vector3.right * playerSpeedHorizontal * Time.deltaTime);
		
		//Vector3 playerJumpCheck = transform.TransformDirection (Vector3.down);

		if (Input.GetButton("Jump"))
		{
			playerJump();
			Debug.Log ("Can jump");
		}
		
		//if(Physics.Raycast(transform.position, playerJumpCheck, playerSpeedJump)) { 
		//	transform.Translate (Vector3.up* playerSpeedJump * Time.deltaTime);
		//	Debug.Log ("You can jump");
		//}
	}
	
	/// Here we handle anything to do with the jump, including the raycast, any animations, and the force setting it's self.
	void playerJump() {

		const float JumpForce = 1.0f;
		Debug.Log ("Should Jump");

		if(Physics.Raycast(rigidbody.position, Vector3.down, collider.bounds.extents.y + 0.1f)) {
		//	Debug.Log ("Can jump");
			rigidbody.AddForce (Vector3.up * JumpForce, ForceMode.VelocityChange);
		}
	}
}