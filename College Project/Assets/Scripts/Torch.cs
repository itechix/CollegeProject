using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	private Light playerTorch;

	void Start() {
		playerTorch = GetComponent<Light> ();
	}

	void Update () {
		if (Input.GetButtonDown("Flashlight")) {
			playerTorch.enabled = !playerTorch.enabled;
		}
	}
}
