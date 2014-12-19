using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	void Awake() {
		Debug.Log ("Player speed set");
	}

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void FixedUpdate() {

		float playerSpeed = 5f * Input.GetAxis ("Horizontal");

		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Debug.Log ("Hori:"+moveHorizontal);
		Debug.Log ("Vert:"+moveVertical);
		
		// Detecting if W key is pressed
		if (moveVertical == 1) {
			transform.Translate (Vector3.forward * playerSpeed * Time.deltaTime);
		}
		// Detecting is S key is pressed
		if (moveVertical == -1) {
			transform.Translate(-Vector3.forward * playerSpeed * Time.deltaTime);
		}
		
		transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);

	}
}