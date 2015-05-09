using UnityEngine;
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
		transform.Rotate (new Vector3 (10, 30, 45) * Time.deltaTime);

	}

	void OnTriggerEnter(Collider pickUp) {
		if (pickUp.CompareTag("Player"))
		{
			gameObject.SetActive(false);
			Debug.Log ("Collided Ammo Pack");
			gunReinitialisation();
		}
	}

	void gunReinitialisation() 
	{
		// Debug log.
		Debug.Log ("Picked up Ammo");

		// Perform the replenish function in the ShootGun script, to avoid having to reference it all here which over-complicates things.
		gunScript.ReplenishPistolAmmo ();

		// Debug to confirm it worked the reinitialisation worked and prints the updated value of each clip.
		int temp_clipdebugvar = 0;
		foreach (var clip in gunScript.aClipPistol) {
			Debug.Log ("Clip[" + temp_clipdebugvar + "]: " + clip);	
			temp_clipdebugvar++;
		}
	}
}
