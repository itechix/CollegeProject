using UnityEngine;
using System.Collections;

public class GunAmmo : MonoBehaviour {

	public int ammoCount = 30;
	
	// Update is called once per frame
	void FixedUpdate () {
		ammoDecrease();
	}

	void ammoDecrease () {
		for(int i = 0; i < ammoCount; i++){

			if(Input.GetButtonDown("Fire1")) {
				ammoCount -= 1;
				Debug.Log ("Ammo remaining: " + ammoCount);
			}
		}

	}
}
