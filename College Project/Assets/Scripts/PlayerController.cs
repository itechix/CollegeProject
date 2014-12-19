using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed = 5f * Input.GetAxis ("Horizontal");

	void Awake() {
		Debug.Log ("Player speed set");
	}

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void FixedUpdate() {

		// Detecting if W key is pressed
		if (moveVertical == 1) {
			transform.Translate (Vector3.forward * playerSpeed * Time.deltaTime);
		}
		// Detecting is S key is pressed
		if (moveVertical == -1) {
			transform.Translate(-Vector3.forward * playerSpeed * Time.deltaTime);
		}
		if(moveHorizontal == 1) {
			transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
		}
		if(moveHorizontal == -1) {
			transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
		}

	}
}