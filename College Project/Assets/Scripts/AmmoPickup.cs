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
		Debug.Log ("Ammo Pickup");
		foreach (int clip in gunScript.aClipPistol) {
			Debug.Log (gunScript.aClipPistol[clip]);
			gunScript.aClipPistol[clip] = 12;
			//clip = 12;
			//Debug.Log (clip);

		}
		//gunScript.aClipPistol [0] = 12;

	}
}