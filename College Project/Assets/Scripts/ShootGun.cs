using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour {
	
		
	public Text aCounter;
	public Text aClipCounter;
	public GameObject aEmpty;
	public GameObject aReload;
	
	int aClipCurrent = 0;

	// Creating a list for the different clips for the piston weapon (and the ammo in each clip)
	public List<int> aClipPistol = new List<int> ();

	void Start()
	{
		aClipPistol.Add (8);
		aClipPistol.Add (8);
		aClipPistol.Add (8);
		aClipPistol.Add (8);
		Debug.Log (aClipPistol.Count);

	}


	void FixedUpdate ()
	{
		int aClipCheck = aClipPistol.Count - aClipCurrent;
		aClipCounter.text = "/ " + aClipCheck;
		gunFire();

	}
	void gunFire()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			if(aClipPistol[aClipCurrent] > 0)
			{
				// Reducing the ammo of the current clip by 1.
				aClipPistol[aClipCurrent] -= 1;

				// Debug message for counting the ammo left
				Debug.Log ("Ammo remaining: " + aClipPistol[aClipCurrent]);
				aCounter.text = " " + aClipPistol[aClipCurrent];

				// Raycasting for bullet projection against obstacles within the world (WIP)
				Vector3 gunRayOrigin = transform.position;
				float gunRayDistance = 50f;
				
				Ray gunRay = new Ray ();
				gunRay.origin = gunRayOrigin;
				gunRay.direction = Vector3.down;

				// The actual raycast
				if(Physics.Raycast(gunRayOrigin, gunRay.direction, gunRayDistance)) {
					Debug.Log("Bullet Hit");
				}
			}
			if(aClipPistol[aClipCurrent] == 0)
			{
				// Activating the reload notification on the interface
				aReload.SetActive(true);
				gunReload();
			}
			
		}
	}
	void gunReload()
	{
		Debug.Log ("Reload check");
		if (aClipCurrent <= 3)
		{
			// THIS does not work atm for some reason?
			if (Input.GetButtonDown ("Reload"))
			{
				// Deactivating the reload notification on the interface
				aReload.SetActive(false);
				// Incrementing the aClipCurrent value by 1 so the current clip "should" progress one along? idk
				aClipCurrent += 1;
			}
		}
		else 
		{
			// Deactivating the reload notification and activating the out of ammo notification on the interface
			aReload.SetActive(false);
			aEmpty.SetActive (true);
		}
	}

}