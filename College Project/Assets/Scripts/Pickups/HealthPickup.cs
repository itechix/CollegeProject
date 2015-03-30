﻿using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public PlayerHealth healthPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider pickUp) {
		if (pickUp.CompareTag("Player"))
		{
			Destroy (this.gameObject);
			Debug.Log ("Collided Health Pack");
			HealthReinitialisation();
		}
	}
	
	void HealthReinitialisation()
	{
		// Debug log.
		Debug.Log ("Picked up Health");
		healthPlayer.playerHealthRestore ();
	}

}