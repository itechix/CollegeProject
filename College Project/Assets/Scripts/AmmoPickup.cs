﻿using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {
	// ShootGun = script name     gunScript = variable name in this class
	public ShootGun gunScript;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
		// Make the object rotate by the specified angle / amount.
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

	}

	void OnTriggerEnter(Collider pickUp) {
		if (pickUp.CompareTag("Player"))
		{
			Destroy (this.gameObject);
			Debug.Log ("Collided");
			gunReinitialisation();
		}
	}

	void gunReinitialisation() 
	{
		// Debug log.
		Debug.Log ("Ammo Pickup");

		// Perform the replenishment. It makes more sense for this to be a function call instead of doing the work here.
		gunScript.ReplenishPistolAmmo ();

		// Debug to confirm it worked.
		int temp_clipdebugvar = 0;
		foreach (var clip in gunScript.aClipPistol) {
			Debug.Log ("Clip[" + temp_clipdebugvar + "]: "+clip);	
			temp_clipdebugvar++;
		}
		//gunScript.aClipPistol [0] = 12;
	}
}