using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public PlayerHealth healthPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (10, 45, 30) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider pickUp) {
		if (pickUp.CompareTag("Player"))
		{
			gameObject.SetActive(false);
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